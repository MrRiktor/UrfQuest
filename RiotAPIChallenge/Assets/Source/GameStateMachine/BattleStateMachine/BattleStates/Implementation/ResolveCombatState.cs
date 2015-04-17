#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: ResolveCombatState.cs
 * Date Created: 4/12/2015 8:28PM EST
 * 
 * Description: This state resolves combat after each complete loop of the attack queue
 *              until the queue is empty of either team and a winner is chosen.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/14/2015 1:28 AM
 *              - Modified: Matthew "Riktor" Baker - 4/16/2015 9:07 PM - Added Comments
 *******************************************************************************/

#endregion

public class ResolveCombatState : BattleState
{
    #region Constructor

    /// <summary>
    /// Default Constructor - sets this states BattleStateType.
    /// </summary>
    public ResolveCombatState()
    {
        this.StateType = BattleStateType.ResolveCombatState;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Overrides BattleState's OnExit() - Occurs when the state is exited.
    /// </summary>
    public override void OnExit()
    {
 	    base.OnExit();
    }

    /// <summary>
    /// Overrides BattleState's OnEnter() - Occurs when the state is entered.
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();

        if( BattleManager.GetInstance().WinningTeam == BattleManager.Team.None )
        {
            BattleManager.GetInstance().StateMachine.TransitionToState(BattleState.BattleStateType.CombatState);
        }
        else
        {
            BattleManager.GetInstance().StateMachine.TransitionToState(BattleState.BattleStateType.ResultState);
        }
    }

    /// <summary>
    /// Overrides BattleState's Update() - Occurs while the state is active.
    /// </summary>
    public override void Update()
    {

    }

    #endregion
}
