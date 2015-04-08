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
public class TeamSelectItemView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    #region variables

    private Color32 COLOR_GOLD = new Color32( 255, 223, 0, 255 );
    private Color32 COLOR_DARK_GREY = new Color32( 64, 64, 64, 255 );
    private Color32 COLOR_LIGHT_GREY = new Color32( 128, 128, 128, 255 );

    [SerializeField]
    private Image mainBackground; //The background image we will be changing on select and hover

    #region Init Data

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

    #endregion


    private static TeamSelectItemView currentItem = null; //Keeps track of the currently selected TeamSelectItem
    #endregion

    #region Accessors/Mutators

    public static TeamSelectItemView CurrentItem
    {
        get
        {
            return currentItem;
        }
    }

    #endregion

    #region UI Visual Updates

    /// <summary>
    /// Triggered when the models match Id changes
    /// </summary>
    public void OnMatchIdChange( Int32 newID )
    {
        titleText.text = "Match ID: " + newID;
    }

    /// <summary>
    /// Triggered when the models champion Id 1 changes
    /// </summary>
    public void OnChampionId1Change( Int32 newID )
    {
       // championIcon1.sprite = SpriteManager.ChampionIcons [ newID ];
    }

    /// <summary>
    /// Triggered when the models champion Id 2 changes
    /// </summary>
    public void OnChampionId2Change( Int32 newID )
    {
        // championIcon2.sprite = SpriteManager.ChampionIcons [ newID ];
    }

    /// <summary>
    /// Triggered when the models champion Id 3 changes
    /// </summary>
    public void OnChampionId3Change( Int32 newID )
    {
        // championIcon3.sprite = SpriteManager.ChampionIcons [ newID ];
    }

    /// <summary>
    /// Triggered when the models champion Id 4 changes
    /// </summary>
    public void OnChampionId4Change( Int32 newID )
    {
        // championIcon4.sprite = SpriteManager.ChampionIcons [ newID ];
    }

    /// <summary>
    /// Triggered when the models champion Id 5 changes
    /// </summary>
    public void OnChampionId5Change( Int32 newID )
    {
        // championIcon5.sprite = SpriteManager.ChampionIcons [ newID ];
    }

    #endregion

    #region IPointerEnterHandler Implementation

    /// <summary>
    /// Gets Triggered when the mouse enters 
    /// the button region
    /// </summary>
    void IPointerEnterHandler.OnPointerEnter( PointerEventData data )
    {
        if ( this != CurrentItem )
            mainBackground.color = COLOR_LIGHT_GREY;
    }

    #endregion

    #region IPointerExitHandler Implementation

    /// <summary>
    /// Gets Triggered when the mouse exits
    /// the button region
    /// </summary>
    void IPointerExitHandler.OnPointerExit( PointerEventData data )
    {
        if ( this != CurrentItem )
            mainBackground.color = COLOR_DARK_GREY;
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