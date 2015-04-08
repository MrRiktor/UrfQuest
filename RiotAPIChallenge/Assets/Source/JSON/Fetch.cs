using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using JsonFx.Json;

public class Fetch
{
    private WWW www;
    private CallbackSuccessHandler successCallback;
    private CallbackFailureHandler failureCallback;
    private RawResponse rawResponse;
    /// <summary>
    /// 
    /// </summary>
    public Fetch( CallbackSuccessHandler callback, CallbackFailureHandler failCallback, String url, RawResponse rawResponse)
    {
        this.failureCallback = failCallback;
        this.successCallback = callback;
        this.rawResponse = rawResponse;

        www = new WWW( url );
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IEnumerator WaitForUrlData()
    {
        yield return www;

        if ( !string.IsNullOrEmpty( www.error ) && ( failureCallback != null ) )
        {
            failureCallback( www.error );
        }
        else
        {
            string rawServerResponse = www.text;
            //object convertedResponse =;

            if ( successCallback != null )
            {
                successCallback( rawResponse( rawServerResponse ) );
            }
        }

        www.Dispose();
        www = null;
    }
}