#region File Header

/*******************************************************************************
 * Author: Vincent "Sabin" Biancardi
 * Filename: LeaderBoardView.cs
 * Date Created: 4/14/2015 4:05PM EST
 * 
 * Description: The leaderboard view.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 8:13 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

#endregion

public class LeaderBoardView : MonoBehaviour
{
    #region Public Variables

    #region SerializeFields

    /// <summary>
    /// the grid gameobject
    /// </summary>
    [SerializeField]
    GridLayoutGroup grid;

    /// <summary>
    /// the leaderboard item game object
    /// </summary>
    [SerializeField]
    GameObject LEADERBOARDITEM;

    /// <summary>
    /// the scoreboard panel gameobject
    /// </summary>
    [SerializeField]
    GameObject ScoreBoardPanel;

    /// <summary>
    /// The input panel gameobject
    /// </summary>
    [SerializeField]
    GameObject InputPanel;

    /// <summary>
    /// The username text gameobject
    /// </summary>
    [SerializeField]
    Text usernameText;

    /// <summary>
    /// The score text gameobject
    /// </summary>
    [SerializeField]
    Text scoreText;

    /// <summary>
    /// The win text gameobject
    /// </summary>
    [SerializeField]
    Text winText;

    /// <summary>
    /// The win panel gameobject
    /// </summary>
    [SerializeField]
    GameObject winPanel;

    /// <summary>
    /// The Input field for entering
    /// your name
    /// </summary>
    [SerializeField]
    InputField inputField;

    /// <summary>
    /// The button for submitting
    /// your high score
    /// </summary>
    [SerializeField]
    Button submitButton;

    #endregion

    /// <summary>
    /// The text when you win.
    /// </summary>
    private const string WIN_TEXT = "You have defeated Urf and brought normalcy back to Summoner's Rift!  Way to ruin a great game type newb…";
    
    /// <summary>
    /// The text when you lose.
    /// </summary>
    private const string LOSE_TEXT = "Wow... you my friend do not deal TONS OF DAMAGE on a daily basis. Urf is still rampant!";

    /// <summary>
    /// 
    /// </summary>
    public StyledComboBox comboBox;

    #region Database

    /// <summary>
    /// Fill in your server data here.
    /// </summary>
    private string privateKey = "KEY_USED_IN_DB";
    
    /// <summary>
    /// The top score url
    /// </summary>
    private string TopScoresURL = "http://urfquest.lolinactive.com/TopScores.php";

    /// <summary>
    /// The add score url - Don't forget the question marks!
    /// </summary>
    private string AddScoreURL = "http://urfquest.lolinactive.com/AddScore.php?";
    
    /// <summary>
    /// The rank url - Don't forget the question marks!
    /// </summary>
    private string RankURL = "http://urfquest.lolinactive.com/GetRank.php?";

    #endregion

    /// <summary>
    /// the user name on the high score
    /// </summary>
    private string username;
   
    /// <summary>
    /// the region the summoner belongs to
    /// </summary>
    private string region;
    
    /// <summary>
    /// the players score.
    /// </summary>
    private int highscore;
    
    /// <summary>
    /// the rank they achieved in the high score table.
    /// </summary>
    private int rank;

    #endregion

    #region Native Unity Functionality

    /// <summary>
    /// Used for initialization.
    /// </summary>
    void Start( )
    {
        //if ( GameData.Score == 0.0f )
        //{
        //    ScoreBoardPanel.SetActive( true );
        //    InputPanel.SetActive( false );
        //    winPanel.SetActive( false );
       //     StartCoroutine( GetTopScores( ) );
       // }
       // else
        {
            ScoreBoardPanel.SetActive( false );
            InputPanel.SetActive( true );
            winPanel.SetActive( true );
            submitButton.interactable = false;
            winText.text = GameData.Victorious ? WIN_TEXT : LOSE_TEXT;
            scoreText.text = ((int)GameData.Score).ToString();
            comboBox.AddItems( "NA", "EUW", "EUNE", "BR", "TR", "RU", "LAN", "LAS", "OCE", "KR" );
        }
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// handles the back button click.
    /// </summary>
    public void HandleBack( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.INTRO );
    }

    /// <summary>
    /// Handle the submit button click
    /// </summary>
    public void HandleSubmit( )
    {
        region = comboBox.SelectedItem.GetText( ).text;
        username = usernameText.text;
        highscore = (int)GameData.Score;
        InputPanel.SetActive( false );
        winPanel.SetActive( false );
        StartCoroutine( AddScore( username, region, highscore ) );
    }

    #endregion

    #region Private Methods

    #region IEnumerators

    /// <summary>
    /// Adds the score to the DB
    /// </summary>
    /// <param name="name"> Summoner name </param>
    /// <param name="region"> Summoner's Region </param>
    /// <param name="score"> Player's Score </param>
    /// <returns></returns>
    private IEnumerator AddScore( string name, string region, int score )
    {
        string hash = Md5Sum( name + region + score + privateKey );


        WWW ScorePost = new WWW( AddScoreURL + "name=" +  name  + "&region=" + WWW.EscapeURL( region ) + "&score=" + score + "&hash=" + hash ); //Post our score
        yield return ScorePost; // The function halts until the score is posted.

        if ( ScorePost.error == null )
        {
            Debug.Log( ScorePost.text );
            StartCoroutine( GrabRank( name, region ) ); // If the post is successful, the rank gets grabbed next.
        }
        else
        {
            Debug.LogError( ScorePost.error );
        }
    }

    /// <summary>
    /// grabs the rank from the DB
    /// </summary>
    /// <param name="name"> Summoner name </param>
    /// <param name="region"> Summoner's region </param>
    private IEnumerator GrabRank( string name, string region )
    {
        //Try and grab the Rank
        WWW RankGrabAttempt = new WWW( RankURL + "name=" + WWW.EscapeURL( name ) + "&region=" + WWW.EscapeURL( region ) );

        yield return RankGrabAttempt;

        if ( RankGrabAttempt.error == null )
        {
            Debug.Log( RankGrabAttempt.text );
            rank = System.Int32.Parse( RankGrabAttempt.text ); // Assign the rank to our variable. We could also use a TryParse and write an error dialogue.
            StartCoroutine( GetTopScores( ) ); // Get our top scores
        }
        else
        {
            Debug.LogError( RankGrabAttempt.error );
        }
    }

    /// <summary>
    /// Retrieves the top scores from the DB
    /// </summary>
    private IEnumerator GetTopScores( )
    {
        WWW GetScoresAttempt = new WWW( TopScoresURL );
        yield return GetScoresAttempt;

        if ( GetScoresAttempt.error != null )
        {
            Debug.LogError( GetScoresAttempt.error );
        }
        else
        {
            Debug.Log( GetScoresAttempt.text );
            //Collect up all our data
            string [] textlist = GetScoresAttempt.text.Split( new string [] { "\n", "\t" }, System.StringSplitOptions.RemoveEmptyEntries );

            //Split it into two smaller arrays
            string [] Names = new string [ Mathf.FloorToInt( textlist.Length / 3 ) ];
            string [] Regions = new string [ Names.Length ];
            string [] Scores = new string [ Names.Length ];
            for ( int i = 0; i < textlist.Length; i++ )
            {
                if ( i % 3 == 0 )
                {
                    Names [ Mathf.FloorToInt( i / 3 ) ] = textlist [ i ];
                }
                else if ( i % 3 == 1 )
                {
                    Regions [ Mathf.FloorToInt( i / 3 ) ] = textlist [ i ];
                }
                else
                {
                    Scores [ Mathf.FloorToInt( i / 3 ) ] = textlist [ i ];
                }
            }

            ///Our top 10 scores
            for ( int i = 0; i < Names.Length; i++ )
            {
                GameObject item = ( GameObject )Instantiate( LEADERBOARDITEM, Vector3.zero, Quaternion.identity );

                LeaderBoardItem itemScript = item.GetComponent<LeaderBoardItem>( );
                itemScript.InitItem( (i + 1).ToString(), Names [ i ], Regions [ i ], Scores [ i ] );

                item.transform.SetParent( grid.transform );
                item.transform.localScale = new Vector3( 1.0f, 1.0f, 1.0f );
                item.transform.localPosition = Vector3.zero;
            }

            InputPanel.SetActive( false );
            winPanel.SetActive( false );
            ScoreBoardPanel.SetActive( true );
        }
    }

    #endregion

    /// <summary>
    /// Calculates and verifies 128-bit MD5 hashes
    /// </summary>
    /// <param name="strToEncrypt"> The string to encrypt. </param>
    /// <returns></returns>
    private string Md5Sum( string strToEncrypt )
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding( );
        byte [] bytes = ue.GetBytes( strToEncrypt );

        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider( );
        byte [] hashBytes = md5.ComputeHash( bytes );

        string hashString = "";

        for ( int i = 0; i < hashBytes.Length; i++ )
        {
            hashString += System.Convert.ToString( hashBytes [ i ], 16 ).PadLeft( 2, '0' );
        }

        return hashString.PadLeft( 32, '0' );
    }

    /// <summary>
    /// User to fix proper input
    /// </summary>
    public void FixInputValue( )
    {
        inputField.text = Regex.Replace( inputField.text, "[^a-zA-Z0-9âãäåæçèéêëìíîïðñòóôõøùúûüýþÿı]+", "", RegexOptions.IgnoreCase );
        if ( inputField.text == "" )
        {
            submitButton.interactable = false;
        }
        else
        {
            submitButton.interactable = true;
        }
    }

    #endregion
}