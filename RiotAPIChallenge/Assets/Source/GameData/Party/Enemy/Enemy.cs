using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

public class Enemy : Being
{
    #region Private Member Variables

    private int partyMemberId;
    private String iconPath;
    private String portraitPath;

    #endregion

    #region Accessors/Modifiers

    [XmlAttribute("id")]
    public int PartyMemberId
    {
        get
        {
            return this.partyMemberId;
        }
        set
        {
            this.partyMemberId = value;
        }
    }

    public String IconPath
    {
        get 
        {
            return this.iconPath;
        }
        set 
        {
            this.iconPath = value;

            if (this.Icon == null)
            {
                UnityEngine.Texture2D texture = UnityEngine.Resources.Load(iconPath) as UnityEngine.Texture2D;

                if (texture != null)
                {
                    this.Icon = UnityEngine.Sprite.Create(texture, new UnityEngine.Rect(0f, 0f, texture.width, texture.height), new UnityEngine.Vector2(0.5f, 0.5f), 128f);
                }
            }
        }
    }


    public String PortraitPath
    {
        get 
        { 
            return this.portraitPath; 
        }
        set 
        {
            this.portraitPath = value; 
         
            if(this.Portrait == null)
            {
                UnityEngine.Texture2D texture = UnityEngine.Resources.Load(portraitPath) as UnityEngine.Texture2D;
                
                if (texture != null)
                {
                    this.Portrait = UnityEngine.Sprite.Create(texture, new UnityEngine.Rect(0f, 0f, texture.width, texture.height), new UnityEngine.Vector2(0.5f, 0.5f), 128f); ;
                }
            }
        }
    }

    #endregion
    
    public Enemy()
    {

    }
    
   /* public Enemy( EnemyData enemyData )
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
    }    */
}
