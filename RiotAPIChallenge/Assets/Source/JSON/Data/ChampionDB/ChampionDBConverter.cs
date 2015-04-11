using System;
using System.Collections.Generic;
using JsonFx.Json;

public class ChampionDBConverter : JsonConverter
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="propToValueMap"></param>
    /// <returns></returns>
    public static ChampionDB DictionaryToChampionDB(Dictionary<String, Object> propToValueMap)
    {
        ChampionDB championDB = new ChampionDB();

        #region Type Property

        if (propToValueMap.ContainsKey(ChampionDB.PropertyNames.Type) && propToValueMap[ChampionDB.PropertyNames.Type] is string)
        {
            championDB.Type = (string)propToValueMap[ChampionDB.PropertyNames.Type];
        }

        #endregion

        #region Format Property

        if (propToValueMap.ContainsKey(ChampionDB.PropertyNames.Format) && propToValueMap[ChampionDB.PropertyNames.Format] is string)
        {
            championDB.Format = (string)propToValueMap[ChampionDB.PropertyNames.Format];
        }

        #endregion

        #region Version Property

        if (propToValueMap.ContainsKey(ChampionDB.PropertyNames.Version) && propToValueMap[ChampionDB.PropertyNames.Version] is string)
        {
            championDB.Version = (string)propToValueMap[ChampionDB.PropertyNames.Version];
        }

        #endregion        

        #region Keys Property

        if (propToValueMap.ContainsKey(ChampionDB.PropertyNames.Keys) && propToValueMap[ChampionDB.PropertyNames.Keys] is Dictionary<String, Object>)
        {
            Dictionary<String, Object> keyPropValueMap = (Dictionary<String, Object>)propToValueMap[ChampionDB.PropertyNames.Keys];
            
            foreach (KeyValuePair<String, Object> keyDict in keyPropValueMap)
            {
                championDB.Keys.Add(keyDict.Key, keyDict.Value as String);
            }
        }

        #endregion

        #region Data Property

        if (propToValueMap.ContainsKey(ChampionDB.PropertyNames.Data) && propToValueMap[ChampionDB.PropertyNames.Data] is Dictionary<String, Object>)
        {
            Dictionary<String, Object> championPropValueMap = (Dictionary<String, Object>)propToValueMap[ChampionDB.PropertyNames.Data];

            foreach (KeyValuePair<String,Object> championDict in championPropValueMap)
            {
                Champion champion = ChampionConverter.DictionaryToChampion(championDict.Value as Dictionary<String, Object>);
                
                championDB.Data.Add(championDict.Key, champion);
            }
        }

        #endregion



        return championDB;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matchDetail"></param>
    /// <returns></returns>
    public static Dictionary<String, Object> ChampionDBToDictionary(ChampionDB championDB)
    {
        if (championDB == null)
        {
            throw new ArgumentException("parameter championDB is required.");
        }

        Dictionary<String, Object> propToValueMap = new Dictionary<String, Object>();
                
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
        if (typeof(ChampionDB).Equals(t))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Converts a dictionary into a ChampionDB
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

        return DictionaryToChampionDB(value);
    }

    /// <summary>
    /// Converts a ChampionDB into a dictionary
    /// </summary>
    /// <param name="type">Optional - the type of the value parameter</param>
    /// <param name="value">Optional - the instance that is to be converted into a dictionary</param>
    /// <returns>A Dictionary containing the data contained in the value parameter</returns>
    public override Dictionary<String, Object> WriteJson(Type type, Object value)
    {
        ChampionDB championDB = (ChampionDB)value;
        return ChampionDBToDictionary(championDB);
    }

    #endregion
}
