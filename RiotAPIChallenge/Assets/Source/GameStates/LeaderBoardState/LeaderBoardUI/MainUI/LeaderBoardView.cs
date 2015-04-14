using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeaderBoardView : MonoBehaviour
{

    [SerializeField]
    GridLayoutGroup grid;

    [SerializeField]
    GameObject LEADERBOARDITEM;

    [SerializeField]
    GameObject ScoreBoardPanel;

    [SerializeField]
    GameObject InputPanel;

    [SerializeField]
    Text usernameText;

    [SerializeField]
    Text scoreText;

    public StyledComboBox comboBox;

    ///Fill in your server data here.
    private string privateKey = "e733fdbe-1b86-406c-88fc-c8aa9c874679";
    private string TopScoresURL = "http://urfquest.lolinactive.com/TopScores.php";

    //Don't forget the question marks!
    private string AddScoreURL = "http://urfquest.lolinactive.com/AddScore.php?";
    private string RankURL = "http://urfquest.lolinactive.com/GetRank.php?";
    
    private string username;
    private string region;
    private int highscore;
    private int rank;

    void Start( )
    {
        if ( GameData.Score == 0.0f )
        {
            ScoreBoardPanel.SetActive( true );
            InputPanel.SetActive( false );
            StartCoroutine( GetTopScores( ) );
        }
        else
        {
            ScoreBoardPanel.SetActive( false );
            InputPanel.SetActive( true );
            scoreText.text = ((int)GameData.Score).ToString();
            comboBox.AddItems( "NA", "EUW", "EUNE", "BR", "TR", "RU", "LAN", "LAS", "OCE", "KR" );
        }
    }

    public void HandleBack( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.INTRO );
    }

    public void HandleSubmit( )
    {
        region = comboBox.SelectedItem.GetText( ).text;
        username = usernameText.text;
        highscore = (int)GameData.Score;
        StartCoroutine( AddScore( username, region, highscore ) );
        GameData.Score = 0;
        GameData.CurrentLevel = 0;
    }

    ///Our IEnumerators
    IEnumerator AddScore( string name, string region, int score )
    {
        string hash = Md5Sum( name + region + score + privateKey );

        WWW ScorePost = new WWW( AddScoreURL + "name=" + WWW.EscapeURL( name ) + "&region=" + WWW.EscapeURL( region ) + "&score=" + score + "&hash=" + hash ); //Post our score
        yield return ScorePost; // The function halts until the score is posted.

        if ( ScorePost.error == null )
        {
            StartCoroutine( GrabRank( name ) ); // If the post is successful, the rank gets grabbed next.
        }
        else
        {
            Debug.LogError( ScorePost.error );
        }
    }

    IEnumerator GrabRank( string name )
    {
        //Try and grab the Rank
        WWW RankGrabAttempt = new WWW( RankURL + "name=" + WWW.EscapeURL( name ) );

        yield return RankGrabAttempt;

        if ( RankGrabAttempt.error == null )
        {
            rank = System.Int32.Parse( RankGrabAttempt.text ); // Assign the rank to our variable. We could also use a TryParse and write an error dialogue.
            StartCoroutine( GetTopScores( ) ); // Get our top scores
        }
        else
        {
            Debug.LogError( RankGrabAttempt.error );
        }
    }

    IEnumerator GetTopScores( )
    {
        WWW GetScoresAttempt = new WWW( TopScoresURL );
        yield return GetScoresAttempt;

        if ( GetScoresAttempt.error != null )
        {
            Debug.LogError( GetScoresAttempt.error );
        }
        else
        {
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
            ScoreBoardPanel.SetActive( true );
        }
    }

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
}