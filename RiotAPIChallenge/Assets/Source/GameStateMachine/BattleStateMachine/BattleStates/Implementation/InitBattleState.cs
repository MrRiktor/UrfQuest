using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InitBattleState : BattleState
{
    /// <summary>
    /// Default Constructor
    /// </summary>
    public InitBattleState()
    {
        this.StateType = BattleState.BattleStateType.InitBattleState;
        OnEnter();
    }

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
}
