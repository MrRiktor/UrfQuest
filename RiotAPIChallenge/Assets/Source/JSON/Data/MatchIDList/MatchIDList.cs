using System;
using System.Collections.Generic;

public class MatchIDList
{
    #region Private Constants

    /// <summary>
    /// 
    /// </summary>
    public static class PropertyNames
    {
        public static readonly String MatchIdList = "matchIdList";
    }

    #endregion
    
    #region Private Property Declarations

    /// <summary>
    /// a list of game IDs for a 5 minute time range, starting with the given date.
    /// </summary>
    private List<long> iDList;

    #endregion
    
    #region Accessors/Modifiers

    /// <summary>
    /// 
    /// </summary>
    public List<long> IDList
    {
        get
        {
            return iDList;
        }
        set
        {
            iDList = value;
        }
    }

    #endregion

    #region Constructor

    public MatchIDList()
    {
    
    }

    public MatchIDList( List<long> matchIDList )
    {
        this.iDList = matchIDList;
    }

    #endregion
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="rawResponse"></param>
    /// <returns></returns>
    public static MatchIDList fromJSON( object rawResponse )
    {
        if (rawResponse is String)
        {
            String json = (String)rawResponse;
            JsonFx.Json.JsonReader reader = JSONUtils.getJsonReader(json);
            long[] matchArray = reader.Deserialize<long[]>();

            return new MatchIDList( new List<long>( matchArray ) );
        }

        return new MatchIDList();
    }
}
