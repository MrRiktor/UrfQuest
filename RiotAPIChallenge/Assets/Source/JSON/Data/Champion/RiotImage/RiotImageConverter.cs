using System;
using System.Collections.Generic;
using JsonFx.Json;

public class RiotImageConverter : JsonConverter
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="propToValueMap"></param>
    /// <returns></returns>
    public static RiotImage DictionaryToRiotImage(Dictionary<String, Object> propToValueMap)
    {
        RiotImage riotImage = new RiotImage();

        #region Full Property

        if (propToValueMap.ContainsKey(RiotImage.PropertyNames.Full) && propToValueMap[RiotImage.PropertyNames.Full] is string)
        {
            riotImage.Full = (string)propToValueMap[RiotImage.PropertyNames.Full];
        }

        #endregion

        #region Group Property

        if (propToValueMap.ContainsKey(RiotImage.PropertyNames.Group) && propToValueMap[RiotImage.PropertyNames.Group] is string)
        {
            riotImage.Group = (string)propToValueMap[RiotImage.PropertyNames.Group];
        }

        #endregion

        #region Height Property

        if (propToValueMap.ContainsKey(RiotImage.PropertyNames.Height) && propToValueMap[RiotImage.PropertyNames.Height] is int)
        {
            riotImage.Height = (int)propToValueMap[RiotImage.PropertyNames.Height];
        }

        #endregion

        #region Sprite Property

        if (propToValueMap.ContainsKey(RiotImage.PropertyNames.Sprite) && propToValueMap[RiotImage.PropertyNames.Sprite] is string)
        {
            riotImage.Sprite = (string)propToValueMap[RiotImage.PropertyNames.Sprite];
        }

        #endregion

        #region Width Property

        if (propToValueMap.ContainsKey(RiotImage.PropertyNames.Width) && propToValueMap[RiotImage.PropertyNames.Width] is int)
        {
            riotImage.Width = (int)propToValueMap[RiotImage.PropertyNames.Width];
        }

        #endregion

        #region X Property

        if (propToValueMap.ContainsKey(RiotImage.PropertyNames.X) && propToValueMap[RiotImage.PropertyNames.X] is int)
        {
            riotImage.X = (int)propToValueMap[RiotImage.PropertyNames.X];
        }

        #endregion

        #region Y Property

        if (propToValueMap.ContainsKey(RiotImage.PropertyNames.Y) && propToValueMap[RiotImage.PropertyNames.Y] is int)
        {
            riotImage.Y = (int)propToValueMap[RiotImage.PropertyNames.Y];
        }

        #endregion

        return riotImage;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matchDetail"></param>
    /// <returns></returns>
    public static Dictionary<String, Object> RiotImageToDictionary(RiotImage riotImage)
    {
        if (riotImage == null)
        {
            throw new ArgumentException("parameter champion is required.");
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
        if (typeof(RiotImage).Equals(t))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Converts a dictionary into a RiotImage
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

        return DictionaryToRiotImage(value);
    }

    /// <summary>
    /// Converts a RiotImage into a dictionary
    /// </summary>
    /// <param name="type">Optional - the type of the value parameter</param>
    /// <param name="value">Optional - the instance that is to be converted into a dictionary</param>
    /// <returns>A Dictionary containing the data contained in the value parameter</returns>
    public override Dictionary<String, Object> WriteJson(Type type, Object value)
    {
        RiotImage riotImage = (RiotImage)value;
        return RiotImageToDictionary(riotImage);
    }

    #endregion
}
