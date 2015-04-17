#region File Header

/*******************************************************************************
 * Author: Vincent "Sabin" Biancardi
 * Filename: FetchMatch.cs
 * Date Created: 4/10/2015 10:26 PM EST
 * 
 * Description: Makes the calls to grab the match data from JSON
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 8:13 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#endregion

public class FetchMatch : MonoBehaviour
{
    #region Private Variables

    /// <summary>
    /// The list of match IDs
    /// </summary>
    private List<Int64> matchIDs = new List<Int64>( );

    #endregion

    #region Protected Variables

    /// <summary>
    /// The parties from the match ids
    /// </summary>
    protected List<Party> parties = new List<Party>( );
    
    /// <summary>
    /// the maximum party stats.
    /// </summary>
    protected MaxPartyStats maxPartyStats = new MaxPartyStats( );

    #endregion

    #region Public Methods

    /// <summary>
    /// Adds a match ID and Fetches the 
    /// Match Details
    /// </summary>
    /// <param name="matchID">The ID of the match being added</param>
    public void AddMatchID( Int64 matchID )
    {
        matchIDs.Add( matchID );
        StartCoroutine( getMatch( matchID ) );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public IEnumerator getMatch( Int64 matchID )
    {
        string url = "";
        if ( Application.isWebPlayer )
        {
            url = "UrfQuest.php?apiCall=" + RiotAPIConstants.MATCHv2_2( Region.na, matchID );
        }
        else
        {
            url = RiotAPIConstants.MATCHv2_2( Region.na, matchID );
        }

        Fetch fetch = new Fetch( MatchGrabSuccess, failure, url, MatchDetail.fromJSON );

        return fetch.WaitForUrlData( );
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Success handler for grabbing a match.
    /// </summary>
    /// <param name="obj"> the matches MatchDetail object </param>
    private void MatchGrabSuccess( object obj )
    {
        MatchDetail match = null;

        if ( obj is MatchDetail )
        {
            match = ( obj as MatchDetail );

           // Debug.LogError( "Match ID: " + match.MatchId.ToString( ) );

            Party party = new Party( );

            party.MatchID = match.MatchId;

            foreach ( Participant p in match.Participants )
            {
                if ( p.Stats.Winner == true )
                {
                    PartyMember partyMember = new PartyMember( p );

                   // Debug.Log( "Name: " + partyMember.BeingName + " Attack: " + partyMember.AttackDamage + " | Health: " + partyMember.HealthPool + " | MovementSpeed: " + partyMember.MovementSpeed );

                    party.AddPartyMember( partyMember );
                }
            }

           // Debug.LogWarning( "Party Averages - Attack: " + party.AttackAverage + " | Health: " + party.HealthAverage + " | MovementSpeed: " + party.MovementSpeedAverage );
            parties.Add( party );
            CalculateMaxStats( );
            Messenger<Party>.Broadcast( MessengerEventTypes.TSUI_ADD_PARTY, party );
        }
    }

    /// <summary>
    /// The failure callback for the fetching of matches.
    /// </summary>
    /// <param name="message">the failure message </param>
    private void failure( string message )
    {
        Debug.LogError( message );
    }

    /// <summary>
    /// Calculates the maximum stats of the team and party members
    /// </summary>
    private void CalculateMaxStats( )
    {
        for ( Int32 i = 0; i < parties.Count; i++ )
        {
            Party party = parties [ i ];

            if ( (party.AttackAverage*5) > maxPartyStats.MaxTeamAttack )
            {
                maxPartyStats.MaxTeamAttack = ( party.AttackAverage * 5 );
            }

            if ( (party.HealthAverage*5) > maxPartyStats.MaxTeamHealthPool )
            {
                maxPartyStats.MaxTeamHealthPool = ( party.HealthAverage * 5 );
            }

            for ( Int32 j = 0; j < 5; j++ )
            {
                PartyMember partyMember = party.PartyMembers [ j ];

                if ( partyMember.AttackDamage > maxPartyStats.MaxPlayerAttack )
                {
                    maxPartyStats.MaxPlayerAttack = partyMember.AttackDamage;
                }

                if ( partyMember.HealthPool > maxPartyStats.MaxPlayerHealthPool )
                {
                    maxPartyStats.MaxPlayerHealthPool = partyMember.HealthPool;
                }

            }
        }
        Messenger<MaxPartyStats>.Broadcast( MessengerEventTypes.TSUI_MAX_PARTY_STATS_UPDATE, maxPartyStats );
    }

    #endregion
}