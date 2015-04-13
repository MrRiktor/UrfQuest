using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BattleStateMachine
{
    private IBattleState currentState;

    Dictionary<BattleStateTransition, IBattleState> transitions = new Dictionary<BattleStateTransition, IBattleState>();

    /// <summary>
    /// 
    /// </summary>
    private void InitializeTransitions()
    {        
        transitions.Add(new BattleStateTransition(BattleState.BattleStateType.InitBattleState, BattleState.BattleStateType.CombatState), new CombatState());
        transitions.Add(new BattleStateTransition(BattleState.BattleStateType.CombatState, BattleState.BattleStateType.ResolveCombatState), new ResolveCombatState());
        transitions.Add(new BattleStateTransition(BattleState.BattleStateType.ResolveCombatState, BattleState.BattleStateType.CombatState), new CombatState());
        transitions.Add(new BattleStateTransition(BattleState.BattleStateType.ResolveCombatState, BattleState.BattleStateType.ResultState), new ResultState());
    }

    public BattleStateMachine( IBattleState startingState )
    {
        currentState = startingState;
        InitializeTransitions();
    }

    public IBattleState ValidateStateTransition( BattleState.BattleStateType nextBattleState)
    {
        IBattleState nextState = null;
        
        BattleStateTransition transition = new BattleStateTransition( currentState.StateType, nextBattleState );
        if(!transitions.TryGetValue( transition, out nextState ))
        {
            UnityEngine.Debug.LogError("Invalid Transition");
        }

        return nextState;
    }

    public IBattleState GetNextState(BattleState.BattleStateType nextState)
    {
        return ValidateStateTransition(nextState);
    }

    public void TransitionToState(BattleState.BattleStateType nextState)
    {       
        IBattleState battleState = GetNextState(nextState);

        currentState.OnExit();

        currentState = battleState;

        currentState.OnEnter();
    }

    public IBattleState CurrentState 
    { 
        get
        {
            return currentState;
        }
    }
}