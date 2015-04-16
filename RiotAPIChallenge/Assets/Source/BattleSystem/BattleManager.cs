using UnityEngine;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour
{

    #region Public Enum

    public enum Team
    {
        None,
        Enemy,
        Player
    };

    #endregion


    #region Private Member Variables

    /// <summary>
    /// The singleton instance of this manager.
    /// </summary>
    private static BattleManager instance = null;

    /// <summary>
    /// The Gameobject that acts as a container and holds the Enemy party members. 
    /// This grants us access to the SetupParty Component on the Party GameObject.
    /// </summary>
    [SerializeField] private GameObject enemyParty = null;
    
    /// <summary>
    /// The Gameobject that acts as a container and holds the Player party members. 
    /// This grants us access to the SetupParty Component on the Party GameObject.
    /// </summary>
    [SerializeField] private GameObject playerParty = null;

    [SerializeField] private GameObject victoryPrefab = null;
    [SerializeField] private GameObject defeatPrefab = null;

    /// <summary>
    /// A Boolean defining whether or not the visual team items have been setup.
    /// </summary>
    private bool areTeamsInitialized = false;

    /// <summary>
    /// The list that contains all combat members. They are placed in this list ordered by movementspeed from highest to lowest. 
    /// This will define the turn order in the combat state.
    /// </summary>
    private List<PartyMemberItem> attackQueue = new List<PartyMemberItem>();

    public List<PartyMemberItem> AttackQueue
    {
        get
        {
            return this.attackQueue;
        }
    }

    private static int attackQueueIndex = 0;

    private bool autoBattleEnabled = false;

    private List<PartyMemberItem> enemyTeam = new List<PartyMemberItem>();
    private List<PartyMemberItem> playerTeam = new List<PartyMemberItem>();

    private PartyMemberItem playerTarget = null;

    private Team winningTeam = Team.None;

    /// <summary>
    /// The statemachine that drives combat flow.
    /// </summary>
    private BattleStateMachine stateMachine;
    
    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// 
    /// </summary>
    public GameObject DefeatPrefab
    {
        get
        {
            return defeatPrefab;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public GameObject VictoryPrefab
    {
        get
        {
            return victoryPrefab;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Team WinningTeam
    {
        get
        {
            return this.winningTeam;
        }
    }

    /// <summary>
    /// A Boolean defining whether or not the visual team items have been setup.
    /// </summary>
    public bool AreTeamsInitialized
    {
        get
        {
            return areTeamsInitialized;
        }
    }

    /// <summary>
    /// Accessor to statemachine that drives combat flow. This allows objects outside of this battle manager to tell the statemachine to transition.
    /// </summary>
    public BattleStateMachine StateMachine
    {
        get
        {
            return stateMachine;
        }
    }

    #endregion

    #region Native Unity Methods

    /// <summary>
    /// Used for initialization of the singleton instance
    /// </summary>
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        stateMachine = new BattleStateMachine(new InitBattleState());
    }

    /// <summary>
    /// Use this for initialization
    /// </summary>
	void Start() 
    {
        
	}
		
    /// <summary>
    /// Update is called once per frame
    /// </summary>
	void Update() 
    {
        stateMachine.CurrentState.Update();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// The accessor to this singleton BattleManager.GetInstance().
    /// </summary>
    /// <returns> Returns the instance of this manager. </returns>
    public static BattleManager GetInstance()
    {
        if( instance == null )
        {
            Debug.LogError("BattleManager instance is null.");
        }
        return instance;
    }

    public void SetPlayerTarget(PartyMemberItem target)
    {
        if (target.CombatStatus.BeingType == Being.BeingType.Enemy && target.CombatStatus.IsAlive())
        {
            if (BattleManager.GetInstance().playerTarget != null)
            {
                BattleManager.GetInstance().playerTarget.SetTargetIconActive(false);
            }

            BattleManager.GetInstance().playerTarget = target;
            target.SetTargetIconActive(true);
            SoundManager.GetInstance().PlaySound(SoundManager.SoundClip.TargetPing);
        }
        else
        {
            Debug.Log("YOU CANNOT TARGET AN ALLY.");
        }
    }

    public void AttackClicked()
    {
        BattleManager.GetInstance().AttackQueue[attackQueueIndex].SetTarget(playerTarget);
        BattleManager.GetInstance().AttackQueue[attackQueueIndex].AttackClicked();
    }

    public void TauntClicked()
    {
        BattleManager.GetInstance().AttackQueue[attackQueueIndex].SetTarget(playerTarget);
        BattleManager.GetInstance().AttackQueue[attackQueueIndex].TauntClicked();
    }
    
    public void ResetAttackQueue()
    {
        attackQueueIndex = 0;

        foreach (PartyMemberItem partyMemberItem in BattleManager.GetInstance().AttackQueue)
        {
            partyMemberItem.ResetState();
        }

    }

    /// <summary>
    /// Initializes the both teams. Delegates the setup of the visual objects to the party Gameobject's SetupParty Components.
    /// </summary>
    public void InitializeTeams()
    {
        playerTeam = playerParty.GetComponent<SetupParty>().SetupTheParty(GameData.CurrentParty);
        enemyTeam = enemyParty.GetComponent<SetupParty>().SetupTheParty(GameData.StageMap.Stages[GameData.CurrentLevel].Enemies);

        BattleManager.GetInstance().AttackQueue.AddRange(playerTeam);
        BattleManager.GetInstance().AttackQueue.AddRange(enemyTeam);
        
        SortAttackQueue();
        
        areTeamsInitialized = true;
    }

    public void Fight()
    {
        if (attackQueueIndex >= (BattleManager.GetInstance().AttackQueue.Count) || !winningTeam.Equals(Team.None))
        {
            stateMachine.TransitionToState(BattleState.BattleStateType.ResolveCombatState);
        }

        if (BattleManager.GetInstance().AttackQueue[attackQueueIndex].CombatStatus.IsAlive() && BattleManager.GetInstance().AttackQueue[attackQueueIndex].IsWaiting())
        {
            //Enemy Turn
            if (BattleManager.GetInstance().AttackQueue[attackQueueIndex].CombatStatus.BeingType.Equals(Being.BeingType.Enemy))
            {
                PartyMemberItem target = GetRandomTarget(Being.BeingType.Player);

                if(target != null)
                {
                    // Perform Attack
                    BattleManager.GetInstance().AttackQueue[attackQueueIndex].SetTarget(target);
                    BattleManager.GetInstance().AttackQueue[attackQueueIndex].AttackTarget();
                }
                else
                {
                    this.winningTeam = Team.Enemy;
                }
            }
            // Player Turn
            else 
            {
                // A random enemy if we decide to use it.
                PartyMemberItem target = GetRandomTarget(Being.BeingType.Enemy);

                if (target == null)
                {
                    this.winningTeam = Team.Player;
                }
                else
                {
                    BattleManager.GetInstance().AttackQueue[attackQueueIndex].SetTarget(playerTarget);

                    if (autoBattleEnabled == true)
                    {
                        if (BattleManager.GetInstance().AttackQueue[attackQueueIndex].GetAttackTarget() == null)
                        {
                            BattleManager.GetInstance().AttackQueue[attackQueueIndex].SetTarget(target);
                        }

                        // Perform Attack
                        BattleManager.GetInstance().AttackQueue[attackQueueIndex].AttackTarget();
                    }
                    else
                    {
                        if (BattleManager.GetInstance().AttackQueue[attackQueueIndex].CombatState == PartyMemberItem.CombatStates.None)
                        {
                            BattleManager.GetInstance().AttackQueue[attackQueueIndex].SetAttackTauntBarActive(true);
                            SoundManager.GetInstance().PlaySound(SoundManager.SoundClip.PlayerTurn);

                            BattleManager.GetInstance().AttackQueue[attackQueueIndex].SetBorderPanelActive(true);
                            BattleManager.GetInstance().AttackQueue[attackQueueIndex].CombatState = PartyMemberItem.CombatStates.Ready;
                        }

                        if( BattleManager.GetInstance().AttackQueue[attackQueueIndex].CombatState == PartyMemberItem.CombatStates.Ready )
                        {
                            BattleManager.GetInstance().AttackQueue[attackQueueIndex].IsMitigating = false;
                            BattleManager.GetInstance().AttackQueue[attackQueueIndex].SetTauntIconActive(false);
                        }

                        if (BattleManager.GetInstance().AttackQueue[attackQueueIndex].CombatState == PartyMemberItem.CombatStates.Attacking)
                        {
                            BattleManager.GetInstance().AttackQueue[attackQueueIndex].SetBorderPanelActive(false);
                            if (BattleManager.GetInstance().AttackQueue[attackQueueIndex].GetAttackTarget() == null)
                            {
                                BattleManager.GetInstance().AttackQueue[attackQueueIndex].SetTarget(target);
                            }
                            
                            // Perform Attack
                            BattleManager.GetInstance().AttackQueue[attackQueueIndex].AttackTarget();
                        }
                        else if (BattleManager.GetInstance().AttackQueue[attackQueueIndex].CombatState == PartyMemberItem.CombatStates.Taunting)
                        {
                            if (!SoundManager.GetInstance().IsPriorityClipPlaying())
                            {
                                BattleManager.GetInstance().AttackQueue[attackQueueIndex].SetBorderPanelActive(false);
                                if (BattleManager.GetInstance().AttackQueue[attackQueueIndex].GetTauntTarget() == null)
                                {
                                    BattleManager.GetInstance().AttackQueue[attackQueueIndex].SetTarget(target);
                                }

                                BattleManager.GetInstance().AttackQueue[attackQueueIndex].TauntTarget();
                            }
                        }
                    }
                }
            }
        }

        if (!BattleManager.GetInstance().AttackQueue[attackQueueIndex].CombatStatus.IsAlive() || BattleManager.GetInstance().AttackQueue[attackQueueIndex].IsOnCooldown())
        {
            ++attackQueueIndex;
        }
    }
    
    #endregion

    #region Private Methods

    /// <summary>
    /// Grabs a random target for the current attacker to attack.
    /// </summary>
    /// <returns></returns>
    private PartyMemberItem GetRandomTarget(Being.BeingType beingType)
    {
        int index = 0;
        List<PartyMemberItem> aliveOpponents = new List<PartyMemberItem>();

        foreach(PartyMemberItem pmi in attackQueue)
        {
            if (pmi.CombatStatus.IsAlive() && (pmi.CombatStatus.BeingType.Equals(beingType))) 
            {
                aliveOpponents.Add(pmi);
            }
        }

        if (aliveOpponents.Count <= 0)
        {
            return null;
        }
        else
        {
            index = Random.Range(0, (aliveOpponents.Count - 1));
            return aliveOpponents[index];
        }
    }

    /// <summary>
    /// Sorts the attack list from highest movement speed to lowest.
    /// </summary>
    private void SortAttackQueue()
    {
        attackQueue.Sort((p1, p2) => (-1 * p1.PartyMemberData.MovementSpeed.CompareTo(p2.PartyMemberData.MovementSpeed)));

        Debug.Log("Debug");
    }

    #endregion
}
