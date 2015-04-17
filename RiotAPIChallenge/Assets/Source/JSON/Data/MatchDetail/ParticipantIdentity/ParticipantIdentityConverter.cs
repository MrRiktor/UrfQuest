#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: ParticipantIdentity.cs
 * Date Created: 4/11/2015 8:28PM EST
 * 
 * Description: Converter for ParticipantIdentity Data Class
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;
using System.Collections.Generic;
using JsonFx.Json;

#endregion

public class ParticipantIdentityConverter : JsonConverter
{
    #region Public Methods

    #region Converters

    /// <summary>
    /// 
    /// </summary>
    /// <param name="propToValueMap"></param>
    /// <returns></returns>
    public static ParticipantIdentity DictionaryToParticipantIdentity( Dictionary<String, Object> propToValueMap )
    {
        ParticipantIdentity participantIdentity = new ParticipantIdentity();

        #region ParticipantId Property

        if( propToValueMap.ContainsKey( ParticipantIdentity.PropertyNames.ParticipantId ) && propToValueMap[ParticipantIdentity.PropertyNames.ParticipantId] is int )
        {
            participantIdentity.ParticipantId = (int)propToValueMap[ParticipantIdentity.PropertyNames.ParticipantId];
        }

        #endregion

        #region Player Property

        if( propToValueMap.ContainsKey( ParticipantIdentity.PropertyNames.Player ) && propToValueMap[ParticipantIdentity.PropertyNames.Player] is Dictionary<string, object> )
        {
            Dictionary<String, Object> participantIdentityPropValueMap = (Dictionary<String, Object>)propToValueMap[ParticipantIdentity.PropertyNames.Player];
            Player player = PlayerConverter.DictionaryToPlayer( participantIdentityPropValueMap );

            participantIdentity.Player = player;
        }

        #endregion

        return participantIdentity;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="participantIdentity"></param>
    /// <returns></returns>
    public static Dictionary<String, Object> ParticipantIdentityToDictionary( ParticipantIdentity participantIdentity )
    {
        if( participantIdentity == null )
        {
            throw new ArgumentException( "parameter player is required." );
        }

        Dictionary<String, Object> propToValueMap = new Dictionary<String, Object>();

        /*#region ??? Property

        //propToValueMap.Add( Player.PropertyNames.???, player.??? );

        #endregion*/

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
        if( typeof( ParticipantIdentity ).Equals( t ) )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Converts a dictionary into a ParticipantIdentity
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

        return DictionaryToParticipantIdentity( value );
    }

    /// <summary>
    /// Converts a ParticipantIdentity into a dictionary
    /// </summary>
    /// <param name="type">Optional - the type of the value parameter</param>
    /// <param name="value">Optional - the instance that is to be converted into a dictionary</param>
    /// <returns>A Dictionary containing the data contained in the value parameter</returns>
    public override Dictionary<String, Object> WriteJson( Type type, Object value )
    {
        ParticipantIdentity participantIdentity = (ParticipantIdentity)value;
        return ParticipantIdentityToDictionary( participantIdentity );
    }

    #endregion

    #endregion
}
