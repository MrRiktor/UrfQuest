using UnityEngine;
using System.Collections;

class FetchMatch : MonoBehaviour
{
    [SerializeField]
    private int matchID = 1787569113;

    void Start()
    {
        JSONUtils.initJsonObjectConversion();

        StartCoroutine( getMatchIDList() );
    }
        
    /// <summary>
    /// 
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public IEnumerator getMatchIDList()
    {
        Fetch fetch = new Fetch(success, failure, RiotAPIConstants.MATCHv2_2(Region.NorthAmerica, matchID), MatchDetail.fromJSON);
            
        return fetch.WaitForUrlData();
    }

    private void success(object obj)
    {
        if ( obj is MatchDetail )
        {
            Debug.Log( "Test" );
        } 
    }

    private void failure(string message)
    {
        Debug.LogError(message);
    }
}
