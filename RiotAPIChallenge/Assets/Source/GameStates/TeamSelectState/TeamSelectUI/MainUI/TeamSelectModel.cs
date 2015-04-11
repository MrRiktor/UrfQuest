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

    private PartyMember selectedPartyMember;

    private Boolean initFinalized = false;

    #endregion

    #region Accessors/Mutators

    #endregion

    #region Unity Methods

    /// <summary>
    /// Grab a pool of match ID's 
    /// on startup
    /// </summary>
    void Start( )
    {
        if ( ChampionDBManager.GetInstance( ).ChampionDBReady )
        {
            AddMatchID( 1783499038 );
            AddMatchID( 1783499704 );
            AddMatchID( 1783499709 );
            AddMatchID( 1783499209 );
            AddMatchID( 1783517364 );

            AddMatchID( 1787566261 );
            AddMatchID( 1787568249 );
            AddMatchID( 1787568426 );
            AddMatchID( 1787579044 );
            AddMatchID( 1787608607 );
            initFinalized = true;
        }
    }

    /// <summary>
    /// This is temporary until
    /// we have an intro scene
    /// </summary>
    void Update( )
    {
        if ( !initFinalized && ChampionDBManager.GetInstance( ).ChampionDBReady )
        {
            AddMatchID( 1783499038 );
            AddMatchID( 1783499704 );
            AddMatchID( 1783499709 );
            AddMatchID( 1783499209 );
            AddMatchID( 1783517364 );

            AddMatchID( 1787566261 );
            AddMatchID( 1787568249 );
            AddMatchID( 1787568426 );
            AddMatchID( 1787579044 );
            AddMatchID( 1787608607 );
            initFinalized = true;
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
                Messenger<Party>.Broadcast( MessengerEventTypes.TSUI_PARTY_UPDATE, selectedParty );
                break;
            }
        }
    }

    #endregion

}