using UnityEngine;
using System.Collections;

public class IntroView : MonoBehaviour {

    /// <summary>
    /// Handles the play button press
    /// </summary>
    public void OnPlayHandler( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.TEAMSELECT );
    }
}
