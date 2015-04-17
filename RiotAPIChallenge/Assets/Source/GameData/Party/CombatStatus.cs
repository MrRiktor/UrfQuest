#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: CombatStatus.cs
 * Date Created: 4/14/2015 7:02PM EST
 * 
 * Description: This holds combat stats and status for the PartyMember.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/15/2015 10:43 AM
 *              - Modified: Matthew "Riktor" Baker - 4/16/2015 8:06 PM - Added Comments
 *******************************************************************************/

#endregion

public class CombatStatus
{
    #region Public Enumerations

    /// <summary>
    /// The health status of the Party Member.
    /// </summary>
    public enum HealthStates
    {
        Alive,
        Dying,
        Dead,
    };

    #endregion

    #region Private Member Variables

    /// <summary>
    /// The partyMembers current health.
    /// </summary>
    private float currentHealth = 1.0f;

    /// <summary>
    /// Boolean representing whether the target is alive or not.
    /// </summary>
    private bool isAlive = true;

    /// <summary>
    /// The BeingType of the PartyMember.
    /// </summary>
    private Being.BeingType beingType = Being.BeingType.None;

    /// <summary>
    /// The HealthState of the PartyMember.
    /// </summary>
    private HealthStates healthState = HealthStates.Alive;

    #endregion

    #region Constructors

    /// <summary>
    /// Default Constructor
    /// </summary>
    public CombatStatus()
    {

    }

    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// Accessor/Modifier for the current health. 
    /// 
    /// Note: If the currentHealth is below 0 this will return 0.
    /// </summary>
    public float CurrentHealth
    {
        get
        {
            return this.currentHealth;
        }
        set
        {
            this.currentHealth = value;

            if( currentHealth <= 0 )
            {
                this.healthState = HealthStates.Dying;
            }
        }
    }

    /// <summary>
    /// Accessor/Modifier for the health state.
    /// </summary>
    public HealthStates HealthState
    {
        get
        {
            return this.healthState;
        }
        set
        {
            this.healthState = value;
        }
    }
    
    /// <summary>
    /// Accessor/Modifier for the being type.
    /// </summary>
    public Being.BeingType BeingType
    {
        get
        {
            return this.beingType;
        }
        set
        {
            this.beingType = value;
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Checks the status of the isAlive boolean.
    /// </summary>
    public bool IsAlive()
    {
        if (healthState == HealthStates.Alive || healthState == HealthStates.Dying)
            return true;
        else
            return false;
    }

    #endregion

}
