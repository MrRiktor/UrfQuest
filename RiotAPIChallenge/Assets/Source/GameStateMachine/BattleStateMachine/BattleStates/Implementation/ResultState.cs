using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

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

        if (BattleManager.GetInstance().WinningTeam == BattleManager.Team.Enemy)
        {
            GameObject defeatScreen = GameObject.Instantiate(BattleManager.GetInstance().DefeatPrefab);

            defeatScreen.transform.parent = BattleManager.GetInstance().transform;

            defeatScreen.transform.localPosition = Vector3.zero;
            defeatScreen.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

            ++GameData.Strikes;
        }
        else if(BattleManager.GetInstance().WinningTeam == BattleManager.Team.Player)
        {
            GameObject victoryScreen = GameObject.Instantiate(BattleManager.GetInstance().VictoryPrefab);

            victoryScreen.transform.parent = BattleManager.GetInstance().transform;

            victoryScreen.transform.localPosition = Vector3.zero;
            victoryScreen.transform.localScale = new Vector3(1.0f,1.0f,1.0f);

            ++GameData.CurrentLevel;
        }
    } 
}
