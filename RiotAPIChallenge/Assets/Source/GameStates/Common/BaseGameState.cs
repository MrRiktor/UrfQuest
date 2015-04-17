#region File Header

/*******************************************************************************
 * Author: Vincent "Sabin" Biancardi
 * Filename: BaseGameState.cs
 * Date Created: 4/8/2015 6:50PM EST
 * 
 * Description: Base game state of our game state machine.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 8:13 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;

#endregion

public class BaseGameState : MonoBehaviour, IGameState
{
    #region Private Variables

    /// <summary>
    /// The MainUI prefab GameObject.
    /// </summary>
    [SerializeField]
    private GameObject MainUIPrefab;

    /// <summary>
    /// The State type.
    /// </summary>
    [SerializeField]
    private GameStateTypes stateType; 

    /// <summary>
    /// Main UI GameObject
    /// </summary>
    private GameObject MainUI;

    #endregion

    #region Accessors/Mutators

    /// <summary>
    /// Accessor for the state type.
    /// </summary>
    public GameStateTypes StateType
    {
        get
        {
            return stateType;
        }
    }

    #endregion

    #region Public Methods

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

    #endregion
}