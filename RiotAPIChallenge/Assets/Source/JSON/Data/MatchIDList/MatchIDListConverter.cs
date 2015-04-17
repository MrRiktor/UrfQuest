#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: MatchIDListConverter.cs
 * Date Created: 4/11/2015 8:28PM EST
 * 
 * Description: Converter for MatchIDList Data Class
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;
using System.Collections.Generic;
using JsonFx.Json;

#endregion

public class MatchIDListConverter : JsonConverter
{
    #region Public Methods

    #region Converters

    /// <summary>
    /// 
    /// </summary>
    /// <param name="propToValueMap"></param>
    /// <returns></returns>
    public static MatchIDList DictionaryToMatchIDList( Dictionary<String, Object> propToValueMap )
    {
        MatchIDList matchIDList = new MatchIDList();

        #region MatchIDList Property

        if( propToValueMap[MatchIDList.PropertyNames.MatchIdList] is List<long> )
        {
            matchIDList.IDList = (List<long>)propToValueMap[MatchIDList.PropertyNames.MatchIdList];
        }

        #endregion

        return matchIDList;
    }    

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matchIDList"></param>
    /// <returns></returns>
    public static Dictionary<String, Object> MatchIDListToDictionary( MatchIDList matchIDList )
    {
        if( matchIDList == null )
        {
            throw new ArgumentException( "parameter matchIDList is required." );
        }

        Dictionary<String, Object> propToValueMap = new Dictionary<String, Object>();

        #region MatchIDList Property

        propToValueMap.Add( MatchIDList.PropertyNames.MatchIdList, matchIDList.IDList );

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
        if( typeof( MatchIDList ).Equals( t ) )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Converts a dictionary into a MatchIDList
    /// </summary>
    /// <param name="type">Optional - the type of the value parameter</param>
    /// <param name="value">Optional - the dictionary that is to be converted into an instance</param>
    /// <returns>A MatchIDList instance if type and value are not null, null otherwise</returns>
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

        return DictionaryToMatchIDList( value );
    }

    /// <summary>
    /// Converts a MatchIDList into a dictionary
    /// </summary>
    /// <param name="type">Optional - the type of the value parameter</param>
    /// <param name="value">Optional - the instance that is to be converted into a dictionary</param>
    /// <returns>A Dictionary containing the data contained in the value parameter</returns>
    public override Dictionary<String, Object> WriteJson( Type type, Object value )
    {
        MatchIDList matchIDList = (MatchIDList)value;
        return MatchIDListToDictionary( matchIDList );
    }

    #endregion

    #endregion
}
