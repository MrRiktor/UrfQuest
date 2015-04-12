using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Xml.Serialization;

public abstract class Being : IPartyMember
{
    #region Private Member Variables

    private String beingName;
    private long attackDamage;
    private long healthPool;
    private long movementSpeed;

    private UnityEngine.Sprite icon;
    private UnityEngine.Sprite portrait;

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

    #endregion

    public Being()
    {

    }
    
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
    }    
}
