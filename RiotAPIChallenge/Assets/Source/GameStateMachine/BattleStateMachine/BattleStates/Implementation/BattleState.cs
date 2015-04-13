using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class BattleState : IBattleState
{
    public enum BattleStateType
    {
        InitBattleState,
        CombatState,
        ResolveCombatState,
        ResultState,
    };

    private BattleStateType stateType;

    public BattleState()
    {        
    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnExit()
    {

    }

    public virtual void Update()
    {

    }

    public BattleState.BattleStateType StateType
    {
        get
        {
            return this.stateType;
        }
        set 
        {
            this.stateType = value;
        }
    }
}

