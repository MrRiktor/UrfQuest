#region File Header

/**
 *   File Name:                 IGameStat.cs
 *   Author:                    Vincent Biancardi
 *   Creation Date:             April 8, 2015
 */

#endregion

using UnityEngine;
using System.Collections;

/// <summary>
/// Base Game State Class
/// </summary>
public class BaseGameState : MonoBehaviour, IGameState
{
    #region Variables

    [SerializeField]
    private GameObject MainUIPrefab;

    [SerializeField]
    private GameStateTypes stateType; 

    private GameObject MainUI;

    #endregion

    #region Accessors/Mutators

    public GameStateTypes StateType
    {
        get
        {
            return stateType;
        }
    }

    #endregion

    /// <summary>
    /// Gets called when the GameState Machine
    /// switches to this state
    /// </summary>
    public void OnEnterState( )
    {
        if ( MainUIPrefab == null )
            return;

        MainUI = ( GameObject )Instantiate( MainUIPrefab, Vector3.zero, Quaternion.identity );
    }

    /// <summary>
    /// Gets called when the GameState Machine
    /// switches to another state from this state
    /// </summary>
    public void OnExitState( )
    {
        if ( MainUIPrefab == null )
            return;

        Destroy( MainUI );
        MainUI = null;
    }
}