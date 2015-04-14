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

    void Start( )
    {
        Stage curStage = GameData.StageMap.Stages [ GameData.CurrentLevel ];

        mainImage.sprite = Resources.Load<Sprite>( curStage.StageImage );

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


    }

    /// <summary>
    /// Handles the play button press
    /// </summary>
    public void OnContinueHandler( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.BATTLE );
    }
}