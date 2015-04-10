using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ChampionStats
{
    #region Constant Property Names

    public static class PropertyNames
    {
        public static readonly String Armor = "armor";
        public static readonly String Armorperlevel = "armorperlevel";
        public static readonly String Attackdamage = "attackdamage";
        public static readonly String Attackdamageperlevel = "attackdamageperlevel";
        public static readonly String Attackrange = "attackrange";
        public static readonly String Attackspeedoffset = "attackspeedoffset";
        public static readonly String Attackspeedperlevel = "attackspeedperlevel";
        public static readonly String Crit = "crit";
        public static readonly String Critperlevel = "critperlevel";
        public static readonly String Hp = "hp";
        public static readonly String Hpperlevel = "hpperlevel";
        public static readonly String Hpregen = "hpregen";
        public static readonly String Hpregenperlevel = "hpregenperlevel";
        public static readonly String Movespeed = "movespeed";
        public static readonly String Mp = "mp";
        public static readonly String Mpperlevel = "mpperlevel";
        public static readonly String Mpregen = "mpregen";
        public static readonly String Mpregenperlevel = "mpregenperlevel";
        public static readonly String Spellblock = "spellblock";
        public static readonly String Spellblockperlevel = "spellblockperlevel";
    }

    #endregion

    #region Private Member Variables

    private double armor;
    private double armorperlevel;
    private double attackdamage;
    private double attackdamageperlevel;
    private double attackrange;
    private double attackspeedoffset;
    private double attackspeedperlevel;
    private double crit;
    private double critperlevel;	
    private double hp;	
    private double hpperlevel;
    private double hpregen;
    private double hpregenperlevel;
    private double movespeed;
    private double mp;
    private double mpperlevel;
    private double mpregen;
    private double mpregenperlevel;
    private double spellblock;
    private double spellblockperlevel;

    #endregion

    #region Accessors/Modifiers

    public double Armor 
    {
        get 
        {
            return armor;
        }
        set
        {
            armor = value;
        }
    }
    public double Armorperlevel
    {
        get
        {
            return armorperlevel;
        }
        set
        {
            armorperlevel = value;
        }
    }
    public double Attackdamage
    {
        get
        {
            return attackdamage;
        }
        set
        {
            attackdamage = value;
        }
    }
    public double Attackdamageperlevel
    {
        get
        {
            return attackdamageperlevel;
        }
        set
        {
            attackdamageperlevel = value;
        }
    }
    public double Attackrange
    {
        get
        {
            return attackrange;
        }
        set
        {
            attackrange = value;
        }
    }
    public double Attackspeedoffset
    {
        get
        {
            return attackspeedoffset;
        }
        set
        {
            attackspeedoffset = value;
        }
    }
    public double Attackspeedperlevel
    {
        get
        {
            return attackspeedperlevel;
        }
        set
        {
            attackspeedperlevel = value;
        }
    }
    public double Crit
    {
        get
        {
            return crit;
        }
        set
        {
            crit = value;
        }
    }
    public double Critperlevel
    {
        get
        {
            return critperlevel;
        }
        set
        {
            critperlevel = value;
        }
    }
    public double Hp
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }
    public double Hpperlevel
    {
        get
        {
            return hpperlevel;
        }
        set
        {
            hpperlevel = value;
        }
    }
    public double Hpregen
    {
        get
        {
            return hpregen;
        }
        set
        {
            hpregen = value;
        }
    }
    public double Hpregenperlevel
    {
        get
        {
            return hpregenperlevel;
        }
        set
        {
            hpregenperlevel = value;
        }
    }
    public double Movespeed
    {
        get
        {
            return movespeed;
        }
        set
        {
            movespeed = value;
        }
    }
    public double Mp
    {
        get
        {
            return mp;
        }
        set
        {
            mp = value;
        }
    }
    public double Mpperlevel
    {
        get
        {
            return mpperlevel;
        }
        set
        {
            mpperlevel = value;
        }
    }
    public double Mpregen
    {
        get
        {
            return mpregen;
        }
        set
        {
            mpregen = value;
        }
    }
    public double Mpregenperlevel
    {
        get
        {
            return mpregenperlevel;
        }
        set
        {
            mpregenperlevel = value;
        }
    }
    public double Spellblock
    {
        get
        {
            return spellblock;
        }
        set
        {
            spellblock = value;
        }
    }
    public double Spellblockperlevel
    {
        get
        {
            return spellblockperlevel;
        }
        set
        {
            spellblockperlevel = value;
        }
    }

    #endregion

    public static ChampionStats fromJSON(object rawResponse)
    {
        if (rawResponse is String)
        {
            String json = (String)rawResponse;
            JsonFx.Json.JsonReader reader = JSONUtils.getJsonReader(json);

            ChampionStats championStats = new ChampionStats();
            championStats = reader.Deserialize<ChampionStats>();

            return championStats;
        }

        return new ChampionStats();
    }
}

