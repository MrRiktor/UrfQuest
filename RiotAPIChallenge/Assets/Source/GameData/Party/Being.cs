using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public abstract class Being
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

        //string key = champion.Key[]
        
        Texture2D texture = Resources.Load("Icons/champion/" + champion.Key) as Texture2D;

        if (texture != null)
        {
            icon = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 128f);
        }

        texture = Resources.Load("Images/champion/loading/" + champion.Key + "_0") as Texture2D;
        if (texture != null)
        {
            portrait = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 128f); ;
        }
    }
    
    /*public Being( Enemy enemy )
    {

    }*/
}
