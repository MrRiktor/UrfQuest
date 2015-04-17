#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: Being.cs
 * Date Created: 4/9/2015 6:41PM EST
 * 
 * Description: The abstract base class that we derive Enemy and PartyMember from.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/15/2015 10:47 AM
 *              - Modified: Matthew "Riktor" Baker - 4/16/2015 6:46 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;
using System.Xml.Serialization;

#endregion

public abstract class Being : IPartyMember
{
    #region Public Enum

    /// <summary>
    /// The type of unit this is.
    /// </summary>
    public enum BeingType
    {
        None,
        Player,
        Enemy,
    };

    #endregion

    #region Private Member Variables

    /// <summary>
    /// The name of the unit. (Ex. Teemo)
    /// </summary>
    private String beingName;
    
    /// <summary>
    /// The calculated attack damage derived from BattleStatCalculator
    /// </summary>
    private long attackDamage;
    
    /// <summary>
    /// The currentHealth of this unit.
    /// </summary>
    private long currentHealth;
    
    /// <summary>
    /// The calculated health pool derived from BattleStatCalculator
    /// </summary>
    private long healthPool;
    
    /// <summary>
    /// The base movement speed of the unit, this drives initiative in combat.
    /// </summary>
    private long movementSpeed;
    
    /// <summary>
    /// The actual sprite that represents the icon of our unit.
    /// </summary>
    private UnityEngine.Sprite icon;
    
    /// <summary>
    /// The actual sprite that represents the portrait of our unit.
    /// </summary>
    private UnityEngine.Sprite portrait;
    
    /// <summary>
    /// The actual AudioClip that is played when our unit attacks.
    /// </summary>
    private UnityEngine.AudioClip attackClip;

    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// 
    /// </summary>
    [XmlAttribute]
    public String BeingName
    {
        get 
        {
            return beingName;
        }
        set 
        {
            beingName = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public long AttackDamage
    {
        get
        {
            return attackDamage;
        }
        set
        {
            attackDamage = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public long HealthPool
    {
        get
        {
            return healthPool;
        }
        set
        {
            healthPool = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public long MovementSpeed
    {
        get
        {
            return movementSpeed;
        }
        set
        {
            movementSpeed = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public UnityEngine.Sprite Icon
    {
        get
        {
            return icon;
        }
        set { icon = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public UnityEngine.Sprite Portrait
    {
        get
        {
            return portrait;
        }
        set { portrait = value; }
    }

    public UnityEngine.AudioClip AttackClip
    {
        get
        {
            return this.attackClip;
        }
        set
        {
            this.attackClip = value;
        }
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Default Constructor
    /// </summary>
    public Being()
    {

    }
    
    /// <summary>
    /// Constructor for PartyMembers
    /// </summary>
    /// <param name="participant"> The data class derived from the Riot API Participant. </param>
    public Being( Participant participant )
    {
        Champion champion = ChampionDBManager.GetInstance().ChampionDB.GetChampionByID(participant.ChampionId);

        beingName = champion.Name;
        attackDamage = (long)BattleStatCalculator.DamageCalculation(participant.Stats.TotalDamageDealtToChampions,
                                                                participant.Stats.Kills,
                                                                participant.Stats.Assists);
        healthPool = (long)BattleStatCalculator.HealthCalculation( participant.Stats.TotalDamageTaken, participant.Stats.Deaths );
        movementSpeed = (long)champion.Stats.Movespeed;
        
        icon = champion.Image.Icon;

        portrait = champion.Image.Portrait;

        attackClip = champion.AttackClip;
    }

    #endregion
}
