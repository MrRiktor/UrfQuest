#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: GrabMatchIDsFromFile.cs
 * Date Created: 4/15/2015
 * 
 * Description: A static class used for fetching matchID's from our text file.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using System.Collections.Generic;

#endregion

public static class GrabMatchIDsFromFile
{
    #region Public Methods

    /// <summary>
    /// Parses a text document that holds our stored list of urf match id's and returns a random number of them based upon parameters.
    /// </summary>
    /// <param name="numberOfMatches"> the number of random match id's you wish to get back. </param>
    /// <returns></returns>
    public static List<long> FetchRandomMatchIDs( int numberOfMatchIds=8 )
    {
        List<long> listToReturn = new List<long>();

        TextAsset text = Resources.Load<TextAsset>("MatchIDList/MatchIDList");

        string[] delims = { "\r\n" };

        string[] allMatchIds = text.text.Split(delims, System.StringSplitOptions.None);

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

    #endregion
}

