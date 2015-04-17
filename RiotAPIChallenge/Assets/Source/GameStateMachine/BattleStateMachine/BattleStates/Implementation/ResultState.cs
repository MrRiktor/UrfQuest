#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: CombatState.cs
 * Date Created: 4/12/2015 8:28PM EST
 * 
 * Description: The Result state occurs when either team is completely dead.  
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/14/2015 8:52 PM
 *              - Modified: Matthew "Riktor" Baker - 4/16/2015 9:07 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;

#endregion

public class ResultState : BattleState
{
    #region Constructor

    /// <summary>
    /// Default Constructor - sets this states BattleStateType.
    /// </summary>
    public ResultState()
    {
        this.StateType = BattleStateType.ResultState;
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Overrides BattleState's OnExit() - Occurs when the state is exited.
    /// </summary>
    public override void OnExit()
    {
        base.OnExit();
    }

    /// <summary>
    /// Overrides BattleState's OnEnter() - Occurs when the state is entered.
    /// </summary>
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

    #endregion
}
