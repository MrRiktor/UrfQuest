#region File Header

/*******************************************************************************
 * Author: Vincent "Sabin" Biancardi
 * Filename: TeamSelectData.cs
 * Date Created: 4/8/2015 10:26 PM EST
 * 
 * Description: The data class used to initilize a TeamSelectItem
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 8:13 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using System.Collections;
using System;

#endregion

public class TeamSelectData
{
    #region Private Variables

    /// <summary>
    /// The match ID
    /// </summary>
    private Int64 matchID;

    /// <summary>
    /// The champion string list.
    /// </summary>
    private String [] champions = new String [ 5 ];

    #endregion

    #region Accessor/Mutatots

    /// <summary>
    /// Accessor for the matchId
    /// </summary>
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
        
    /// <summary>
    /// Gets the name of a champion in index 0->4
    /// </summary>
    /// <param name="index"> the index </param>
    /// <returns> return a champion name. </returns>
    public String GetChampion( Int32 index )
    {
        if ( index < 0 || index > 4 )
            throw new ArgumentOutOfRangeException( );

        return champions [ index ];
    }
        
    /// <summary>
    /// Sets the name of a champion in index 0->4
    /// </summary>
    /// <param name="index"></param>
    /// <param name="name"></param>
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