using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

/// <summary>
/// A UI Team Item that gets dynamically created when the users
/// needs to select a team from random match ID's
/// </summary>
public class TeamSelectItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

    #region Initilization

    public void InitData( TeamSelectData data )
    {
        titleText.text = "Match ID: " + data.MatchId;
        championIcon1.sprite = Resources.Load<Sprite>( "Icons/champion/" + data.GetChampion( 0 ) );
        championIcon2.sprite = Resources.Load<Sprite>( "Icons/champion/" + data.GetChampion( 1 ) );
        championIcon3.sprite = Resources.Load<Sprite>( "Icons/champion/" + data.GetChampion( 2 ) );
        championIcon4.sprite = Resources.Load<Sprite>( "Icons/champion/" + data.GetChampion( 3 ) );
        championIcon5.sprite = Resources.Load<Sprite>( "Icons/champion/" + data.GetChampion( 4 ) );
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