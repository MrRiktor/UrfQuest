/**********************************************************************************************
 * 
 * 
 * 
 * 
 * 
 * 
 * ********************************************************************************************/

public class CombatState : BattleState
{
    /// <summary>
    /// Default Constructor
    /// </summary>
    public CombatState()
    {
        this.StateType = BattleStateType.CombatState;
    }

    /// <summary>
    /// 
    /// </summary>
    public override void OnEnter()
    {
        BattleManager.GetInstance().ResetAttackQueue();

        base.OnEnter();
    } 

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void Update()
    {        
        base.Update();

        BattleManager.GetInstance().Fight();
    }
}
