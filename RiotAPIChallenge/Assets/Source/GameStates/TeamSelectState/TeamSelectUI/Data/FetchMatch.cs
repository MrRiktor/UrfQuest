using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetchMatch : MonoBehaviour
{
    private List<Int64> matchIDs = new List<Int64>( );
    protected List<Party> parties = new List<Party>( );

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
        Fetch fetch = new Fetch( MatchGrabSuccess, failure, RiotAPIConstants.MATCHv2_2( Region.na, matchID ), MatchDetail.fromJSON );

        return fetch.WaitForUrlData( );
    }

    private void MatchGrabSuccess( object obj )
    {
        MatchDetail match = null;

        if ( obj is MatchDetail )
        {
            match = ( obj as MatchDetail );

            Debug.LogError( "Match ID: " + match.MatchId.ToString( ) );

            Party party = new Party( );

            party.MatchID = match.MatchId;

            foreach ( Participant p in match.Participants )
            {
                if ( p.Stats.Winner == true )
                {
                    PartyMember partyMember = new PartyMember( p );

                    Debug.Log( "Name: " + partyMember.BeingName + " Attack: " + partyMember.AttackDamage + " | Health: " + partyMember.HealthPool + " | MovementSpeed: " + partyMember.MovementSpeed );

                    party.AddPartyMember( partyMember );
                }
            }

            Debug.LogWarning( "Party Averages - Attack: " + party.AttackAverage + " | Health: " + party.HealthAverage + " | MovementSpeed: " + party.MovementSpeedAverage );
            Messenger<Party>.Broadcast( MessengerEventTypes.TSUI_ADD_PARTY, party );
            parties.Add( party );
        }
    }

    private void failure( string message )
    {
        Debug.LogError( message );
    }
}