#region File Header

/**
 *   File Name:                 TeamSelectView.cs
 *   Author:                    Vincent Biancardi
 *   Creation Date:             April 8, 2015
 */

#endregion

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TeamSelectView : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private GridLayoutGroup grid;
    
    [SerializeField]
    private ScrollRect scrollRect;
    
    [SerializeField]
    private Scrollbar scrollBar;

    [SerializeField]
    private GameObject TeamSelectItem;

    [SerializeField]
    private Button continueButton;

    [SerializeField]
    private Image champ1Portrait;

    [SerializeField]
    private Image champ2Portrait;

    [SerializeField]
    private Image champ3Portrait;

    [SerializeField]
    private Image champ4Portrait;

    [SerializeField]
    private Image champ5Portrait;

    #endregion

    #region Unity Methods

    void Start( )
    {
        continueButton.gameObject.SetActive( false );
    }

    #endregion

    #region UI Methods

    /// <summary>
    /// Adds a UI Game Object to the grid
    /// </summary>
    /// <param name="item">the item being added</param>
    public void AddParty( Party party )
    {
        GameObject item = ( GameObject )Instantiate( TeamSelectItem, Vector3.zero, Quaternion.identity );
        
        if ( item == null || item.GetComponent<TeamSelectItem>( ) == null )
            return;

        TeamSelectItem itemScript = item.GetComponent<TeamSelectItem>( );
        itemScript.InitData( party.MatchID, party.PartyMembers[0].Icon, party.PartyMembers[1].Icon, 
            party.PartyMembers[2].Icon, party.PartyMembers[3].Icon, party.PartyMembers[4].Icon );

        item.transform.SetParent( grid.transform );
        item.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        item.transform.localPosition = Vector3.zero;
        
        if ( scrollRect.verticalScrollbar.size == 1 )
            scrollBar.gameObject.SetActive( false );
        else
            scrollBar.gameObject.SetActive( true );
    }

    public void UpdateParty( Party party )
    {
        champ1Portrait.sprite = party.PartyMembers [ 0 ].Portrait;
        champ2Portrait.sprite = party.PartyMembers [ 1 ].Portrait;
        champ3Portrait.sprite = party.PartyMembers [ 2 ].Portrait;
        champ4Portrait.sprite = party.PartyMembers [ 3 ].Portrait;
        champ5Portrait.sprite = party.PartyMembers [ 4 ].Portrait;
    }

    public void EnableContinue( )
    {
        continueButton.gameObject.SetActive( true );
    }

    #endregion
}