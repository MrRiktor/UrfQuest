using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ResultState : BattleState
{
    
    /// <summary>
    /// Default Constructor
    /// </summary>
    public ResultState()
    {
        this.StateType = BattleStateType.ResultState;
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnEnter()
    {
        base.OnEnter();

        if (BattleManager.GetInstance().winningTeam == BattleManager.Team.Enemy)
        {
            UnityEngine.Debug.Log("YOU LOSE!");
        }
        else if(BattleManager.GetInstance().winningTeam == BattleManager.Team.Player)
        {
            UnityEngine.Debug.Log("YOU WIN!");
        }
    } 
}
