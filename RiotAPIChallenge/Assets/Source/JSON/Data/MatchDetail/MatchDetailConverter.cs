using System;
using System.Collections.Generic;
using JsonFx.Json;

public class MatchDetailConverter : JsonConverter
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="propToValueMap"></param>
    /// <returns></returns>
    public static MatchDetail DictionaryToMatchDetail(Dictionary<String, Object> propToValueMap)
    {
        MatchDetail matchDetail = new MatchDetail();

        #region MapId Property

        if (propToValueMap[MatchDetail.PropertyNames.MapId] is int)
        {
            matchDetail.MapId = (int)propToValueMap[MatchDetail.PropertyNames.MapId];
        }

        #endregion

        #region MatchCreation Property

        if (propToValueMap[MatchDetail.PropertyNames.MatchCreation] is long)
        {
            matchDetail.MatchCreation = (long)propToValueMap[MatchDetail.PropertyNames.MatchCreation];
        }

        #endregion

        #region MatchDuration Property

        if (propToValueMap[MatchDetail.PropertyNames.MatchDuration] is int)
        {
            matchDetail.MatchDuration = (int)propToValueMap[MatchDetail.PropertyNames.MatchDuration];
        }

        else if (propToValueMap[MatchDetail.PropertyNames.MatchDuration] is long)
        {
            matchDetail.MatchDuration = (long)propToValueMap[MatchDetail.PropertyNames.MatchDuration];
        }

        #endregion
        
        #region MatchId Property

        if (propToValueMap[MatchDetail.PropertyNames.MatchId] is int )
        {
            matchDetail.MatchId = (int)propToValueMap[MatchDetail.PropertyNames.MatchId];
        }

        else if ( propToValueMap[MatchDetail.PropertyNames.MatchId] is long)
        {
            matchDetail.MatchId = (long)propToValueMap[MatchDetail.PropertyNames.MatchId];
        }

        #endregion

        #region MatchMode Property

        if (propToValueMap[MatchDetail.PropertyNames.MatchMode] is String)
        {
            matchDetail.MatchMode = (String)propToValueMap[MatchDetail.PropertyNames.MatchMode];
        }

        #endregion

        #region MatchType Property

        if (propToValueMap[MatchDetail.PropertyNames.MatchType] is String)
        {
            matchDetail.MatchType = (String)propToValueMap[MatchDetail.PropertyNames.MatchType];
        }

        #endregion
        
        #region MatchVersion Property

        if (propToValueMap[MatchDetail.PropertyNames.MatchVersion] is String)
        {
            matchDetail.MatchVersion = (String)propToValueMap[MatchDetail.PropertyNames.MatchVersion];
        }

        #endregion

        #region ParticipantIdentities Property !!!!!!!!!(Not yet implemented)!!!!!!!!!!!!!

        /*if (propToValueMap[MatchDetail.PropertyNames.ParticipantIdentities] is String)
        {
            matchDetail.ParticipantIdentities = (String)propToValueMap[MatchDetail.PropertyNames.ParticipantIdentities];
        }*/

        #endregion
        
        #region Participants Property !!!!!!!!!!!!(Not Yet Implemented)!!!!!!!

        if (propToValueMap[MatchDetail.PropertyNames.Participants] != null)
        {
            object obj = propToValueMap[MatchDetail.PropertyNames.Participants];

            Dictionary<System.String, System.Object> subObj = new Dictionary<System.String, System.Object>();

            subObj = obj as Dictionary<System.String, System.Object>;

            //matchDetail.Participants = (List<Participant>)propToValueMap[MatchDetail.PropertyNames.Participants];
        }

        #endregion
        
        #region PlatformId Property

        if (propToValueMap[MatchDetail.PropertyNames.PlatformId] is String)
        {
            matchDetail.PlatformId = (String)propToValueMap[MatchDetail.PropertyNames.PlatformId];
        }

        #endregion

        #region QueueType Property

        if (propToValueMap[MatchDetail.PropertyNames.QueueType] is String)
        {
            matchDetail.QueueType = (String)propToValueMap[MatchDetail.PropertyNames.QueueType];
        }

        #endregion
        
        #region Region Property

        if (propToValueMap[MatchDetail.PropertyNames.Region] is String)
        {
            matchDetail.Region = (String)propToValueMap[MatchDetail.PropertyNames.Region];
        }

        #endregion
        
        #region Season Property

        if (propToValueMap[MatchDetail.PropertyNames.Season] is String)
        {
            matchDetail.Season = (String)propToValueMap[MatchDetail.PropertyNames.Season];
        }

        #endregion
        
        #region Teams Property !!!!!!!!!(Not Yet IMPLEMENTED)!!!!!!!!!!!!!!!!

       /* if (propToValueMap[MatchDetail.PropertyNames.Teams] is String)
        {
            matchDetail.Teams = (String)propToValueMap[MatchDetail.PropertyNames.Teams];
        }*/

        #endregion

        #region Timeline Property !!!!!!!!!(Not Yet IMPLEMENTED)!!!!!!!!!!!!!!!!

        /*if (propToValueMap[MatchDetail.PropertyNames.Timeline] is String)
        {
            matchDetail.Timeline = (String)propToValueMap[MatchDetail.PropertyNames.Timeline];
        }*/

        #endregion

        return matchDetail;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matchDetail"></param>
    /// <returns></returns>
    public static Dictionary<String, Object> MatchDetailToDictionary(MatchDetail matchDetail)
    {
        if (matchDetail == null)
        {
            throw new ArgumentException("parameter matchDetail is required.");
        }

        Dictionary<String, Object> propToValueMap = new Dictionary<String, Object>();

        #region MapID Property

        propToValueMap.Add( MatchDetail.PropertyNames.MapId, matchDetail.MapId );

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
        if (typeof(MatchDetail).Equals(t))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Converts a dictionary into a MatchDetail
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

        return DictionaryToMatchDetail(value);
    }

    /// <summary>
    /// Converts a MatchDetail into a dictionary
    /// </summary>
    /// <param name="type">Optional - the type of the value parameter</param>
    /// <param name="value">Optional - the instance that is to be converted into a dictionary</param>
    /// <returns>A Dictionary containing the data contained in the value parameter</returns>
    public override Dictionary<String, Object> WriteJson(Type type, Object value)
    {
        MatchDetail matchDetail = (MatchDetail)value;
        return MatchDetailToDictionary(matchDetail);
    }

    #endregion
}
