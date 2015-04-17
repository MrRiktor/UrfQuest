#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: BattleResultClickHandler.cs
 * Date Created: 4/11/2015 8:28PM EST
 * 
 * Description: Converter for Image Data Class
 * 
 * Changelog: - Modified: Vincent "Sabin" Biancardi
 *            - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using System.Collections;

#endregion

public class BattleResultClickHandler : MonoBehaviour
{
    #region Public Methods

    /// <summary>
    /// Occurs when the victory/Defeat screen's continue button is clicked.
    /// </summary>
    public void OnContinueClick()
    {
        if (BattleManager.GetInstance().WinningTeam == BattleManager.Team.Enemy)
        {
            if (GameData.Strikes >= 3)
            {
                GameData.Victorious = false;
                Messenger<GameStateTypes>.Broadcast(MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.SCOREBOARD);
            }
            else
            {
                Messenger<GameStateTypes>.Broadcast(MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.PROGRESSION);
            }
        }
        else if (BattleManager.GetInstance().WinningTeam == BattleManager.Team.Player)
        {
            if (GameData.CurrentLevel <= 10)
            {
                Messenger<GameStateTypes>.Broadcast(MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.PROGRESSION);
            }
            else
            {
                //REALLY REALLY WIN??? lol
                GameData.Victorious = true;
                Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.SCOREBOARD );
            }

        }
    }

    #endregion
}
