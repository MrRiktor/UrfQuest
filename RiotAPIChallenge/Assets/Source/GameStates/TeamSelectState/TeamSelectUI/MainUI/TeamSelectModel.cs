#region File Header

/**
 *   File Name:                 IGameStat.cs
 *   Author:                    Vincent Biancardi
 *   Creation Date:             April 8, 2015
 */

#endregion

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Maintains the data that controlls
/// the TeamSelectView
/// </summary>
public class TeamSelectModel : MonoBehaviour
{
    #region Variables

    private List<MatchDetail> matchDetails = new List<MatchDetail>( );

    private MatchDetail selectedMatchDetail;

    private Participant selectedParticipant;

    #endregion

    #region Accessors/Mutators

    #endregion

    #region Unity Methods

    /// <summary>
    /// Triggered when the game object this scrip
    /// is attached to is enabled
    /// </summary>
    void OnEnable( )
    {
        //API Call to grab Matches and Their data
    }

    #endregion

    #region private methods

    private void APICallSuccessHandler( )
    {
        //Fill out data
    }

    private void AddMatchDetail( MatchDetail matchDetail )
    {
        //TODO Send Message to controller
        matchDetails.Add( matchDetail );
    }

    #endregion

}