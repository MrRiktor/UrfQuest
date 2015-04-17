#region File Header

/*******************************************************************************
 * Author: Vincent "Sabin" Biancardi
 * Filename: TeamSelectController.cs
 * Date Created: 4/8/2015 10:26 PM EST
 * 
 * Description: The team select's MVC controller
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 8:13 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using System.Collections;
using System;

#endregion

public class TeamSelectController : MonoBehaviour
{
    #region Private Variables

    /// <summary>
    /// The model of the MVC
    /// </summary>
    [SerializeField]
    private TeamSelectModel model;

    /// <summary>
    /// the view of the MVC
    /// </summary>
    [SerializeField]
    private TeamSelectView view;

    #endregion

    #region Unity Methods

    /// <summary>
    /// Triggered when the game object this scrip
    /// is attached to is enabled
    /// </summary>
    void OnEnable( )
    {
        //From Model
        Messenger<Party>.AddListener( MessengerEventTypes.TSUI_ADD_PARTY, OnPartyAdd );
        Messenger<Party, MaxPartyStats>.AddListener( MessengerEventTypes.TSUI_PARTY_UPDATE, OnPartyUpdate );
        Messenger<MaxPartyStats>.AddListener( MessengerEventTypes.TSUI_MAX_PARTY_STATS_UPDATE, OnMaxStatsUpdate );
        Messenger<ParticipantStats>.AddListener( MessengerEventTypes.TSUI_PARTY_MEMBER_UPDATE, OnPartyMemberUpdate );

        //FromView
        Messenger<Int64>.AddListener( MessengerEventTypes.TSUI_PARTY_SELECTED, OnPartySelect );
        Messenger<Int32>.AddListener( MessengerEventTypes.TSUI_PARTY_MEMBER_SELECTED, OnPartyMemberSelect );
    }

    /// <summary>
    /// Triggered when the game object this scrip
    /// is attached to is disabled
    /// </summary>
    void OnDisable( )
    {
        //From Model
        Messenger<Party>.RemoveListener( MessengerEventTypes.TSUI_ADD_PARTY, OnPartyAdd );
        Messenger<Party, MaxPartyStats>.RemoveListener( MessengerEventTypes.TSUI_PARTY_UPDATE, OnPartyUpdate );
        Messenger<MaxPartyStats>.RemoveListener( MessengerEventTypes.TSUI_MAX_PARTY_STATS_UPDATE, OnMaxStatsUpdate );
        Messenger<ParticipantStats>.RemoveListener( MessengerEventTypes.TSUI_PARTY_MEMBER_UPDATE, OnPartyMemberUpdate );

        //FromView
        Messenger<Int64>.RemoveListener( MessengerEventTypes.TSUI_PARTY_SELECTED, OnPartySelect );
        Messenger<Int32>.RemoveListener( MessengerEventTypes.TSUI_PARTY_MEMBER_SELECTED, OnPartyMemberSelect );
    }

    #endregion

    #region Messenger Handlers From Model

    /// <summary>
    /// Updates the visuals for selected party
    /// </summary>
    /// <param name="party"></param>
    private void OnPartyUpdate( Party party, MaxPartyStats maxPartyStats )
    {
        view.UpdateParty( party, maxPartyStats );
    }

    /// <summary>
    /// Triggered when the model adds
    /// a Party to its list
    /// </summary>
    /// <param name="party">party being added</param>
    private void OnPartyAdd( Party party )
    {
        view.AddParty( party );
    }

    private void OnPartyMemberUpdate( ParticipantStats stats )
    {
        view.UpdateSelectedPartyMember( stats );
    }

    private void OnMaxStatsUpdate( MaxPartyStats maxStats )
    {
        if ( model.SelectedParty == null )
            return;

        view.UpdateParty( model.SelectedParty, maxStats );
    }

    #endregion

    #region Messenger Handlers From View

    /// <summary>
    /// Gets called when a team item gets
    /// clicked
    /// </summary>
    /// <param name="matchID">matchId of the item</param>
    private void OnPartySelect( Int64 matchID )
    {
        model.PartyChange( matchID );
        view.EnableContinue( );
    }

    private void OnPartyMemberSelect( Int32 playerIndex )
    {
        model.PartyMemberChange( playerIndex );
    }

    #endregion
}