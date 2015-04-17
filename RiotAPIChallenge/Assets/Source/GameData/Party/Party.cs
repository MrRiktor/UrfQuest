#region File Header

/*******************************************************************************
 * Author: Vincent "Sabin" Biancardi
 * Filename: Party.cs
 * Date Created: 4/9/2015 6:41PM EST
 * 
 * Description: The data class representing the a Party
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 8:29 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System.Collections.Generic;
using System.Collections.ObjectModel;

#endregion

public class Party
{
    #region Private Member Variables

    /// <summary>
    /// 
    /// </summary>
    List<PartyMember> partyMembers = new List<PartyMember>();

    /// <summary>
    /// The Match ID of this party.
    /// </summary>
    private long matchID;

    /// <summary>
    /// The total attack of the team.
    /// </summary>
    private long teamTotalAttack;

    /// <summary>
    /// the total health pool of the team.
    /// </summary>
    private long teamTotalHealth;

    /// <summary>
    /// the total movement speed of the team.
    /// </summary>
    private long teamTotalMovementSpeed;
    
    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// The Party Members in the party.
    /// </summary>
    public ReadOnlyCollection<PartyMember> PartyMembers
    {
        get
        {
            return partyMembers.AsReadOnly();
        }
    }

    /// <summary>
    /// the average attack of the party.
    /// </summary>
    public long AttackAverage
    {
        get
        {
            return (this.teamTotalAttack / partyMembers.Count);
        }
    }

    /// <summary>
    /// The average health pool of the party.
    /// </summary>
    public long HealthAverage
    {
        get
        {
            return (this.teamTotalHealth / partyMembers.Count);
        }
    }

    /// <summary>
    /// The match ID of the party
    /// </summary>
    public long MatchID
    {
        get
        {
            return matchID;
        }
        set
        {
            matchID = value;
        }
    }

    /// <summary>
    /// The average movement speed of the party.
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
    /// Adds a party member to the party.
    /// </summary>
    /// <param name="partyMember"> the party member to add. </param>
    public void AddPartyMember( PartyMember partyMember )
    {
        partyMembers.Add(partyMember);

        teamTotalAttack += partyMember.AttackDamage;
        teamTotalHealth += partyMember.HealthPool;
        teamTotalMovementSpeed += partyMember.MovementSpeed;
    }

    #endregion
}

