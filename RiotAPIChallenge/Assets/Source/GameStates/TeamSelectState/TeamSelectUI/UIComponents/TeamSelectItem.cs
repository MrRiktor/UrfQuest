#region File Header

/**
 *   File Name:                 TeamSelectItemView.cs
 *   Author:                    Vincent Biancardi
 *   Creation Date:             April 8, 2015
 */

#endregion

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// A UI Team Item that gets dynamically created when the users
/// needs to select a team from random match ID's
/// </summary>
public class TeamSelectItem : MonoBehaviour
{
    #region variables

    private Color32 COLOR_GOLD = new Color32( 255, 223, 0, 255 );
    private Color32 COLOR_DARK_GREY = new Color32( 64, 64, 64, 255 );
    private Color32 COLOR_LIGHT_GREY = new Color32( 128, 128, 128, 255 );

    private Int64 matchID;

    [SerializeField]
    private Image mainBackground; //The background image we will be changing on select and hover

    [SerializeField]
    private Text titleText; //The title of the team
    [SerializeField]
    private Image championIcon1;
    [SerializeField]
    private Image championIcon2;
    [SerializeField]
    private Image championIcon3;
    [SerializeField]
    private Image championIcon4;
    [SerializeField]
    private Image championIcon5;

    private AudioSource buttonAudioSource;

    private static TeamSelectItem currentItem = null; //Keeps track of the currently selected TeamSelectItem
   
    #endregion

    #region Accessors/Mutators

    public static TeamSelectItem CurrentItem
    {
        get
        {
            return currentItem;
        }
    }

    #endregion

    #region Initialization

    void Start( )
    {
        buttonAudioSource = transform.parent.GetComponent<AudioSource>();
    }

    /// <summary>
    /// Updates the visual item with the passed
    /// in data
    /// </summary>
    /// <param name="matchId">Id the party is attached to</param>
    /// <param name="champIcon1">postion 1 champion</param>
    /// <param name="champIcon2">postion 2 champion</param>
    /// <param name="champIcon3">postion 3 champion</param>
    /// <param name="champIcon4">postion 4 champion</param>
    /// <param name="champIcon5">postion 5 champion</param>
    public void InitData( Int64 matchID, Sprite champIcon1, Sprite champIcon2, Sprite champIcon3, Sprite champIcon4, Sprite champIcon5 )
    {
        this.matchID = matchID;

        titleText.text = matchID.ToString( );
        championIcon1.sprite = champIcon1;
        championIcon2.sprite = champIcon2;
        championIcon3.sprite = champIcon3;
        championIcon4.sprite = champIcon4;
        championIcon5.sprite = champIcon5;
    }

    #endregion

    #region Button Input Methods

    /// <summary>
    /// Triggered when this item is clicked
    /// </summary>
    public void OnButtonClick( )
    {
        if ( this != CurrentItem )
        {
            if ( CurrentItem != null )
                CurrentItem.Reset( );

            currentItem = this;

            Messenger<Int64>.Broadcast( MessengerEventTypes.TSUI_PARTY_SELECTED, matchID );

            mainBackground.color = COLOR_GOLD;
        }
    }

    #endregion

    #region public UI Methods

    /// <summary>
    /// Resets the UI to initial form
    /// </summary>
    void Reset( )
    {
        mainBackground.color = COLOR_DARK_GREY;
    }

    #endregion

}