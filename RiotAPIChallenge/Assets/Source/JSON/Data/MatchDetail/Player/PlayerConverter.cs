#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: PlayerConverter.cs
 * Date Created: 4/11/2015 8:28PM EST
 * 
 * Description: Converter for Player Data Class
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;
using System.Collections.Generic;
using JsonFx.Json;

#endregion

public class PlayerConverter : JsonConverter
{
    #region Public Methods

    #region Converters

    /// <summary>
    /// 
    /// </summary>
    /// <param name="propToValueMap"></param>
    /// <returns></returns>
    public static Player DictionaryToPlayer( Dictionary<String, Object> propToValueMap )
    {
        Player player = new Player();

        #region MatchHistoryUri Property

        if( propToValueMap[Player.PropertyNames.MatchHistoryUri] is string )
        {
            player.MatchHistoryUri = (string)propToValueMap[Player.PropertyNames.MatchHistoryUri];
        }

        #endregion

        #region ProfileIcon Property

        if( propToValueMap[Player.PropertyNames.ProfileIcon] is int )
        {
            player.ProfileIcon = (int)propToValueMap[Player.PropertyNames.ProfileIcon];
        }

        #endregion

        #region SummonerId Property

        if( propToValueMap[Player.PropertyNames.SummonerId] is long )
        {
            player.SummonerId = (long)propToValueMap[Player.PropertyNames.SummonerId];
        }

        else if( propToValueMap[Player.PropertyNames.SummonerId] is int )
        {
            player.SummonerId = (int)propToValueMap[Player.PropertyNames.SummonerId];
        }

        #endregion

        #region SummonerName Property

        if( propToValueMap[Player.PropertyNames.SummonerName] is string )
        {
            player.SummonerName = (string)propToValueMap[Player.PropertyNames.SummonerName];
        }

        #endregion

        return player;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    public static Dictionary<String, Object> PlayerToDictionary( Player player )
    {
        if( player == null )
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
        if( typeof( Player ).Equals( t ) )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Converts a dictionary into a Player
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

        return DictionaryToPlayer( value );
    }

    /// <summary>
    /// Converts a Player into a dictionary
    /// </summary>
    /// <param name="type">Optional - the type of the value parameter</param>
    /// <param name="value">Optional - the instance that is to be converted into a dictionary</param>
    /// <returns>A Dictionary containing the data contained in the value parameter</returns>
    public override Dictionary<String, Object> WriteJson( Type type, Object value )
    {
        Player player = (Player)value;
        return PlayerToDictionary( player );
    }

    #endregion

    #endregion
}