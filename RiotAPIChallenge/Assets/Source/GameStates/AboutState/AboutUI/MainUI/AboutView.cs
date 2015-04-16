using UnityEngine;
using System.Collections;

public class AboutView : MonoBehaviour
{
    /// <summary>
    /// On back
    /// </summary>
    public void OnBack( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.INTRO );
    }

}