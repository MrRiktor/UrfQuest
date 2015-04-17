#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: ChampionDB.cs
 * Date Created: 4/11/2015 8:28PM EST
 * 
 * Description: ChampionDB Data Class
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;
using System.Collections.Generic;

#endregion

public class ChampionDB
{
    #region Constant Property Names

    public static class PropertyNames
    {
        public static readonly String Type = "type";
        public static readonly String Format = "format";
        public static readonly String Version = "version";
        public static readonly String Data = "data";
        public static readonly String Keys = "keys";
    }

    #endregion

    #region Private Member Variables

    /// <summary>
    /// 
    /// </summary>
    private string type;

    /// <summary>
    /// 
    /// </summary>
    private string format;

    /// <summary>
    /// 
    /// </summary>
    private string version;

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<String, Champion> data = new Dictionary<string,Champion>();

    /// <summary>
    /// 
    /// </summary>
    private Dictionary<String, String> keys = new Dictionary<string,string>();

    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// 
    /// </summary>
    public string Type
    {
        get 
        {
            return type;
        }
        set
        {
            type = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string Format
    {
        get
        {
            return format;
        }
        set
        {
            format = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string Version
    {
        get
        {
            return version;
        }
        set
        {
            version = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Dictionary<String,Champion> Data
    {
        get
        {
            return data;
        }
        set
        {
            data = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public Dictionary<String, String> Keys
    {
        get
        {
            return keys;
        }
        set
        {
            keys = value;
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ChampionID"></param>
    /// <returns></returns>
    public String GetChampionNameByID( long ChampionID )
    {
        return this.Keys[ChampionID.ToString()];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ChampionID"></param>
    /// <returns></returns>
    public Champion GetChampionByID( long ChampionID )
    {
        if (this.keys.ContainsKey(ChampionID.ToString()))
        {
            return this.Data[this.Keys[ChampionID.ToString()]];
        }
        else
        {
            throw new IndexOutOfRangeException(ChampionID + " is not a valid ChampionID.");
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="rawResponse"></param>
    /// <returns></returns>
    public static ChampionDB fromJSON( object rawResponse )
    {
        if ( rawResponse is String )
        {
            String json = (String)rawResponse;
            JsonFx.Json.JsonReader reader = JSONUtils.getJsonReader(json);

            ChampionDB championDB = new ChampionDB();
            championDB = reader.Deserialize<ChampionDB>();

            return championDB;
        }

        return new ChampionDB();
    }

    #endregion
}
