using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ProgressionView : MonoBehaviour
{
    [SerializeField]
    private Image mainImage;

    [SerializeField]
    private GameObject EnemyPortraiItem;

    [SerializeField]
    private GridLayoutGroup grid;

    [SerializeField]
    private Text StoryText;

    [SerializeField]
    private Scrollbar scrollBar;

    [SerializeField]
    private Image trys1;

    [SerializeField]
    private Image trys2;

    [SerializeField]
    private Sprite failed;

    [SerializeField]
    private GridLayoutGroup progressGrid;

    [SerializeField]
    private Text scoreText;

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

    /// <summary>
    /// Handles the play button press
    /// </summary>
    public void OnContinueHandler( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.BATTLE );
    }

    public void OnQuitHandler( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.INTRO );
    }
}