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
    private Text loadingText;

    private List<String> loadingSuffix = new List<String>();
    private Int32 loadingSuffixIndx = 0;
    private Boolean loadingIncrement = true;
    private const Int32 LOADING_INDX_MAX = 3;
    private Single elapsedTime = 0.0f;

    #region Unity Methods

    void Start( )
    {
        loadingSuffix.Add( " " );
        loadingSuffix.Add( " . " );
        loadingSuffix.Add( " . . " );
        loadingSuffix.Add( " . . . " );

    }

    void Update()
    {
        if ( ChampionDBManager.GetInstance( ).ChampionDBReady && !playButton.gameObject.activeSelf )
        {
            playButton.gameObject.SetActive( true );
            loadingText.gameObject.SetActive( false );
        }
        else if ( !playButton.gameObject.activeSelf )
        {
            loadingText.text = "Loading" + loadingSuffix [ loadingSuffixIndx ];

            elapsedTime += Time.deltaTime;
            if ( elapsedTime >= 0.25f )
            {
                if ( loadingIncrement )
                    loadingSuffixIndx++;
                else
                    loadingSuffixIndx--;

                elapsedTime = 0.0f;
            }

            if ( loadingSuffixIndx < 0 )
            {
                loadingSuffixIndx++;
                loadingIncrement = true;
            }

            if ( loadingSuffixIndx > LOADING_INDX_MAX )
            {
                loadingSuffixIndx--;
                loadingIncrement = false;
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
}