#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: BattleStateMachine.cs
 * Date Created: 4/12/2015 4:58PM EST
 * 
 * Description: The state machine that drives our battle system.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System.Collections.Generic;

#endregion

public class BattleStateMachine
{
    #region Private Member Variables

    /// <summary>
    /// The current state of the state machine.
    /// </summary>
    private IBattleState currentState;

    /// <summary>
    /// The Dictionary of acceptable state transitions.
    /// </summary>
    private Dictionary<BattleStateTransition, IBattleState> transitions = new Dictionary<BattleStateTransition, IBattleState>();

    #endregion
    
    #region Accessors/Modifiers

    /// <summary>
    /// Accessor for the current state of the state machine.
    /// </summary>
    public IBattleState CurrentState
    {
        get
        {
            return currentState;
        }
    }

    #endregion
    
    #region Constructor

    /// <summary>
    /// Default Constructor
    /// </summary>
    /// <param name="startingState"> The starting state of the state machine. </param>
    public BattleStateMachine( IBattleState startingState )
    {
        currentState = startingState;
        InitializeTransitions();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// A call to transition to the nextState passed in.
    /// </summary>
    /// <param name="nextState"> the desired state to transition to. </param>
    public void TransitionToState(BattleState.BattleStateType nextState)
    {       
        IBattleState battleState = GetNextState(nextState);

        currentState.OnExit();

        currentState = battleState;

        currentState.OnEnter();
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Initializes the state transitions Dictionary.
    /// </summary>
    private void InitializeTransitions()
    {
        transitions.Add(new BattleStateTransition(BattleState.BattleStateType.InitBattleState, BattleState.BattleStateType.CombatState), new CombatState());
        transitions.Add(new BattleStateTransition(BattleState.BattleStateType.CombatState, BattleState.BattleStateType.ResolveCombatState), new ResolveCombatState());
        transitions.Add(new BattleStateTransition(BattleState.BattleStateType.ResolveCombatState, BattleState.BattleStateType.CombatState), new CombatState());
        transitions.Add(new BattleStateTransition(BattleState.BattleStateType.ResolveCombatState, BattleState.BattleStateType.ResultState), new ResultState());
    }
    
    /// <summary>
    /// Validates the transition from the current state to the nextBattleState passed in.
    /// </summary>
    /// <param name="nextBattleState"> The desired next battle state. </param>
    /// <returns> Returns the next state or null depending on the validity of the state transition requested. </returns>
    private IBattleState ValidateStateTransition( BattleState.BattleStateType nextBattleState)
    {
        IBattleState nextState = null;
        
        BattleStateTransition transition = new BattleStateTransition( currentState.StateType, nextBattleState );
        if(!transitions.TryGetValue( transition, out nextState ))
        {
            UnityEngine.Debug.LogError("Invalid Transition");
        }

        return nextState;
    }
    
    /// <summary>
    /// Requests a next state.
    /// </summary>
    /// <param name="nextState"> the next state we want. </param>
    /// <returns> returns a valid next state or null. </returns>
    private IBattleState GetNextState(BattleState.BattleStateType nextState)
    {
        return ValidateStateTransition(nextState);
    }

    #endregion
}