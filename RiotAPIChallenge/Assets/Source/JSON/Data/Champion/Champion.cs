﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    private RiotImage image;
    //private Info info;
    private string key;
    private string lore;
    private string name;
    private string partype;
    //private Passive passive;
    //private Recommended[] recommended;
    //private Skins[] skins;
    //private ChampionSpells[] spells;
    private ChampionStats stats;
    private string[] tags;
    private string title;

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
            return image;
        }
        set
        {
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
