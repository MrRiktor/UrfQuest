
public class ResolveCombatState : BattleState
{   
    /// <summary>
    /// Default Constructor
    /// </summary>
    public ResolveCombatState()
    {
        this.StateType = BattleStateType.ResolveCombatState;
    }

    public override void OnExit()
    {
 	    base.OnExit();
    }

    public override void OnEnter()
    {
        base.OnEnter();

        if( BattleManager.GetInstance().winningTeam == BattleManager.Team.None )
        {
            BattleManager.GetInstance().StateMachine.TransitionToState(BattleState.BattleStateType.CombatState);
        }
        else
        {
            BattleManager.GetInstance().StateMachine.TransitionToState(BattleState.BattleStateType.ResultState);
        }
    }

    public override void Update()
    {

    }
}
