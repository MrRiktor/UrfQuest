using System;
using System.Collections;
using System.Collections.Generic;

public class Party
{
    #region Private Member Variables

    List<PartyMember> partyMembers = new List<PartyMember>();

    private long teamTotalAttack;
    private long teamTotalHealth;
    private long teamTotalMovementSpeed;
    
    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// 
    /// </summary>
    public List<PartyMember> PartyMembers
    {
        get
        {
            return partyMembers;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public long AttackAverage
    {
        get
        {
            return (this.teamTotalAttack / partyMembers.Count);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public long HealthAverage
    {
        get
        {
            return (this.teamTotalHealth / partyMembers.Count);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public long MovementSpeedAverage
    {
        get
        {
            return (this.teamTotalMovementSpeed / partyMembers.Count);
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="partyMember"></param>
    public void AddPartyMember( PartyMember partyMember )
    {
        partyMembers.Add(partyMember);

        teamTotalAttack += partyMember.AttackDamage;
        teamTotalHealth += partyMember.HealthPool;
        teamTotalMovementSpeed += partyMember.MovementSpeed;
    }

    #endregion
}

