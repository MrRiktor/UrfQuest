using UnityEngine;
using System.Collections;

public class ProgressionView : MonoBehaviour
{

    /// <summary>
    /// Handles the play button press
    /// </summary>
    public void OnContinueHandler( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.BATTLE );
    }
}