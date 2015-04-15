using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CombatStatus
{
    public enum HealthStates
    {
        Alive,
        Dying,
        Dead,
    };

    /// <summary>
    /// The partyMembers current health.
    /// </summary>
    private float currentHealth = 1.0f;

    /// <summary>
    /// 
    /// </summary>
    private bool isAlive = true;

    /// <summary>
    /// 
    /// </summary>
    private Being.BeingType beingType = Being.BeingType.None;

    private HealthStates healthState = HealthStates.Alive;

    public CombatStatus()
    {

    }

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

    public bool IsAlive()
    {
        if (healthState == HealthStates.Alive || healthState == HealthStates.Dying)
            return true;
        else
            return false;
    }



    public Being.BeingType BeingType
    {
        get;
        set;
    }
}
