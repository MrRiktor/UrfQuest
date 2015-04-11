using System;
using System.Collections.Generic;
using JsonFx.Json;

public class ChampionConverter : JsonConverter
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="propToValueMap"></param>
    /// <returns></returns>
    public static Champion DictionaryToChampion(Dictionary<String, Object> propToValueMap)
    {
        Champion champion = new Champion();

        #region Allytips Property

        if ( propToValueMap.ContainsKey(Champion.PropertyNames.Allytips) && propToValueMap[Champion.PropertyNames.Allytips] is string[])
        {
            champion.Allytips = (string[])propToValueMap[Champion.PropertyNames.Allytips];
        }

        #endregion

        #region Blurb Property

        if (propToValueMap.ContainsKey(Champion.PropertyNames.Blurb) && propToValueMap[Champion.PropertyNames.Blurb] is string)
        {
            champion.Blurb = (string)propToValueMap[Champion.PropertyNames.Blurb];
        }

        #endregion

        #region Enemytips Property

        if (propToValueMap.ContainsKey(Champion.PropertyNames.Enemytips) && propToValueMap[Champion.PropertyNames.Enemytips] is string[])
        {
            champion.Enemytips = (string[])propToValueMap[Champion.PropertyNames.Enemytips];
        }

        #endregion

        #region Id Property

        if (propToValueMap.ContainsKey(Champion.PropertyNames.Id) && propToValueMap[Champion.PropertyNames.Id] is int)
        {
            champion.Id = (int)propToValueMap[Champion.PropertyNames.Id];
        }

        #endregion

        #region Key Property

        if (propToValueMap.ContainsKey(Champion.PropertyNames.Key) && propToValueMap[Champion.PropertyNames.Key] is string)
        {
            champion.Key = (string)propToValueMap[Champion.PropertyNames.Key];
        }

        #endregion

        #region Image Property

        if (propToValueMap.ContainsKey(Champion.PropertyNames.Image) && propToValueMap[Champion.PropertyNames.Image] is Dictionary<String, Object>)
        {
            Dictionary<String, Object> riotImagePropValueMap = (Dictionary<String, Object>)propToValueMap[Champion.PropertyNames.Image];
            RiotImage riotImage = RiotImageConverter.DictionaryToRiotImage(riotImagePropValueMap);

            UnityEngine.Texture2D texture = UnityEngine.Resources.Load("Icons/champion/" + champion.Key) as UnityEngine.Texture2D;

            if (texture != null)
            {
                riotImage.Icon = UnityEngine.Sprite.Create(texture, new UnityEngine.Rect(0f, 0f, texture.width, texture.height), new UnityEngine.Vector2(0.5f, 0.5f), 128f);
            }

            texture = UnityEngine.Resources.Load("Images/champion/loading/" + champion.Key + "_0") as UnityEngine.Texture2D;
            if (texture != null)
            {
                riotImage.Portrait = UnityEngine.Sprite.Create(texture, new UnityEngine.Rect(0f, 0f, texture.width, texture.height), new UnityEngine.Vector2(0.5f, 0.5f), 128f); ;
            }

            champion.Image = riotImage;
        }

        #endregion

        #region Info Property

        /*if (propToValueMap.ContainsKey(Champion.PropertyNames.Blurb) && propToValueMap[Champion.PropertyNames.Info] is string)
        {
            champion.Info = (string)propToValueMap[Champion.PropertyNames.Info];
        }*/

        #endregion

        #region Lore Property

        if (propToValueMap.ContainsKey(Champion.PropertyNames.Lore) && propToValueMap[Champion.PropertyNames.Lore] is string)
        {
            champion.Lore = (string)propToValueMap[Champion.PropertyNames.Lore];
        }

        #endregion

        #region Name Property

        if (propToValueMap.ContainsKey(Champion.PropertyNames.Name) && propToValueMap[Champion.PropertyNames.Name] is string)
        {
            champion.Name = (string)propToValueMap[Champion.PropertyNames.Name];
        }

        #endregion

        #region Partype Property

        if (propToValueMap.ContainsKey(Champion.PropertyNames.Partype) && propToValueMap[Champion.PropertyNames.Partype] is string)
        {
            champion.Partype = (string)propToValueMap[Champion.PropertyNames.Partype];
        }

        #endregion

        #region Passive Property

        /* if (propToValueMap.ContainsKey(Champion.PropertyNames.Passive) && propToValueMap[Champion.PropertyNames.Passive] is string)
        {
            champion.Passive = (string)propToValueMap[Champion.PropertyNames.Passive];
        }*/

        #endregion

        #region Recommended Property

        /* if (propToValueMap.ContainsKey(Champion.PropertyNames.Recommended) && propToValueMap[Champion.PropertyNames.Recommended] is string)
        {
            champion.Recommended = (string)propToValueMap[Champion.PropertyNames.Recommended];
        }*/

        #endregion

        #region Skins Property

        /* if (propToValueMap.ContainsKey(Champion.PropertyNames.Skins) && propToValueMap[Champion.PropertyNames.Skins] is string)
        {
            champion.Skins = (string)propToValueMap[Champion.PropertyNames.Skins];
        }*/

        #endregion

        #region Spells Property

        /* if (propToValueMap.ContainsKey(Champion.PropertyNames.Spells) && propToValueMap[Champion.PropertyNames.Spells] is string)
        {
            champion.Spells = (string)propToValueMap[Champion.PropertyNames.Spells];
        }*/

        #endregion
        
        #region Stats Property

        if (propToValueMap.ContainsKey(Champion.PropertyNames.Stats) && propToValueMap[Champion.PropertyNames.Stats] is Dictionary<string, object>)
        {
            Dictionary<String, Object> championStatsPropValueMap = (Dictionary<String, Object>)propToValueMap[Champion.PropertyNames.Stats];
            ChampionStats championStats = ChampionStatsConverter.DictionaryToChampionStats(championStatsPropValueMap);

            champion.Stats = championStats;
        }

        #endregion

        #region Tags Property

        if (propToValueMap.ContainsKey(Champion.PropertyNames.Tags) && propToValueMap[Champion.PropertyNames.Tags] is string[])
        {
            champion.Tags = (string[])propToValueMap[Champion.PropertyNames.Tags];
        }

        #endregion

        #region Title Property

        if (propToValueMap.ContainsKey(Champion.PropertyNames.Title) && propToValueMap[Champion.PropertyNames.Title] is string)
        {
            champion.Title = (string)propToValueMap[Champion.PropertyNames.Title];
        }

        #endregion

        return champion;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matchDetail"></param>
    /// <returns></returns>
    public static Dictionary<String, Object> ChampionToDictionary(Champion champion)
    {
        if (champion == null)
        {
            throw new ArgumentException("parameter champion is required.");
        }

        Dictionary<String, Object> propToValueMap = new Dictionary<String, Object>();

        #region Allytips Property

        propToValueMap.Add(Champion.PropertyNames.Allytips, champion.Allytips);

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
        if (typeof(Champion).Equals(t))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Converts a dictionary into a Champion
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

        return DictionaryToChampion(value);
    }

    /// <summary>
    /// Converts a Champion into a dictionary
    /// </summary>
    /// <param name="type">Optional - the type of the value parameter</param>
    /// <param name="value">Optional - the instance that is to be converted into a dictionary</param>
    /// <returns>A Dictionary containing the data contained in the value parameter</returns>
    public override Dictionary<String, Object> WriteJson(Type type, Object value)
    {
        Champion champion = (Champion)value;
        return ChampionToDictionary(champion);
    }

    #endregion
}
