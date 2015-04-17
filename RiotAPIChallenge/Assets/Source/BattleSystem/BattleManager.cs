#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: BattleManager.cs
 * Date Created: 4/11/2015 1:49AM EST
 * 
 * Description: This is the main combat handler, the hub that all combat functionality passes through.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 3:55 AM
 *              - Modified: Matthew "Riktor" Baker - 4/16/2015 6:46 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using System.Collections.Generic;

#endregion

public class BattleManager : MonoBehaviour
{
    #region Public Enum

    /// <summary>
    /// Enum that defines what team a PartyMember belongs to.
    /// </summary>
    public enum Team
    {
        None,
        Enemy,
        Player
    };

    #endregion
    
    #region Private Member Variables

    #region Instance of BattleManager

    /// <summary>
    /// The singleton instance of this manager.
    /// </summary>
    private static BattleManager instance = null;

    #endregion

    #region SerializeField Variables

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

    /// <summary>
    /// The victory screen UI GameObject.
    /// </summary>
    [SerializeField] private GameObject victoryPrefab = null;

    /// <summary>
    /// The defeat screen UI GameObject.
    /// </summary>
    [SerializeField] private GameObject defeatPrefab = null;

    #endregion

    /// <summary>
    /// A Boolean defining whether or not the visual team items have been setup.
    /// </summary>
    private bool areTeamsInitialized = false;

    /// <summary>
    /// The list that contains all combat members. They are placed in this list ordered by movementspeed from highest to lowest. 
    /// This will define the turn order in the combat state.
    /// </summary>
    private List<PartyMemberItem> attackQueue = new List<PartyMemberItem>();

    /// <summary>
    /// Global index of the attackQueue.
    /// </summary>
    private static int attackQueueIndex = 0;

    /// <summary>
    /// A boolean determining whether autobattle is turned on or off. ( Default: OFF)
    /// </summary>
    private bool autoBattleEnabled = false;

    /// <summary>
    /// The instance of the currently selected target.
    /// </summary>
    private PartyMemberItem playerTarget = null;

    /// <summary>
    /// The winning team object. 
    /// </summary>
    private Team winningTeam = Team.None;

    /// <summary>
    /// The statemachine that drives combat flow.
    /// </summary>
    private BattleStateMachine stateMachine;
    
    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// Accessor for the DefeatPrefab GameObject.
    /// </summary>
    public GameObject DefeatPrefab
    {
        get
        {
            return defeatPrefab;
        }
    }

    /// <summary>
    /// Accessor for the VictoryPrefab GameObject.
    /// </summary>
    public GameObject VictoryPrefab
    {
        get
        {
            return victoryPrefab;
        }
    }
    
    /// <summary>
    /// Accessor for the AttackQueue List.
    /// </summary>
    public List<PartyMemberItem> AttackQueue
    {
        get
        {
            return this.attackQueue;
        }
    }

    /// <summary>
    /// Accessor for the WinningTeam object.
    /// </summary>
    public Team WinningTeam
    {
        get
        {
            return this.winningTeam;
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
    /// Set's the players current target if it is valid.
    /// </summary>
    /// <param name="target"> the target we wish to make the players target. </param>
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

    /// <summary>
    /// Handler for the when the attack button is clicked.
    /// </summary>
    public void AttackClicked()
    {
        BattleManager.GetInstance().AttackQueue[attackQueueIndex].SetTarget(playerTarget);
        BattleManager.GetInstance().AttackQueue[attackQueueIndex].AttackClicked();
    }

    /// <summary>
    /// Handler for when the taunt button is clicked.
    /// </summary>
    public void TauntClicked()
    {
        BattleManager.GetInstance().AttackQueue[attackQueueIndex].SetTarget(playerTarget);
        BattleManager.GetInstance().AttackQueue[attackQueueIndex].TauntClicked();
    }
    
    /// <summary>
    /// Resets the state of the attack queue and the partymember inside.
    /// </summary>
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
        List<PartyMemberItem> playerTeam = playerParty.GetComponent<SetupParty>().SetupTheParty(GameData.CurrentParty);
        List<PartyMemberItem> enemyTeam = enemyParty.GetComponent<SetupParty>().SetupTheParty(GameData.StageMap.Stages[GameData.CurrentLevel].Enemies);

        BattleManager.GetInstance().AttackQueue.AddRange(playerTeam);
        BattleManager.GetInstance().AttackQueue.AddRange(enemyTeam);
        
        SortAttackQueue();
        
        areTeamsInitialized = true;
    }

    /// <summary>
    /// Called by BattleStateMachine's CombatState's Update(). The main logic of the battle system is done here. 
    /// </summary>
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
