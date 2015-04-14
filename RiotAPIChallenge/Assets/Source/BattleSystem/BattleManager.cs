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
    [SerializeField] private GameObject EnemyParty = null;
    
    /// <summary>
    /// The Gameobject that acts as a container and holds the Player party members. 
    /// This grants us access to the SetupParty Component on the Party GameObject.
    /// </summary>
    [SerializeField] private GameObject PlayerParty = null;

    /// <summary>
    /// A Boolean defining whether or not the visual team items have been setup.
    /// </summary>
    private bool areTeamsInitialized = false;

    /// <summary>
    /// The list that contains all combat members. They are placed in this list ordered by movementspeed from highest to lowest. 
    /// This will define the turn order in the combat state.
    /// </summary>
    private List<PartyMemberItem> attackQueue = new List<PartyMemberItem>();

    private List<PartyMemberItem> enemyTeam = new List<PartyMemberItem>();
    private List<PartyMemberItem> playerTeam = new List<PartyMemberItem>();

    public Team winningTeam = Team.None;

    /// <summary>
    /// The statemachine that drives combat flow.
    /// </summary>
    private BattleStateMachine stateMachine;
    
    #endregion

    #region Accessors/Modifiers

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
    /// The accessor to this singleton instance.
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
    /// Initializes the both teams. Delegates the setup of the visual objects to the party Gameobject's SetupParty Components.
    /// </summary>
    public void InitializeTeams()
    {
        playerTeam = PlayerParty.GetComponent<SetupParty>().SetupTheParty(GameData.CurrentParty);
        enemyTeam = EnemyParty.GetComponent<SetupParty>().SetupTheParty(GameData.StageMap.Stages[GameData.CurrentLevel].Enemies);
        
        attackQueue.AddRange(playerTeam);
        attackQueue.AddRange(enemyTeam);
        
        SortAttackQueue();
        
        areTeamsInitialized = true;
    }
    
    private PartyMemberItem lastattacker = null;
    private PartyMemberItem lastattackee = null;

    public int i = 0;

    public void Fight()
    {
        if (i >= (attackQueue.Count))
        {
            stateMachine.TransitionToState(BattleState.BattleStateType.ResolveCombatState);
        }    
        
        // Attacker is not dead. (a.k.a. HP <= 0)
        if (attackQueue[i].IsAlive && lastattacker != attackQueue[i])
        {
            lastattacker = attackQueue[i];

            PartyMemberItem target = GetRandomTarget(attackQueue[i].IsEnemy);

            if (target == null)
            {
                Debug.Log("Could not find target, all enemies or partymembers are dead.");
                winningTeam = ((attackQueue[i].IsEnemy) ? Team.Enemy : Team.Player);
                stateMachine.TransitionToState(BattleState.BattleStateType.ResolveCombatState);
                return;
            }

            lastattackee = target;

            attackQueue[i].SetTarget(target);
        }

        if( !attackQueue[i].IsAlive || attackQueue[i].IsWaiting() )
        {
            i++;
        }
    }
    
    #endregion

    #region Private Methods

    /// <summary>
    /// Grabs a random target for the current attacker to attack.
    /// </summary>
    /// <returns></returns>
    private PartyMemberItem GetRandomTarget(bool isEnemy)
    {
        int index = 0;
        List<PartyMemberItem> aliveOpponents = new List<PartyMemberItem>();

        foreach(PartyMemberItem pmi in attackQueue)
        {
            if( pmi.IsAlive && ( pmi.IsEnemy != isEnemy ) ) 
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
