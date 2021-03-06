﻿using UnityEngine;
using System.Collections;
using System.IO;



public class FetchMatchIDList : MonoBehaviour 
{    
	// Use this for initialization
	void Start () 
    {
        JSONUtils.initJsonObjectConversion();

        System.DateTime date = System.DateTime.Now;

        for (int i = 0; i < 5; ++i)
        {
            date = date.AddMinutes(-6);
            StartCoroutine(getMatchIDList(DateMath.RoundDateToFive(date)));            
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public IEnumerator getMatchIDList( System.DateTime date )
    {
        string url = "";
        if ( Application.isWebPlayer )
        {
            url = "UrfQuest.php?apiCall=" + RiotAPIConstants.API_CHALLENGE_MATCH_LIST( Region.na, EpochTime.ToEpoch( date ) );
        }
        else
        {
            url = RiotAPIConstants.API_CHALLENGE_MATCH_LIST( Region.na, EpochTime.ToEpoch( date ) );
        }

        Fetch fetch = new Fetch(success,
                                failure, 
                                url,
                                MatchIDList.fromJSON
                                );
        return fetch.WaitForUrlData();

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    private void success( object obj )
    {
        if( obj is MatchIDList )
        {
            WriteOutMatches(obj as MatchIDList);
        }        
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    private void failure(string message)
    {
        Debug.LogError( "Error Message: " + message );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    private void WriteOutMatches( MatchIDList obj )
    {
        if (!File.Exists(@"Assets/Resources/MatchIDList/MatchIDList.txt"))
        {
            File.Create(@"Assets/Resources/MatchIDList/MatchIDList.txt");
        }

        foreach (string line in File.ReadAllLines(@"Assets/Resources/MatchIDList/MatchIDList.txt"))
        {
            foreach (long matchID in obj.IDList)
            {
                if (line.Contains( matchID.ToString() ) )
                {
                    Debug.LogError("Duplicate Found - MatchID: " + matchID);
                    obj.IDList.Remove( matchID );
                    break;
                }
            }
        }

        using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Assets/Resources/MatchIDList/MatchIDList.txt", true))
        {
            foreach (long matchID in obj.IDList)
            {
                Debug.Log("MatchID Written - MatchID: " + matchID);
                file.WriteLine(matchID);
            }
        }

    }
}
