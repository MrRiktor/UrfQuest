#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: ChampionStatsConverter.cs
 * Date Created: 4/11/2015 8:28PM EST
 * 
 * Description: Converter for Champion Stats Data Class
 * 
 * Changelog: - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;
using System.Collections.Generic;
using JsonFx.Json;

#endregion

public class ChampionStatsConverter : JsonConverter
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="propToValueMap"></param>
    /// <returns></returns>
    public static ChampionStats DictionaryToChampionStats(Dictionary<String, Object> propToValueMap)
    {
        ChampionStats championStats = new ChampionStats();

        #region Armor Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Armor) && propToValueMap[ChampionStats.PropertyNames.Armor] is double)
        {
            championStats.Armor = (double)propToValueMap[ChampionStats.PropertyNames.Armor];
        }

        #endregion

        #region Armorperlevel Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Armorperlevel) && propToValueMap[ChampionStats.PropertyNames.Armorperlevel] is double)
        {
            championStats.Armorperlevel = (double)propToValueMap[ChampionStats.PropertyNames.Armorperlevel];
        }

        #endregion

        #region Attackdamage Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Attackdamage) && propToValueMap[ChampionStats.PropertyNames.Attackdamage] is double)
        {
            championStats.Attackdamage = (double)propToValueMap[ChampionStats.PropertyNames.Attackdamage];
        }

        #endregion

        #region Attackdamageperlevel Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Attackdamageperlevel) && propToValueMap[ChampionStats.PropertyNames.Attackdamageperlevel] is double)
        {
            championStats.Attackdamageperlevel = (double)propToValueMap[ChampionStats.PropertyNames.Attackdamageperlevel];
        }

        #endregion

        #region Attackrange Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Attackrange) && propToValueMap[ChampionStats.PropertyNames.Attackrange] is double)
        {
            championStats.Attackrange = (double)propToValueMap[ChampionStats.PropertyNames.Attackrange];
        }

        #endregion

        #region Attackspeedoffset Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Attackspeedoffset) && propToValueMap[ChampionStats.PropertyNames.Attackspeedoffset] is double)
        {
            championStats.Attackspeedoffset = (double)propToValueMap[ChampionStats.PropertyNames.Attackspeedoffset];
        }

        #endregion

        #region Attackspeedperlevel Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Attackspeedperlevel) && propToValueMap[ChampionStats.PropertyNames.Attackspeedperlevel] is double)
        {
            championStats.Attackspeedperlevel = (double)propToValueMap[ChampionStats.PropertyNames.Attackspeedperlevel];
        }

        #endregion

        #region Crit Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Crit) && propToValueMap[ChampionStats.PropertyNames.Crit] is double)
        {
            championStats.Crit = (double)propToValueMap[ChampionStats.PropertyNames.Crit];
        }

        #endregion

        #region Critperlevel Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Critperlevel) && propToValueMap[ChampionStats.PropertyNames.Critperlevel] is double)
        {
            championStats.Critperlevel = (double)propToValueMap[ChampionStats.PropertyNames.Critperlevel];
        }

        #endregion

        #region Hp Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Hp) && propToValueMap[ChampionStats.PropertyNames.Hp] is double)
        {
            championStats.Hp = (double)propToValueMap[ChampionStats.PropertyNames.Hp];
        }

        #endregion

        #region Hpperlevel Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Hpperlevel) && propToValueMap[ChampionStats.PropertyNames.Hpperlevel] is double)
        {
            championStats.Hpperlevel = (double)propToValueMap[ChampionStats.PropertyNames.Hpperlevel];
        }

        #endregion

        #region Hpregen Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Hpregen) && propToValueMap[ChampionStats.PropertyNames.Hpregen] is double)
        {
            championStats.Hpregen = (double)propToValueMap[ChampionStats.PropertyNames.Hpregen];
        }

        #endregion

        #region Hpregenperlevel Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Hpregenperlevel) && propToValueMap[ChampionStats.PropertyNames.Hpregenperlevel] is double)
        {
            championStats.Hpregenperlevel = (double)propToValueMap[ChampionStats.PropertyNames.Hpregenperlevel];
        }

        #endregion

        #region Movespeed Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Movespeed) && propToValueMap[ChampionStats.PropertyNames.Movespeed] is double)
        {
            championStats.Movespeed = (double)propToValueMap[ChampionStats.PropertyNames.Movespeed];
        }

        #endregion

        #region Mp Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Mp) && propToValueMap[ChampionStats.PropertyNames.Mp] is double)
        {
            championStats.Mp = (double)propToValueMap[ChampionStats.PropertyNames.Mp];
        }

        #endregion

        #region Mpperlevel Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Mpperlevel) && propToValueMap[ChampionStats.PropertyNames.Mpperlevel] is double)
        {
            championStats.Mpperlevel = (double)propToValueMap[ChampionStats.PropertyNames.Mpperlevel];
        }

        #endregion

        #region Mpregen Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Mpregen) && propToValueMap[ChampionStats.PropertyNames.Mpregen] is double)
        {
            championStats.Mpregen = (double)propToValueMap[ChampionStats.PropertyNames.Mpregen];
        }

        #endregion

        #region Mpregenperlevel Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Mpregenperlevel) && propToValueMap[ChampionStats.PropertyNames.Mpregenperlevel] is double)
        {
            championStats.Mpregenperlevel = (double)propToValueMap[ChampionStats.PropertyNames.Mpregenperlevel];
        }

        #endregion

        #region Spellblock Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Spellblock) && propToValueMap[ChampionStats.PropertyNames.Spellblock] is double)
        {
            championStats.Spellblock = (double)propToValueMap[ChampionStats.PropertyNames.Spellblock];
        }

        #endregion

        #region Spellblockperlevel Property

        if (propToValueMap.ContainsKey(ChampionStats.PropertyNames.Spellblockperlevel) && propToValueMap[ChampionStats.PropertyNames.Spellblockperlevel] is double)
        {
            championStats.Spellblockperlevel = (double)propToValueMap[ChampionStats.PropertyNames.Spellblockperlevel];
        }

        #endregion

        return championStats;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matchDetail"></param>
    /// <returns></returns>
    public static Dictionary<String, Object> ChampionStatsToDictionary(ChampionStats championStats)
    {
        if ( championStats == null)
        {
            throw new ArgumentException("parameter champion is required.");
        }

        Dictionary<String, Object> propToValueMap = new Dictionary<String, Object>();

        #region Armor Property

        propToValueMap.Add(ChampionStats.PropertyNames.Armor, championStats.Armor);

        #endregion

        return propToValueMap;
    }

    #region Json Converter Inherited Methods

    /// <summary>
    /// Tests to see if the current type can be converted by this converter class
    /// </summary>
    /// <param name="t">Optional - the type to be tested</param>
    /// <returns>true if the type can be converted, false otherwise</returns>
    public override bool CanConvert(Type t)
    {
        if (typeof(ChampionStats).Equals(t))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Converts a dictionary into a ChampionStats
    /// </summary>
    /// <param name="type">Optional - the type of the value parameter</param>
    /// <param name="value">Optional - the dictionary that is to be converted into an instance</param>
    /// <returns>A MatchDetail instance if type and value are not null, null otherwise</returns>
    public override Object ReadJson(Type type, Dictionary<String, Object> value)
    {
        if (!CanConvert(type))
        {
            return null;
        }

        if ((type == null) || (value == null))
        {
            return null;
        }

        return DictionaryToChampionStats(value);
    }

    /// <summary>
    /// Converts a ChampionStats into a dictionary
    /// </summary>
    /// <param name="type">Optional - the type of the value parameter</param>
    /// <param name="value">Optional - the instance that is to be converted into a dictionary</param>
    /// <returns>A Dictionary containing the data contained in the value parameter</returns>
    public override Dictionary<String, Object> WriteJson(Type type, Object value)
    {
        ChampionStats championStats = (ChampionStats)value;
        return ChampionStatsToDictionary(championStats);
    }

    #endregion
}
