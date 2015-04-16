using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IBattleState
{
    void OnExit();

    void OnEnter();

    void Update();

    BattleState.BattleStateType StateType
    {
        get;
        set;
    }
}
