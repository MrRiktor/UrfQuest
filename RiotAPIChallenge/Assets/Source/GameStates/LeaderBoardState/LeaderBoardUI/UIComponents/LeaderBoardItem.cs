using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeaderBoardItem : MonoBehaviour
{
    [SerializeField]
    Text rank;

    [SerializeField]
    Text summonerName;

    [SerializeField]
    Text region;

    [SerializeField]
    Text score;

    public void InitItem( string rank, string summonerName, string region, string score )
    {
        this.rank.text = rank;
        this.summonerName.text = summonerName;
        this.region.text = region;
        this.score.text = score;
    }

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
}