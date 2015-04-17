#region File Header

/*******************************************************************************
 * Author:  Vincent "Sabin" Biancardi
 * Filename: GameStateMachine.cs
 * Date Created: 4/8/2015 4:58PM EST
 * 
 * Description: The state machine that drives our battle system.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using System;
using System.Collections.Generic;

#endregion

public class GameStateMachine : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private GameObject [] gameStates;

    private Dictionary<GameStateTypes, BaseGameState> states = new Dictionary<GameStateTypes, BaseGameState>( );

    private BaseGameState curState;
    private BaseGameState prevState;

    #endregion

    #region Unity Methods

    /// <summary>
    /// Initialize the game states
    /// </summary>
    void Awake( )
    {
        JSONUtils.initJsonObjectConversion( );

        if ( gameStates == null )
        {
            throw new ArgumentNullException("There are no game states");
        }

        for ( Int32 i = 0; i < gameStates.Length; i++ )
        {
            BaseGameState gameState = gameStates [ i ].GetComponent<BaseGameState>( );

            if ( gameState == null )
            {
                Debug.LogError( "A Game State in the editor does not have the appropriate BaseGameState Attached to it" );
            }
            else
            {
                states.Add( gameState.StateType, gameState );
            }
        }

        OnStateChange( GameStateTypes.INTRO );
    }

    /// <summary>
    /// Triggered when the game object this scrip
    /// is attached to is enabled
    /// </summary>
    void OnEnable( )
    {
        Messenger<GameStateTypes>.AddListener( MessengerEventTypes.GAME_STATE_CHANGE, OnStateChange );
    }

    /// <summary>
    /// Triggered when the game object this scrip
    /// is attached to is disabled
    /// </summary>
    void OnDisable( )
    {
        Messenger<GameStateTypes>.RemoveListener( MessengerEventTypes.GAME_STATE_CHANGE, OnStateChange );
    }

    #endregion

    #region Private Helper Methods

    /// <summary>
    /// Changes the game state
    /// </summary>
    /// <param name="stateType">which state to transition to</param>
    private void OnStateChange( GameStateTypes stateType )
    {
        //Clean up the previous state
        if ( curState != null )
        {
            curState.OnExitState( );
        }

        //Update the previous state
        prevState = curState;

        //Update the current state
        curState = states[stateType];

        //Init the current state
        curState.OnEnterState( );
    }

    #endregion
}