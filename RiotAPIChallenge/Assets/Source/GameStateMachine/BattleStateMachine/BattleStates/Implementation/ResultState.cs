using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ResultState : BattleState
{
    
    /// <summary>
    /// Default Constructor
    /// </summary>
    public ResultState()
    {
        this.StateType = BattleStateType.ResultState;
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnEnter()
    {
        base.OnEnter();

        if (BattleManager.GetInstance().winningTeam == BattleManager.Team.Enemy)
        {
            if( GameData.Strikes >= 3 )
            {
                Messenger<GameStateTypes>.Broadcast(MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.INTRO);
            }
            else
            {
                ++GameData.Strikes;
                Messenger<GameStateTypes>.Broadcast(MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.PROGRESSION);
            }

            UnityEngine.Debug.Log("YOU LOSE!");
        }
        else if(BattleManager.GetInstance().winningTeam == BattleManager.Team.Player)
        {
            ++GameData.CurrentLevel;
            Messenger<GameStateTypes>.Broadcast(MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.PROGRESSION);

            UnityEngine.Debug.Log("YOU WIN!");
        }
    } 
}
