#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: Fetch.cs
 * Date Created: 4/11/2015 8:28PM EST
 * 
 * Description: Used for making WWW calls to a given url.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;
using UnityEngine;
using System.Collections;

#endregion

#region Public Delegates

public delegate void CallbackSuccessHandler(object Object);
public delegate void CallbackFailureHandler(string errorMessage);
public delegate object RawResponse(object obj);

#endregion

public class Fetch
{
    #region Private Variables

    /// <summary>
    /// The WWW instance we can store our calls in.
    /// </summary>
    private WWW www;

    /// <summary>
    /// The reference to the success handler
    /// </summary>
    private CallbackSuccessHandler successCallback;
    
    /// <summary>
    /// The reference to the failure handler
    /// </summary>
    private CallbackFailureHandler failureCallback;

    /// <summary>
    /// the raw response reference. (Typically is a FromJSON() call on the data object.)
    /// </summary>
    private RawResponse rawResponse;

    #endregion

    #region Constructors

    /// <summary>
    /// Default Constructor
    /// </summary>
    public Fetch(CallbackSuccessHandler callback, CallbackFailureHandler failCallback, String url, RawResponse rawResponse)
    {
        this.failureCallback = failCallback;
        this.successCallback = callback;
        this.rawResponse = rawResponse;

        www = new WWW(url);
    }

    /// <summary>
    /// A fetch that parses champion data from a file.
    /// </summary>
    public Fetch(CallbackSuccessHandler callback, CallbackFailureHandler failCallback, RawResponse rawResponse)
    {
        this.failureCallback = failCallback;
        this.successCallback = callback;
        this.rawResponse = rawResponse;

        ParseFromFile();
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Waits for the URL data to be returned.
    /// </summary>
    /// <returns></returns>
    public IEnumerator WaitForUrlData()
    {
        yield return www;

        if (!string.IsNullOrEmpty(www.error) && (failureCallback != null))
        {
            failureCallback(www.error);
            Debug.Log(www.error);
        }
        else
        {
            string rawServerResponse = www.text;
            //object convertedResponse =;

            if (successCallback != null)
            {
                successCallback(rawResponse(rawServerResponse));
            }
        }

        www.Dispose();
        www = null;
    }

    /// <summary>
    /// Parses champion data from a stored json file.
    /// </summary>
    public void ParseFromFile()
    {
        string[] json = System.IO.File.ReadAllLines(@"Assets/Resources/BackupChampionData/champion.json");

        if (json == null)
        {
            failureCallback("json string is null.");
        }
        else
        {
            if (successCallback != null)
            {
                if (json.Length == 1)
                {
                    successCallback(rawResponse(json[0]));
                }
            }
        }
    }

    #endregion
}