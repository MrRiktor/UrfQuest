#region File Header

/*******************************************************************************
 * Author: Vincent "Sabin" Biancardi
 * Filename: ProgressionView.cs
 * Date Created: 4/11/2015 6:50PM EST
 * 
 * Description: The progression view of the game.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 10:13 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using UnityEngine.UI;
using System;

#endregion

public class ProgressionView : MonoBehaviour
{
    #region Private Variables

    #region SerializeFields

    /// <summary>
    /// The mainImage gameobject
    /// </summary>
    [SerializeField]
    private Image mainImage;

    /// <summary>
    /// the enemyportrait item game object
    /// </summary>
    [SerializeField]
    private GameObject EnemyPortraiItem;

    /// <summary>
    ///  The gridlayoutgroup of the enemy portraits.
    /// </summary>
    [SerializeField]
    private GridLayoutGroup grid;

    /// <summary>
    /// the story text gameobject
    /// </summary>
    [SerializeField]
    private Text StoryText;

    /// <summary>
    /// the scroll bar of the story text
    /// </summary>
    [SerializeField]
    private Scrollbar scrollBar;

    /// <summary>
    /// the try 1 gameobject
    /// </summary>
    [SerializeField]
    private Image trys1;

    /// <summary>
    /// the try 2 gameobject
    /// </summary>
    [SerializeField]
    private Image trys2;

    /// <summary>
    /// The try 3 gameobject
    /// </summary>
    [SerializeField]
    private Sprite failed;

    /// <summary>
    /// the progress bar gridlayoutgroup
    /// </summary>
    [SerializeField]
    private GridLayoutGroup progressGrid;

    /// <summary>
    /// the score text 
    /// </summary>
    [SerializeField]
    private Text scoreText;

    #endregion

    #endregion

    #region Native Unity Functionality

    /// <summary>
    /// used to initialize this Monobehaviour.
    /// </summary>
    void Start( )
    {
        scoreText.text = GameData.Score.ToString();
        Stage curStage = GameData.StageMap.Stages [ GameData.CurrentLevel ];

        mainImage.sprite = Resources.Load<Sprite>( curStage.StageImage );

        StoryText.text = curStage.StageStory;
        scrollBar.value = 1;

        for ( Int32 i = 0; i < curStage.Enemies.Length; i++ )
        {
            Enemy curEnemy = curStage.Enemies [ i ];

            GameObject item = ( GameObject )Instantiate( EnemyPortraiItem, Vector3.zero, Quaternion.identity );

            if ( item == null || item.GetComponent<EnemyPortraitItem>( ) == null )
                return;

            EnemyPortraitItem itemScript = item.GetComponent<EnemyPortraitItem>( );
            itemScript.SetEnemyPortrait( curEnemy.Icon );

            item.transform.SetParent( grid.transform );
            item.transform.localScale = new Vector3( 1.0f, 1.0f, 1.0f );
            item.transform.localPosition = Vector3.zero;
        }

        if ( GameData.Strikes == 1 )
        {
            trys1.sprite = failed;
        }
        else if ( GameData.Strikes == 2 )
        {
            trys1.sprite = failed;
            trys2.sprite = failed;
        }

        Transform progressTrans = progressGrid.transform.GetChild( GameData.CurrentLevel );
        Image progressImage = progressTrans.GetComponent<Image>( );
        progressImage.color = new Color( 255, 255, 255, 255 );

    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Handles the play button press
    /// </summary>
    public void OnContinueHandler( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.BATTLE );
    }

    /// <summary>
    /// Handles the quit button press.
    /// </summary>
    public void OnQuitHandler( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.INTRO );
    }

    #endregion
}