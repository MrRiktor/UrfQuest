#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: BattleStateTransition.cs
 * Date Created: 4/12/2015 5:02PM EST
 * 
 * Description: The state transition data class.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/12/2015 10:01 PM
 *              - Modified: Matthew "Riktor" Baker - 4/16/2015 9:27 PM - Added Comments
 *******************************************************************************/

#endregion

public class BattleStateTransition
{
    #region Private Variables

    /// <summary>
    /// The current state.
    /// </summary>
    private readonly BattleState.BattleStateType currentState;
    
    /// <summary>
    /// The next state.
    /// </summary>
    private readonly BattleState.BattleStateType nextState;

    #endregion

    #region Constructor

    /// <summary>
    /// Default constructor
    /// </summary>
    /// <param name="currentState"> the original state. </param>
    /// <param name="nextState"> the destination state. </param>
    public BattleStateTransition(BattleState.BattleStateType currentState, BattleState.BattleStateType nextState)
    {
        this.currentState = currentState;
        this.nextState = nextState;
    }

    #endregion  

    #region Public Methods

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return 17 + 31 * currentState.GetHashCode() + 31 * nextState.GetHashCode();
    }

    /// <summary>
    /// Overrides the Equals operator so that we can compare our custom types to one another.
    /// </summary>
    /// <param name="obj"> the object to compare.</param>
    /// <returns> True if objects are the same, false if they are not. </returns>
    public override bool Equals(object obj)
    {
        BattleStateTransition other = obj as BattleStateTransition;
        return other != null && this.currentState == other.currentState && this.nextState == other.nextState;
    }

    #endregion
}


