#region File Header

/*******************************************************************************
 * Author: Vincent "Sabin" Biancardi
 * Filename: IntroView.cs
 * Date Created: 4/10/2015 6:47PM EST
 * 
 * Description: The intro view of the application
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 8:13 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

#endregion

public class IntroView : MonoBehaviour
{
    #region Private Variables

    #region SerializeFields

    /// <summary>
    /// The play button GameObject
    /// </summary>
    [SerializeField]
    private Button playButton;

    /// <summary>
    /// The scores button GameObject
    /// </summary>
    [SerializeField]
    private Button scoresButton;

    /// <summary>
    /// The about button game object
    /// </summary>
    [SerializeField]
    private Button aboutButton;

    /// <summary>
    /// The katarina spinning gif gameobject
    /// </summary>
    [SerializeField]
    private GameObject Spinner;

    /// <summary>
    /// the loading image game object
    /// </summary>
    [SerializeField]
    private Image loadingImage;

    /// <summary>
    /// the loading text game object
    /// </summary>
    [SerializeField]
    private Text loadingText;

    /// <summary>
    /// the sprite list that is being animated
    /// </summary>
    [SerializeField]
    private List<Sprite> imgAnim = new List<Sprite>();

    #endregion

    /// <summary>
    ///  the elapsed time 
    /// </summary>
    private Single elapsedTime = 0.0f;
    
    /// <summary>
    /// the image index of the imgAnim
    /// </summary>
    private Int32 imgIndx = 0;

    /// <summary>
    /// An instance of the championDBmanager.
    /// </summary>
    private ChampionDBManager championDBManager;

    #endregion

    #region Native Unity Functionality

    /// <summary>
    /// Used to initialize this monobehavior
    /// </summary>
    void Start( )
    {
        loadingImage.sprite = imgAnim [ imgIndx ];
        championDBManager = ChampionDBManager.GetInstance( );
        GameData.Score = 0;
        GameData.CurrentLevel = 0;
        GameData.Strikes = 0;
        GameData.Victorious = false;
    }

    /// <summary>
    /// Updates on a consisten iteration.
    /// </summary>
    void Update()
    {
        if ( championDBManager.ChampionDBReady && !playButton.gameObject.activeSelf )
        {
            playButton.gameObject.SetActive( true );
            scoresButton.gameObject.SetActive( true );
            aboutButton.gameObject.SetActive( true );
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

    #region Public Methods

    /// <summary>
    /// Handles the play button press
    /// </summary>
    public void OnPlayHandler( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.TEAMSELECT );
    }

    /// <summary>
    /// Handles the scores button press
    /// </summary>
    public void OnScoresHandler( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.SCOREBOARD );
    }

    /// <summary>
    /// Handles the about button press.
    /// </summary>
    public void OnAboutHandler( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.ABOUT );
    }

    #endregion
}