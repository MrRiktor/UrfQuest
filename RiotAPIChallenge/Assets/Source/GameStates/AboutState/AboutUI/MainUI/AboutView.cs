#region File Header

/*******************************************************************************
 * Author:  Vincent "Sabin" Biancardi
 * Filename: AboutView.cs
 * Date Created: 4/16/2015 3:25AM EST
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;

#endregion

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