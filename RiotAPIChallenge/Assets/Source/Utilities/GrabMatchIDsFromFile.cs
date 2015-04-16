using UnityEngine;
using System.Collections.Generic;
using System.IO;

public static class GrabMatchIDsFromFile
{
    /// <summary>
    /// Parses a text document that holds our stored list of urf match id's and returns a random number of them based upon parameters.
    /// </summary>
    /// <param name="numberOfMatches"> the number of random match id's you wish to get back. </param>
    /// <returns></returns>
    public static List<long> FetchRandomMatchIDs( int numberOfMatchIds=8 )
    {
        List<long> listToReturn = new List<long>();

        if (!File.Exists(@"Assets/Resources/MatchIDList/MatchIDList.txt"))
        {
            File.Create(@"Assets/Resources/MatchIDList/MatchIDList.txt");
        }

        string [] allMatchIds = File.ReadAllLines(@"Assets/Resources/MatchIDList/MatchIDList.txt");

        if(allMatchIds.Length > 0)
        {
            for (int i = 0; i < numberOfMatchIds; ++i)
            {
                listToReturn.Add(long.Parse(allMatchIds[Random.Range(0, (allMatchIds.Length - 1))]));
            }
        }
        else
        {
            Debug.LogError("Failed to read matchID's from file or file is empty.");
        }

        return listToReturn;            
    }
}

