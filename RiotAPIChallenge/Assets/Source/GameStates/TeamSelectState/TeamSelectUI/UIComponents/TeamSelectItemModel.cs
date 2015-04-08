#region File Header

/**
 *   File Name:                 TeamSelectItemModel.cs
 *   Author:                    Vincent Biancardi
 *   Creation Date:             April 8, 2015
 */

#endregion

using UnityEngine;
using System.Collections;
using System;

public class TeamSelectItemModel : MonoBehaviour
{
    #region Variables

    private Int32 matchID;

    private Int32 championID1;

    private Int32 championID2;

    private Int32 championID3;

    private Int32 championID4;
    
    private Int32 championID5;
    
    #endregion

    #region Accessors/Mutators

    public Int32 MatchID
    {
        get
        {
            return matchID;
        }
        set
        {
            matchID = value;
            Messenger<Int32>.Broadcast( MessengerEventTypes.TSI_MATCHID_CHANGE, matchID );
        }
    }

    public Int32 ChampionID1
    {
        get
        {
            return championID1;
        }
        set
        {
            championID1 = value;
            Messenger<Int32>.Broadcast( MessengerEventTypes.TSI_CHAMPIONID1_CHANGE, championID1 );
        }
    }

    public Int32 ChampionID2
    {
        get
        {
            return championID2;
        }
        set
        {
            championID2 = value;
            Messenger<Int32>.Broadcast( MessengerEventTypes.TSI_CHAMPIONID2_CHANGE, championID2 );
        }
    }

    public Int32 ChampionID3
    {
        get
        {
            return championID3;
        }
        set
        {
            championID3 = value;
            Messenger<Int32>.Broadcast( MessengerEventTypes.TSI_CHAMPIONID3_CHANGE, championID3 );
        }
    }

    public Int32 ChampionID4
    {
        get
        {
            return championID4;
        }
        set
        {
            championID4 = value;
            Messenger<Int32>.Broadcast( MessengerEventTypes.TSI_CHAMPIONID4_CHANGE, championID4 );
        }
    }

    public Int32 ChampionID5
    {
        get
        {
            return championID5;
        }
        set
        {
            championID5 = value;
            Messenger<Int32>.Broadcast( MessengerEventTypes.TSI_CHAMPIONID5_CHANGE, championID5 );
        }
    }

    #endregion
}