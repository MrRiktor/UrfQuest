#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: BattleState.cs
 * Date Created: 4/12/2015 8:28PM EST
 * 
 * Description: The abstract base BattleState class.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/12/2015 10:29 PM
 *              - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

public abstract class BattleState : IBattleState
{
    #region Public Enumerations

    public enum BattleStateType
    {
        InitBattleState,
        CombatState,
        ResolveCombatState,
        ResultState,
    };

    #endregion

    #region Private Variables

    /// <summary>
    /// The battlestatetype that of each class that inherits from battle state.
    /// </summary>
    private BattleStateType stateType;

    #endregion

    #region Constructor

    /// <summary>
    /// Default Constructor
    /// </summary>
    public BattleState()
    {        
    }

    #endregion

    #region IBattleState Methods

    /// <summary>
    /// Occurs when the state is entered.
    /// </summary>
    public virtual void OnEnter()
    {

    }

    /// <summary>
    /// Occurs when the state is left.
    /// </summary>
    public virtual void OnExit()
    {

    }

    /// <summary>
    /// Occurs everytime an update is called. (Once per frame in this instance)
    /// </summary>
    public virtual void Update()
    {

    }

    /// <summary>
    /// The battle state type of the state. Used in battle state transitions.
    /// </summary>
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

    #endregion
}

