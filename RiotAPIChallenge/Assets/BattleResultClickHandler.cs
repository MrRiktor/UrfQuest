using UnityEngine;
using System.Collections;

public class BattleResultClickHandler : MonoBehaviour 
{
    public void OnContinueClick()
    {
        if (BattleManager.GetInstance().WinningTeam == BattleManager.Team.Enemy)
        {
            if (GameData.Strikes >= 3)
            {
                Messenger<GameStateTypes>.Broadcast(MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.INTRO);
            }
            else
            {
                Messenger<GameStateTypes>.Broadcast(MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.PROGRESSION);
            }
        }
        else if (BattleManager.GetInstance().WinningTeam == BattleManager.Team.Player)
        {
            if (GameData.CurrentLevel <= 9)
            {
                Messenger<GameStateTypes>.Broadcast(MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.PROGRESSION);
            }
            else
            {
                //REALLY REALLY WIN??? lol
                //Messenger<GameStateTypes>.Broadcast(MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.VICTORY);
            }

        }
    }
}
