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
using System;

/// <summary>
/// Maintains the data that controlls
/// the TeamSelectView
/// </summary>
public class TeamSelectModel : FetchMatch
{
    #region Variables

    private Party selectedParty;

    private Int32 selectedPartyMemberIndex = 0;

    #endregion

    #region Accessors/Mutators

    public Party SelectedParty
    {
        get
        {
            return selectedParty;
        }
    }

    #endregion

    #region Unity Methods

    /// <summary>
    /// Grab a pool of match ID's 
    /// on startup
    /// </summary>
    void Start( )
    {
        List<long> matchIDs = GrabMatchIDsFromFile.FetchRandomMatchIDs();
            
        foreach(long matchID in matchIDs)
        {
            AddMatchID(matchID);
        }
    }

    #endregion

    #region Interaction Handlers

    /// <summary>
    /// On Sumbit Press
    /// </summary>
    public void OnSubmit( )
    {
        GameData.CurrentParty = selectedParty;
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.PROGRESSION );
    }


    /// <summary>
    /// On Cancel Press
    /// </summary>
    public void OnCancel( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.INTRO );
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Updates the selected party
    /// </summary>
    /// <param name="matchID">the matchid of the selected party</param>
    public void PartyChange( Int64 matchID )
    {
        for ( Int32 i = 0; i < parties.Count; i++ )
        {
            Party party = parties [ i ];

            if ( party != null && matchID.Equals( party.MatchID ) )
            {
                selectedParty = party;
                Messenger<Party, MaxPartyStats>.Broadcast( MessengerEventTypes.TSUI_PARTY_UPDATE, selectedParty, maxPartyStats );
                Messenger<ParticipantStats>.Broadcast( MessengerEventTypes.TSUI_PARTY_MEMBER_UPDATE, selectedParty.PartyMembers [ selectedPartyMemberIndex ].Stats );
                break;
            }
        }
    }

    public void PartyMemberChange( Int32 playerIndex )
    {
        selectedPartyMemberIndex = playerIndex;
        Messenger<ParticipantStats>.Broadcast( MessengerEventTypes.TSUI_PARTY_MEMBER_UPDATE, selectedParty.PartyMembers [ playerIndex ].Stats );
    }

    #endregion

}