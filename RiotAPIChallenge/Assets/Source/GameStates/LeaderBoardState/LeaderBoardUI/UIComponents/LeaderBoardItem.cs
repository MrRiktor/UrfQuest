#region File Header

/*******************************************************************************
 * Author: Vincent "Sabin" Biancardi
 * Filename: LeaderBoardItem.cs
 * Date Created: 4/14/2015 4:05PM EST
 * 
 * Description: The leaderboard item.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 8:13 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using UnityEngine.UI;

#endregion

public class LeaderBoardItem : MonoBehaviour
{
    #region Private Variables

    #region SerializeFields

    /// <summary>
    /// The rank text Gameobject
    /// </summary>
    [SerializeField]
    Text rank;

    /// <summary>
    /// The summoner name text gameobject
    /// </summary>
    [SerializeField]
    Text summonerName;

    /// <summary>
    /// the region text gameobject
    /// </summary>
    [SerializeField]
    Text region;

    /// <summary>
    /// the score text gameobject
    /// </summary>
    [SerializeField]
    Text score;

    #endregion

    #endregion

    #region Public Methods

    /// <summary>
    /// Init's the leaderboard item.
    /// </summary>
    /// <param name="rank">the rank</param>
    /// <param name="summonerName"> the summonername </param>
    /// <param name="region">the region</param>
    /// <param name="score"> the score </param>
    public void InitItem( string rank, string summonerName, string region, string score )
    {
        this.rank.text = rank;
        this.summonerName.text = summonerName;
        this.region.text = region;
        this.score.text = score;
    }

    /// <summary>
    /// Handles the onClick event.
    /// </summary>
    public void OnClick( )
    {
        if ( Application.isWebPlayer )
        {
            string urlScript = "window.open('" + "http://www.lolking.net/search?name=" + summonerName.text + "&region=" + region.text + "','_blank')";
            Application.ExternalEval( urlScript );
        }
        else
        {
            Application.OpenURL( "http://www.lolking.net/search?name=" + summonerName.text + "&region=" + region.text );
        }
    }

    #endregion
}