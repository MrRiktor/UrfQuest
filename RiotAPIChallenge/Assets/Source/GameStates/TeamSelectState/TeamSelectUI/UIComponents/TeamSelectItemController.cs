#region File Header

/**
 *   File Name:                 TeamSelectItemController.cs
 *   Author:                    Vincent Biancardi
 *   Creation Date:             April 8, 2015
 */

#endregion

using UnityEngine;
using System.Collections;
using System;

public class TeamSelectItemController : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private TeamSelectItemModel model;

    [SerializeField]
    private TeamSelectItemView view;

    #endregion

    #region Unity Methods

    /// <summary>
    /// Triggered when the game object this scrip
    /// is attached to is enabled
    /// </summary>
    void OnEnable( )
    {
        Messenger<Int32>.AddListener( MessengerEventTypes.TSI_MATCHID_CHANGE, OnMatchIdChange );
        Messenger<Int32>.AddListener( MessengerEventTypes.TSI_CHAMPIONID1_CHANGE, OnChampionId1Change );
        Messenger<Int32>.AddListener( MessengerEventTypes.TSI_CHAMPIONID2_CHANGE, OnChampionId2Change );
        Messenger<Int32>.AddListener( MessengerEventTypes.TSI_CHAMPIONID3_CHANGE, OnChampionId3Change );
        Messenger<Int32>.AddListener( MessengerEventTypes.TSI_CHAMPIONID4_CHANGE, OnChampionId4Change );
        Messenger<Int32>.AddListener( MessengerEventTypes.TSI_CHAMPIONID5_CHANGE, OnChampionId5Change );
    }

    /// <summary>
    /// Triggered when the game object this scrip
    /// is attached to is disabled
    /// </summary>
    void OnDisable( )
    {
        Messenger<Int32>.RemoveListener( MessengerEventTypes.TSI_MATCHID_CHANGE, OnMatchIdChange );
        Messenger<Int32>.RemoveListener( MessengerEventTypes.TSI_CHAMPIONID1_CHANGE, OnChampionId1Change );
        Messenger<Int32>.RemoveListener( MessengerEventTypes.TSI_CHAMPIONID2_CHANGE, OnChampionId2Change );
        Messenger<Int32>.RemoveListener( MessengerEventTypes.TSI_CHAMPIONID3_CHANGE, OnChampionId3Change );
        Messenger<Int32>.RemoveListener( MessengerEventTypes.TSI_CHAMPIONID4_CHANGE, OnChampionId4Change );
        Messenger<Int32>.RemoveListener( MessengerEventTypes.TSI_CHAMPIONID5_CHANGE, OnChampionId5Change );
    }

    #endregion

    #region Messenger Handlers

    /// <summary>
    /// Triggered when the models match Id changes
    /// </summary>
    private void OnMatchIdChange( Int32 newID )
    {
        view.OnMatchIdChange( newID );
    }

    /// <summary>
    /// Triggered when the models champion Id 1 changes
    /// </summary>
    private void OnChampionId1Change( Int32 newID )
    {
        view.OnChampionId1Change( newID );
    }

    /// <summary>
    /// Triggered when the models champion Id 2 changes
    /// </summary>
    private void OnChampionId2Change( Int32 newID )
    {
        view.OnChampionId2Change( newID );
    }

    /// <summary>
    /// Triggered when the models champion Id 3 changes
    /// </summary>
    private void OnChampionId3Change( Int32 newID )
    {
        view.OnChampionId3Change( newID );
    }

    /// <summary>
    /// Triggered when the models champion Id 4 changes
    /// </summary>
    private void OnChampionId4Change( Int32 newID )
    {
        view.OnChampionId4Change( newID );
    }

    /// <summary>
    /// Triggered when the models champion Id 5 changes
    /// </summary>
    private void OnChampionId5Change( Int32 newID )
    {
        view.OnChampionId5Change( newID );
    }

    #endregion
}