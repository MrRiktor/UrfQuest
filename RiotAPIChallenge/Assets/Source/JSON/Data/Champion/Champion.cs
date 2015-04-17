#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: Champion.cs
 * Date Created: 4/11/2015 8:28PM EST
 * 
 * Description: Champion Data Class
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

#region ChampData Public Enumerator

public enum ChampData
{
    minimal,
    all,
    allytips,
    altimages,
    blurb,
    enemytips,
    image,
    info,
    lore,
    partype,
    passive,
    recommended,
    skins,
    spells,
    stats,
    tags,
};

#endregion

public class Champion
{
    #region Constant Property Names

    public static class PropertyNames
    {
        public static readonly String Allytips = "allytips";
        public static readonly String Blurb = "blurb";
        public static readonly String Enemytips = "enemytips";
        public static readonly String Id = "id";
        public static readonly String Image = "image";
        public static readonly String Info = "info";
        public static readonly String Key = "key";
        public static readonly String Lore = "lore";
        public static readonly String Name = "name";
        public static readonly String Partype = "partype";
        public static readonly String Passive = "passive";
        public static readonly String Recommended = "recommended";
        public static readonly String Skins = "skins";
        public static readonly String Spells = "spells";
        public static readonly String Stats = "stats";
        public static readonly String Tags = "tags";
        public static readonly String Title = "title";
    }

    #endregion

    #region Private Member Variables

    private string[] allytips;
    private string blurb;
    private string[] enemytips;
    private int id;
    private RiotImage image = new RiotImage();
    //private Info info;
    private string key;
    private string lore;
    private string name;
    private string partype;
    //private Passive passive;
    //private Recommended[] recommended;
    //private Skins[] skins;
    //private ChampionSpells[] spells;
    private ChampionStats stats = new ChampionStats();
    private string[] tags;
    private string title;

    private UnityEngine.AudioClip attackClip;
    private UnityEngine.AudioClip intro;

    #endregion

    #region Accessors/Modifiers

    public string[] Allytips
    {
        get
        {
            return allytips;
        }
        set
        {
            allytips = value;
        }
    }

    public string Blurb
    {
        get
        {
            return blurb;
        }
        set
        {
            blurb = value;
        }
    }

    public string[] Enemytips
    {
        get
        {
            return enemytips;
        }
        set
        {
            enemytips = value;
        }
    }

    public int Id
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    public RiotImage Image
    {
        get
        {
            if (this.image == null)
            {
                this.image = new RiotImage();
            }
            return image;
        }
        set
        {
            if( this.image == null )
            {
                this.image = new RiotImage();
            }
            image = value;
        }
    }

    /*public Info info
    {
        get
        {
            return info;
        }
        set
        {
            info = value;
        }
    }*/
    
    /// <summary>
    /// The string used to get the champion images and index champion stats in the champion DB.
    /// Important Note: Wukong's key is "Monkeyking" as well as other champions with spaces in their 
    /// names will have a no space name.
    /// </summary>
    public string Key
    {
        get
        {
            return key;
        }
        set
        {
            key = value;
        }
    }

    public string Lore
    {
        get
        {
            return lore;
        }
        set
        {
            lore = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public string Partype
    {
        get
        {
            return partype;
        }
        set
        {
            partype = value;
        }
    }

    /*public Passive Passive
    {
        get
        {
            return passive;
        }
        set
        {
            passive = value;
        }
    }*/

    /*public Recommended[] Recommended
    {
        get
        {
            return recommended;
        }
        set
        {
            recommended = value;
        }
    }*/

    /*public Skins[] Skins
    {
        get
        {
            return skins;
        }
        set
        {
            skins = value;
        }
    }*/

    /*public ChampionSpells[] Spells
    {
        get
        {
            return spells;
        }
        set
        {
            spells = value;
        }
    }*/

    public ChampionStats Stats
    {
        get
        {
            return stats;
        }
        set
        {
            stats = value;
        }
    }

    public string[] Tags
    {
        get
        {
            return tags;
        }
        set
        {
            tags = value;
        }
    }

    public string Title
    {
        get
        {
            return title;
        }
        set
        {
            title = value;
        }
    }

    public UnityEngine.AudioClip Intro
    {
        get 
        { 
            return intro; 
        }
    }

    public UnityEngine.AudioClip AttackClip
    {
        get 
        { 
            if(attackClip == null)
            {
                System.Collections.Generic.List<string> tagsList = new System.Collections.Generic.List<string>(this.tags);

                 this.attackClip = UnityEngine.Resources.Load<UnityEngine.AudioClip>("Sound/Attack");                
            }

            return this.attackClip;
        }
    }

    #endregion

    public static Champion fromJSON( object rawResponse )
    {
        if ( rawResponse is String )
        {
            String json = (String)rawResponse;
            JsonFx.Json.JsonReader reader = JSONUtils.getJsonReader(json);

            Champion champion = new Champion();
            champion = reader.Deserialize<Champion>();

            return champion;
        }

        return new Champion();
    }
}

