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

    private static Color32 COLOR_GOLD = new Color32( 218, 165, 32, 255 );

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

    [SerializeField]
    private GameObject StatListPanel;


    //Main UIs to Activate

    [SerializeField]
    private GameObject TitlePanel;

    [SerializeField]
    private GameObject HorizontalPanel;

    [SerializeField]
    private GameObject SubmitPanel;


    //Right Side

    [SerializeField]
    private Text champ1AttackText;

    [SerializeField]
    private Text champ1HealthText;

    [SerializeField]
    private Text champ2AttackText;

    [SerializeField]
    private Text champ2HealthText;

    [SerializeField]
    private Text champ3AttackText;

    [SerializeField]
    private Text champ3HealthText;

    [SerializeField]
    private Text champ4AttackText;

    [SerializeField]
    private Text champ4HealthText;

    [SerializeField]
    private Text champ5AttackText;

    [SerializeField]
    private Text champ5HealthText;

    [SerializeField]
    private Text teamAttackText;

    [SerializeField]
    private Text teamHealthText;


    [SerializeField]
    private Image champ1PortraitBackground;

    [SerializeField]
    private Image champ2PortraitBackground;

    [SerializeField]
    private Image champ3PortraitBackground;

    [SerializeField]
    private Image champ4PortraitBackground;

    [SerializeField]
    private Image champ5PortraitBackground;

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

    //Right Side Stats

    [SerializeField]
    private Text Kills;
    [SerializeField]
    private Text Assists;
    [SerializeField]
    private Text Deaths;

    [SerializeField]
    private Text GoldEarned;

    [SerializeField]
    private Text LargestCriticalStrike;

    [SerializeField]
    private Text PhysicalDamageDealtToChampions;
    [SerializeField]
    private Text PhysicalDamageDealt;
    [SerializeField]
    private Text PhysicalDamageTaken;

    [SerializeField]
    private Text MagicDamageDealtToChampions;
    [SerializeField]
    private Text MagicDamageDealt;
    [SerializeField]
    private Text MagicDamageTaken;

    [SerializeField]
    private Text TrueDamageDealtToChampions;
    [SerializeField]
    private Text TrueDamageDealt;
    [SerializeField]
    private Text TrueDamageTaken;

    [SerializeField]
    private Text TotalDamageDealtToChampions;
    [SerializeField]
    private Text TotalDamageDealt;
    [SerializeField]
    private Text TotalDamageTaken;
    [SerializeField]
    private Text TotalHeal;

    [SerializeField]
    private Text KillingSprees;
    [SerializeField]
    private Text LargestKillingSpree;

    [SerializeField]
    private Text LargestMultiKill;
    [SerializeField]
    private Text DoubleKills;
    [SerializeField]
    private Text TripleKills;
    [SerializeField]
    private Text QuadraKills;
    [SerializeField]
    private Text PentaKills;
    [SerializeField]
    private Text UnrealKills;

    [SerializeField]
    private Text MinionsKilled;
    //[SerializeField]
    //private Text NeutralMinionsKilled;
    //[SerializeField]
    //private Text NeutralMinionsKilledEnemyJungle;
    //[SerializeField]
    //private Text NeutralMinionsKilledTeamJungle;

    [SerializeField]
    private Text WardsKilled;
    [SerializeField]
    private Text WardsPlaced;

    private static Image currentSelectedPlayer;

    private static Image CurrentSelectedPlayer
    {
        get
        {
            return currentSelectedPlayer;
        }
    }

    private static void SetCurrentSelectedPlayer( Int32 index, Image backgroundImage )
    {
        if ( currentSelectedPlayer != null )
        {
            currentSelectedPlayer.color = Color.black;
        }
        currentSelectedPlayer = backgroundImage;
        currentSelectedPlayer.color = COLOR_GOLD;
        Messenger<Int32>.Broadcast( MessengerEventTypes.TSUI_PARTY_MEMBER_SELECTED, index );
    }

    #endregion

    #region Unity Methods

    void Start( )
    {
        continueButton.gameObject.SetActive( false );
        TitlePanel.SetActive( false );

        HorizontalPanel.SetActive( false );

        SubmitPanel.SetActive( false );
    }

    #endregion

    #region UI Methods

    /// <summary>
    /// On Champion 1 Portrait Selected
    /// </summary>
    public void OnChampion1Press( )
    {
        SetCurrentSelectedPlayer( 0, champ1PortraitBackground );
    }

    /// <summary>
    /// On Champion 2 Portrait Selected
    /// </summary>
    public void OnChampion2Press( )
    {
        SetCurrentSelectedPlayer( 1, champ2PortraitBackground );
    }

    /// <summary>
    /// On Champion 3 Portrait Selected
    /// </summary>
    public void OnChampion3Press( )
    {
        SetCurrentSelectedPlayer( 2, champ3PortraitBackground );
    }

    /// <summary>
    /// On Champion 4 Portrait Selected
    /// </summary>
    public void OnChampion4Press( )
    {
        SetCurrentSelectedPlayer( 3, champ4PortraitBackground );
    }

    /// <summary>
    /// On Champion 5 Portrait Selected
    /// </summary>
    public void OnChampion5Press( )
    {
        SetCurrentSelectedPlayer( 4, champ5PortraitBackground );
    }

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
        itemScript.InitData( party.MatchID, party.PartyMembers [ 0 ].Icon, party.PartyMembers [ 1 ].Icon,
            party.PartyMembers [ 2 ].Icon, party.PartyMembers [ 3 ].Icon, party.PartyMembers [ 4 ].Icon );

        Boolean firstChild = false;
        if ( grid.transform.childCount == 0 )
            firstChild = true;

        item.transform.SetParent( grid.transform );
        item.transform.localScale = new Vector3( 1.0f, 1.0f, 1.0f );
        item.transform.localPosition = Vector3.zero;

        if ( scrollRect.verticalScrollbar.size == 1 )
            scrollBar.gameObject.SetActive( false );
        else
            scrollBar.gameObject.SetActive( true );

        if ( firstChild )
        {
            itemScript.OnButtonClick( );
            SetCurrentSelectedPlayer( 0, champ1PortraitBackground );
        }


        TitlePanel.SetActive( true );

        HorizontalPanel.SetActive( true );

        SubmitPanel.SetActive( true );
    }

    /// <summary>
    /// Update the right side with the selected party
    /// </summary>
    /// <param name="party">selected party</param>
    /// <param name="maxPartyStats">max party stats of the group of ids</param>
    public void UpdateParty( Party party, MaxPartyStats maxPartyStats )
    {
        champ1Portrait.sprite = party.PartyMembers [ 0 ].Portrait;
        champ2Portrait.sprite = party.PartyMembers [ 1 ].Portrait;
        champ3Portrait.sprite = party.PartyMembers [ 2 ].Portrait;
        champ4Portrait.sprite = party.PartyMembers [ 3 ].Portrait;
        champ5Portrait.sprite = party.PartyMembers [ 4 ].Portrait;

        champ1AttackMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 0 ].AttackDamage / maxPartyStats.MaxPlayerAttack, 1, 1 );
        champ1HealthMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 0 ].HealthPool / maxPartyStats.MaxPlayerHealthPool, 1, 1 );
        champ1AttackText.text = party.PartyMembers [ 0 ].AttackDamage.ToString( );
        champ1HealthText.text = party.PartyMembers [ 0 ].HealthPool.ToString( );


        champ2AttackMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 1 ].AttackDamage / maxPartyStats.MaxPlayerAttack, 1, 1 );
        champ2HealthMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 1 ].HealthPool / maxPartyStats.MaxPlayerHealthPool, 1, 1 );
        champ2AttackText.text = party.PartyMembers [ 1 ].AttackDamage.ToString( );
        champ2HealthText.text = party.PartyMembers [ 1 ].HealthPool.ToString( );

        champ3AttackMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 2 ].AttackDamage / maxPartyStats.MaxPlayerAttack, 1, 1 );
        champ3HealthMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 2 ].HealthPool / maxPartyStats.MaxPlayerHealthPool, 1, 1 );
        champ3AttackText.text = party.PartyMembers [ 2 ].AttackDamage.ToString( );
        champ3HealthText.text = party.PartyMembers [ 2 ].HealthPool.ToString( );

        champ4AttackMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 3 ].AttackDamage / maxPartyStats.MaxPlayerAttack, 1, 1 );
        champ4HealthMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 3 ].HealthPool / maxPartyStats.MaxPlayerHealthPool, 1, 1 );
        champ4AttackText.text = party.PartyMembers [ 3 ].AttackDamage.ToString( );
        champ4HealthText.text = party.PartyMembers [ 3 ].HealthPool.ToString( );

        champ5AttackMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 4 ].AttackDamage / maxPartyStats.MaxPlayerAttack, 1, 1 );
        champ5HealthMeter.rectTransform.localScale = new Vector3( ( Single )party.PartyMembers [ 4 ].HealthPool / maxPartyStats.MaxPlayerHealthPool, 1, 1 );
        champ5AttackText.text = party.PartyMembers [ 4 ].AttackDamage.ToString( );
        champ5HealthText.text = party.PartyMembers [ 4 ].HealthPool.ToString( );

        teamAttackMeter.rectTransform.localScale = new Vector3( ( Single )party.AttackAverage * 5.0f / maxPartyStats.MaxTeamAttack, 1, 1 );
        teamHealthMeter.rectTransform.localScale = new Vector3( ( Single )party.HealthAverage * 5.0f / maxPartyStats.MaxTeamHealthPool, 1, 1 );
        teamAttackText.text = (party.AttackAverage * 5).ToString( );
        teamHealthText.text = (party.HealthAverage * 5).ToString( );
    }

    public void UpdateSelectedPartyMember( ParticipantStats stats )
    {
        Kills.text = stats.Kills.ToString( );
        Assists.text = stats.Assists.ToString( );
        Deaths.text = stats.Deaths.ToString( );

        GoldEarned.text = stats.GoldEarned.ToString( );

        LargestCriticalStrike.text = stats.LargestCriticalStrike.ToString( );

        PhysicalDamageDealtToChampions.text = stats.PhysicalDamageDealtToChampions.ToString( );
        PhysicalDamageDealt.text = stats.PhysicalDamageDealt.ToString( );
        PhysicalDamageTaken.text = stats.PhysicalDamageTaken.ToString( );

        MagicDamageDealtToChampions.text = stats.MagicDamageDealtToChampions.ToString( );
        MagicDamageDealt.text = stats.MagicDamageDealt.ToString( );
        MagicDamageTaken.text = stats.MagicDamageTaken.ToString( );

        TrueDamageDealtToChampions.text = stats.TrueDamageDealtToChampions.ToString( );
        TrueDamageDealt.text = stats.TrueDamageDealt.ToString( );
        TrueDamageTaken.text = stats.TrueDamageTaken.ToString( );

        TotalDamageDealtToChampions.text = stats.TotalDamageDealtToChampions.ToString( );
        TotalDamageDealt.text = stats.TotalDamageDealt.ToString( );
        TotalDamageTaken.text = stats.TotalDamageTaken.ToString( );
        TotalHeal.text = stats.TotalHeal.ToString( );

        KillingSprees.text = stats.KillingSprees.ToString( );
        LargestKillingSpree.text = stats.LargestKillingSpree.ToString( );

        LargestMultiKill.text = stats.LargestMultiKill.ToString( );
        DoubleKills.text = stats.DoubleKills.ToString( );
        TripleKills.text = stats.TripleKills.ToString( );
        QuadraKills.text = stats.QuadraKills.ToString( );
        PentaKills.text = stats.PentaKills.ToString( );
        UnrealKills.text = stats.UnrealKills.ToString( );

        MinionsKilled.text = stats.MinionsKilled.ToString( );
        //NeutralMinionsKilled.text = stats.NeutralMinionsKilled.ToString( );
        //NeutralMinionsKilledEnemyJungle.text = stats.NeutralMinionsKilledEnemyJungle.ToString( );
        //NeutralMinionsKilledTeamJungle.text = stats.NeutralMinionsKilledTeamJungle.ToString( );

        WardsKilled.text = stats.WardsKilled.ToString( );
        WardsPlaced.text = stats.WardsPlaced.ToString( );
    }

    public void EnableContinue( )
    {
        continueButton.gameObject.SetActive( true );
    }

    #endregion
}