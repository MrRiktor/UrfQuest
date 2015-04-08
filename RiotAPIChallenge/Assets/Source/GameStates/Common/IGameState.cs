#region File Header

/**
 *   File Name:                 IGameStat.cs
 *   Author:                    Vincent Biancardi
 *   Creation Date:             April 8, 2015
 */

#endregion

/// <summary>
/// Interface used to initialize
/// and clean up a Game State
/// </summary>
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