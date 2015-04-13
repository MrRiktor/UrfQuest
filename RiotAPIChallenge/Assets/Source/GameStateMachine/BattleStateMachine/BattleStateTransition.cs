using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BattleStateTransition
{
    private readonly BattleState.BattleStateType currentState;
    private readonly BattleState.BattleStateType nextState;

    public BattleStateTransition(BattleState.BattleStateType currentState, BattleState.BattleStateType nextState)
    {
        this.currentState = currentState;
        this.nextState = nextState;
    }

    public override int GetHashCode()
    {
        return 17 + 31 * currentState.GetHashCode() + 31 * nextState.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        BattleStateTransition other = obj as BattleStateTransition;
        return other != null && this.currentState == other.currentState && this.nextState == other.nextState;
    }
}


