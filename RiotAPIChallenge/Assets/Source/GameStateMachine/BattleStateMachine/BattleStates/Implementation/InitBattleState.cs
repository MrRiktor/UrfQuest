#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: InitBattleState.cs
 * Date Created: 4/12/2015 8:28PM EST
 * 
 * Description: This state initializes the battle system.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/14/2015 12:02 AM
 *              - Modified: Matthew "Riktor" Baker - 4/16/2015 9:07 PM - Added Comments
 *******************************************************************************/

#endregion

public class InitBattleState : BattleState
{    
    #region Constructor

    /// <summary>
    /// Default Constructor - sets this states BattleStateType.
    /// </summary>
    public InitBattleState()
    {
        this.StateType = BattleState.BattleStateType.InitBattleState;
        OnEnter();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Occurs when this state is entered from another state.
    /// </summary>
    public override void OnEnter()
    {
        base.OnEnter();

        BattleManager.GetInstance().InitializeTeams();
    }
    
    /// <summary>
    /// Occurs when this state is exited to another state.
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
    }

    /// <summary>
    /// This is called every frame while this state is the current state.
    /// </summary>
    public override void Update()
    {
        base.Update();

        if( BattleManager.GetInstance().AreTeamsInitialized )
        {
            SoundManager.GetInstance().PlaySoundOnce(SoundManager.SoundClip.WelcomeToSummonersRift);
            if (!SoundManager.GetInstance().IsClipPlaying())
            {
                BattleManager.GetInstance().StateMachine.TransitionToState(BattleStateType.CombatState);
            }
        }
    }

    #endregion
}
