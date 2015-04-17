#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: Participant.cs
 * Date Created: 4/11/2015 8:28PM EST
 * 
 * Description: Converter for Participant Data Class
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;
using System.Collections.Generic;
using JsonFx.Json;

#endregion

public class ParticipantConverter : JsonConverter
{
    #region Public Methods

    #region Converters

    /// <summary>
    /// 
    /// </summary>
    /// <param name="propToValueMap"></param>
    /// <returns></returns>
    public static Participant DictionaryToParticipant( Dictionary<String, Object> propToValueMap )
    {
        Participant participant = new Participant();

        #region ChampionId Property

        if (propToValueMap[Participant.PropertyNames.ChampionId] is int)
        {
            participant.ChampionId = (int)propToValueMap[Participant.PropertyNames.ChampionId];
        }

        #endregion

        #region HighestAchievedSeasonTier Property

        if (propToValueMap[Participant.PropertyNames.HighestAchievedSeasonTier] is String)
        {
            participant.HighestAchievedSeasonTier = (String)propToValueMap[Participant.PropertyNames.HighestAchievedSeasonTier];
        }

        #endregion

        #region Masteries Property !!!!!!!!!!!!NOT IMPLEMENTED!!!!!!!!!!!!

        /* if (propToValueMap[Participant.PropertyNames.Masteries] is Dictionary<String, Object>[] )
        {
            participant.Masteries = (int)propToValueMap[Participant.PropertyNames.Masteries];
        }*/

        #endregion

        #region ParticipantId Property

        if (propToValueMap[Participant.PropertyNames.ParticipantId] is int)
        {
            participant.ParticipantId = (int)propToValueMap[Participant.PropertyNames.ParticipantId];
        }

        #endregion

        #region Runes Property !!!!!!!!!!!!NOT IMPLEMENTED!!!!!!!!!!!!

        /*if (propToValueMap[Participant.PropertyNames.Runes] is Dictionary<String, Object>[] )
        {
            participant.Runes = (int)propToValueMap[Participant.PropertyNames.Runes];
        }*/

        #endregion

        #region Spell1Id Property

        if (propToValueMap[Participant.PropertyNames.Spell1Id] is int)
        {
            participant.Spell1Id = (int)propToValueMap[Participant.PropertyNames.Spell1Id];
        }

        #endregion

        #region Spell2Id Property

        if( propToValueMap[Participant.PropertyNames.Spell2Id] is int )
        {
            participant.Spell2Id = (int)propToValueMap[Participant.PropertyNames.Spell2Id];
        }

        #endregion

        #region Stats Property

        if (propToValueMap[Participant.PropertyNames.Stats] is Dictionary<string, object>)
        {
            Dictionary<String, Object> participantStatsPropValueMap = (Dictionary<String, Object>)propToValueMap[Participant.PropertyNames.Stats];
            ParticipantStats participantStats = ParticipantStatsConverter.DictionaryToParticipantStats( participantStatsPropValueMap );

            participant.Stats = participantStats;
        }

        #endregion

        #region TeamId Property

        if( propToValueMap[Participant.PropertyNames.TeamId] is int )
        {
            participant.TeamId = (int)propToValueMap[Participant.PropertyNames.TeamId];
        }

        #endregion

        return participant;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matchDetail"></param>
    /// <returns></returns>
    public static Dictionary<String, Object> ParticipantToDictionary( Participant participant )
    {
        if( participant == null )
        {
            throw new ArgumentException( "parameter participant is required." );
        }

        Dictionary<String, Object> propToValueMap = new Dictionary<String, Object>();

        #region ChampionId Property

        propToValueMap.Add( Participant.PropertyNames.ChampionId, participant.ChampionId );

        #endregion

        return propToValueMap;
    }

    #endregion

    #region Json Converter Inherited Methods

    /// <summary>
    /// Tests to see if the current type can be converted by this converter class
    /// </summary>
    /// <param name="t">Optional - the type to be tested</param>
    /// <returns>true if the type can be converted, false otherwise</returns>
    public override bool CanConvert( Type t )
    {
        if( typeof( MatchDetail ).Equals( t ) )
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
    public override Object ReadJson( Type type, Dictionary<String, Object> value )
    {
        if( !CanConvert( type ) )
        {
            return null;
        }

        if( ( type == null ) || ( value == null ) )
        {
            return null;
        }

        return DictionaryToParticipant( value );
    }

    /// <summary>
    /// Converts a MatchDetail into a dictionary
    /// </summary>
    /// <param name="type">Optional - the type of the value parameter</param>
    /// <param name="value">Optional - the instance that is to be converted into a dictionary</param>
    /// <returns>A Dictionary containing the data contained in the value parameter</returns>
    public override Dictionary<String, Object> WriteJson( Type type, Object value )
    {
        Participant participant = (Participant)value;
        return ParticipantToDictionary( participant );
    }

    #endregion

    #endregion
}
