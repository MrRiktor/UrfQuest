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

    //Left Side Scroll 

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


    //Main UIs to Activate

    [SerializeField]
    private GameObject TitlePanel;

    [SerializeField]
    private GameObject HorizontalPanel;

    [SerializeField]
    private GameObject SubmitPanel;


    //Right Side

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

    [SerializeField]
    private Image champ1AttackMeter;

    [SerializeField]
    private Image champ1HealthMeter;

    [SerializeField]
    private Image champ2AttackMeter;

    [SerializeField]
    private Image champ2HealthMeter;

    [SerializeField]
    private Image champ3AttackMeter;

    [SerializeField]
    private Image champ3HealthMeter;

    [SerializeField]
    private Image champ4AttackMeter;

    [SerializeField]
    private Image champ4HealthMeter;

    [SerializeField]
    private Image champ5AttackMeter;

    [SerializeField]
    private Image champ5HealthMeter;

    [SerializeField]
    private Image teamAttackMeter;

    [SerializeField]
    private Image teamHealthMeter;

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


        TitlePanel.SetActive( true );

        HorizontalPanel.SetActive( true );

        SubmitPanel.SetActive( true );
    }

    public void UpdateParty( Party party, MaxPartyStats maxPartyStats )
    {
        champ1Portrait.sprite = party.PartyMembers [ 0 ].Portrait;
        champ2Portrait.sprite = party.PartyMembers [ 1 ].Portrait;
        champ3Portrait.sprite = party.PartyMembers [ 2 ].Portrait;
        champ4Portrait.sprite = party.PartyMembers [ 3 ].Portrait;
        champ5Portrait.sprite = party.PartyMembers [ 4 ].Portrait;

        champ1AttackMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 0 ].AttackDamage / maxPartyStats.MaxPlayerAttack, 1, 1 );
        champ1HealthMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 0 ].HealthPool / maxPartyStats.MaxPlayerHealthPool, 1, 1 );

        champ2AttackMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 1 ].AttackDamage / maxPartyStats.MaxPlayerAttack, 1, 1 );
        champ2HealthMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 1 ].HealthPool / maxPartyStats.MaxPlayerHealthPool, 1, 1 );

        champ3AttackMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 2 ].AttackDamage / maxPartyStats.MaxPlayerAttack, 1, 1 );
        champ3HealthMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 2 ].HealthPool / maxPartyStats.MaxPlayerHealthPool, 1, 1 );

        champ4AttackMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 3 ].AttackDamage / maxPartyStats.MaxPlayerAttack, 1, 1 );
        champ4HealthMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 3 ].HealthPool / maxPartyStats.MaxPlayerHealthPool, 1, 1 );

        champ5AttackMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 4 ].AttackDamage / maxPartyStats.MaxPlayerAttack, 1, 1 );
        champ5HealthMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 4 ].HealthPool / maxPartyStats.MaxPlayerHealthPool, 1, 1 );

        teamAttackMeter.rectTransform.localScale = new Vector3( ( Single )party.AttackAverage*5.0f / maxPartyStats.MaxTeamAttack, 1, 1 );
        teamHealthMeter.rectTransform.localScale = new Vector3( ( Single )party.HealthAverage*5.0f / maxPartyStats.MaxTeamHealthPool, 1, 1 );
    }

    public void EnableContinue( )
    {
        continueButton.gameObject.SetActive( true );
    }

    #endregion
}