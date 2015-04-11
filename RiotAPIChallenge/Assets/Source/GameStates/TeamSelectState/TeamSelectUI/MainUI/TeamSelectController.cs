#region File Header

/**
 *   File Name:                 TeamSelectController.cs
 *   Author:                    Vincent Biancardi
 *   Creation Date:             April 8, 2015
 */

#endregion

using UnityEngine;
using System.Collections;
using System;

public class TeamSelectController : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private TeamSelectModel model;

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
        Messenger<Party>.AddListener( MessengerEventTypes.TSUI_PARTY_UPDATE, OnPartyUpdate );

        //FromView
        Messenger<Int64>.AddListener( MessengerEventTypes.TSUI_PARTY_SELECTED, OnPartySelect );
    }

    /// <summary>
    /// Triggered when the game object this scrip
    /// is attached to is disabled
    /// </summary>
    void OnDisable( )
    {
        //From Model
        Messenger<Party>.RemoveListener( MessengerEventTypes.TSUI_ADD_PARTY, OnPartyAdd );
        Messenger<Party>.RemoveListener( MessengerEventTypes.TSUI_PARTY_UPDATE, OnPartyUpdate );

        //FromView
        Messenger<Int64>.RemoveListener( MessengerEventTypes.TSUI_PARTY_SELECTED, OnPartySelect );
    }

    #endregion

    #region Messenger Handlers From Model

    /// <summary>
    /// Updates the visuals for selected party
    /// </summary>
    /// <param name="party"></param>
    private void OnPartyUpdate( Party party )
    {
        view.UpdateParty( party );
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

    #endregion

}