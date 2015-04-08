using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// The data class used to initilize a TeamSelectItem
/// </summary>
public class TeamSelectData
{
    #region Variables

    private Int64 matchID;

    private String [] champions = new String [ 5 ];

    #endregion

    #region Accessor/Mutatots

    public Int64 MatchId
    {
        get
        {
            return matchID;
        }

        set
        {
            matchID = value;
        }
    }

    //Gets the name of a champion in index 0->4
    public String GetChampion( Int32 index )
    {
        if ( index < 0 || index > 4 )
            throw new ArgumentOutOfRangeException( );

        return champions [ index ];
    }

    //Sets the name of a champion in index 0->4
    public void SetChampion( Int32 index, String name )
    {
        if ( index < 0 || index > 4 )
            throw new ArgumentOutOfRangeException( );

        champions [ index ] = name;
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Team Select Data Constructor
    /// </summary>
    /// <param name="matchID">The ID of the match</param>
    /// <param name="championName1">The 1st slot Champion name</param>
    /// <param name="championName2">The 2nd slot Champion name</param>
    /// <param name="championName3">The 3rd slot Champion name</param>
    /// <param name="championName4">The 4th slot Champion name</param>
    /// <param name="championName5">The 5th slot Champion name</param>
    public TeamSelectData( Int64 matchID, String championName1, String championName2, String championName3, String championName4, String championName5 )
    {
        MatchId = matchID;
        SetChampion( 0, championName1 );
        SetChampion( 1, championName2 );
        SetChampion( 2, championName3 );
        SetChampion( 3, championName4 );
        SetChampion( 4, championName5 );
    }

    #endregion
}