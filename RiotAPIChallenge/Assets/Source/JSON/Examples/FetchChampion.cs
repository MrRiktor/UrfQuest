
using UnityEngine;
using System.Collections;

class FetchChampion : MonoBehaviour
{
    [SerializeField]
    private int ChampionID = 17;

    [SerializeField]
    private Renderer renderer;

    void Start()
    {
        JSONUtils.initJsonObjectConversion();

        StartCoroutine( GetChampionByID( ChampionID ) );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public IEnumerator GetChampionByID( int championID )
    {
        //Fetch fetch = new Fetch(success, failure, RiotAPIConstants.MATCHv2_2(Region.NorthAmerica, 1787569113), MatchDetail.fromJSON);
        Fetch fetch = new Fetch(success, failure, RiotAPIConstants.CHAMPION_STATIC_DATA(championID, ChampData.image, Region.NorthAmerica), Champion.fromJSON);

        return fetch.WaitForUrlData();
    }

    private void success(object obj)
    {
        if (obj is Champion)
        {
            StartCoroutine( GrabChampionIcon( (obj as Champion).Name ) );
            Debug.Log("Test");
        }
    }

    private void failure(string message)
    {
        Debug.LogError(message);
    }

    private IEnumerator GrabChampionIcon( string championName )
    {
        //string url = RiotAPIConstants.CHAMPION_ICON_HYPERLINK(championName);
        string url = RiotAPIConstants.CHAMPION_PORTRAIT_HYPERLINK(championName);
        WWW www = new WWW(url);
        yield return www;
        renderer.material.mainTexture = www.texture;
    }
}

