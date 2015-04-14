using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class IntroView : MonoBehaviour
{

    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button scoresButton;

    [SerializeField]
    private GameObject Spinner;

    [SerializeField]
    private Image loadingImage;

    [SerializeField]
    private Text loadingText;

    [SerializeField]
    private List<Sprite> imgAnim = new List<Sprite>();

    private Single elapsedTime = 0.0f;
    private Int32 imgIndx = 0;
    private ChampionDBManager championDBManager;

    #region Unity Methods

    void Start( )
    {
        loadingImage.sprite = imgAnim [ imgIndx ];
        championDBManager = ChampionDBManager.GetInstance( );
    }

    void Update()
    {
        if ( championDBManager.ChampionDBReady && !playButton.gameObject.activeSelf )
        {
            playButton.gameObject.SetActive( true );
            scoresButton.gameObject.SetActive( true );
            Spinner.SetActive( false );
        }
        else if ( !playButton.gameObject.activeSelf )
        {
            elapsedTime += Time.deltaTime;
            if ( elapsedTime >= 0.05f )
            {
                imgIndx++;
                if ( imgIndx >= imgAnim.Count )
                    imgIndx = 0;

                loadingImage.sprite = imgAnim [ imgIndx ];
                elapsedTime = 0.0f;
            }
        }
    }

    #endregion

    /// <summary>
    /// Handles the play button press
    /// </summary>
    public void OnPlayHandler( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.TEAMSELECT );
    }

    public void OnScoresHandler( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.SCOREBOARD );
    }

}