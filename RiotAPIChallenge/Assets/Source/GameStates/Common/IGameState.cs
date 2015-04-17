#region File Header

/*******************************************************************************
 * Author: Vincent "Sabin" Biancardi
 * Filename: IGameState.cs
 * Date Created: 4/8/2015 6:50PM EST
 * 
 * Description: Interface used to initialize and clean up a Game State
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 8:13 PM - Added Comments
 *******************************************************************************/

#endregion

public interface IGameState
{
    /// <summary>
    /// Gets called when the GameState Machine
    /// switches to this state
    /// </summary>
    void OnEnterState( );

    /// <summary>
    /// Gets called when the GameState Machine
    /// switches to another state from this state
    /// </summary>
    void OnExitState( );
}