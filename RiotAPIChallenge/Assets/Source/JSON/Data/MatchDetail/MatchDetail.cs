using System;
using System.Collections.Generic;

public class MatchDetail
{
    #region Private Constants

    /// <summary>
    /// 
    /// </summary>
    public static class PropertyNames
    {
        public static readonly String MapId = "mapId";
        public static readonly String MatchCreation = "matchCreation";
        public static readonly String MatchDuration = "matchDuration";
        public static readonly String MatchId = "matchId";
        public static readonly String MatchMode = "matchMode";
        public static readonly String MatchType = "matchType";
        public static readonly String MatchVersion = "matchVersion";
        public static readonly String ParticipantIdentities = "participantIdentities";
        public static readonly String Participants = "participants";
        public static readonly String PlatformId = "platformId";
        public static readonly String QueueType = "queueType";
        public static readonly String Region = "region";
        public static readonly String Season = "season";
        public static readonly String Teams = "teams";
        public static readonly String Timeline = "timeline";
    }

    #endregion

    #region Private Variables

    /// <summary>
    /// Match map ID
    /// </summary>
    private int mapId;

    /// <summary>
    /// Match creation time. Designates when the team select lobby is created and/or the match is made through match making, not when the game actually starts.
    /// </summary>
    private long matchCreation;

    /// <summary>
    /// Match duration
    /// </summary>
    private long matchDuration;

    /// <summary>
    /// ID of the match
    /// </summary>
    private long matchId;

    /// <summary>
    /// Match mode (Legal values: CLASSIC, ODIN, ARAM, TUTORIAL, ONEFORALL, ASCENSION, FIRSTBLOOD, KINGPORO)
    /// </summary>
    private string matchMode;
        
    /// <summary>
    /// Match type (Legal values: CUSTOM_GAME, MATCHED_GAME, TUTORIAL_GAME)
    /// </summary>
    private string matchType;
        
    /// <summary>
    /// Match version
    /// </summary>
    private string matchVersion;
        
    /// <summary>
    /// Participant identity information
    /// </summary>
    private ParticipantIdentity[] participantIdentities;	
        
    /// <summary>
    /// Participant information
    /// </summary>
    private Participant[] participants;
        
    /// <summary>
    /// Platform ID of the match
    /// </summary>
    private string platformId;
        
    /// <summary>
    /// Match queue type (Legal values: CUSTOM, NORMAL_5x5_BLIND, RANKED_SOLO_5x5, RANKED_PREMADE_5x5, BOT_5x5, NORMAL_3x3, RANKED_PREMADE_3x3, NORMAL_5x5_DRAFT, 
    ///                                 ODIN_5x5_BLIND, ODIN_5x5_DRAFT, BOT_ODIN_5x5, BOT_5x5_INTRO, BOT_5x5_BEGINNER, BOT_5x5_INTERMEDIATE, RANKED_TEAM_3x3, 
    ///                                 RANKED_TEAM_5x5, BOT_TT_3x3, GROUP_FINDER_5x5, ARAM_5x5, ONEFORALL_5x5, FIRSTBLOOD_1x1, FIRSTBLOOD_2x2, SR_6x6, URF_5x5, 
    ///                                 ONEFORALL_MIRRORMODE_5x5, BOT_URF_5x5, NIGHTMARE_BOT_5x5_RANK1, NIGHTMARE_BOT_5x5_RANK2, NIGHTMARE_BOT_5x5_RANK5, ASCENSION_5x5, 
    ///                                 HEXAKILL, KING_PORO_5x5, COUNTER_PICK)
    /// </summary>
    private string queueType;
        
    /// <summary>
    /// Region where the match was played
    /// </summary>
    private string region;
        
    /// <summary>
    /// Season match was played (Legal values: PRESEASON3, SEASON3, PRESEASON2014, SEASON2014, PRESEASON2015, SEASON2015)
    /// </summary>
    private string season;
        
    /// <summary>
    /// Team information
    /// </summary>
    // private List<Team> teams;
        
    /// <summary>
    /// Match timeline data (not included by default)
    /// </summary>
    //private Timeline timeline;

    #endregion

    #region Constructor

    /// <summary>
    /// Default Constructor
    /// </summary>
    public MatchDetail()
    {

    }

    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// Match map ID
    /// </summary>
    public int MapId
    {
        get 
        { 
            return this.mapId; 
        }
        set 
        { 
            this.mapId = value; 
        }
    }

    /// <summary>
    /// Match creation time. Designates when the team select lobby is created and/or the match is made through match making, not when the game actually starts.
    /// </summary>
    public long MatchCreation
    {
        get 
        { 
            return this.matchCreation; 
        }
        set 
        { 
            this.matchCreation = value; 
        }
    }

    /// <summary>
    /// Match duration
    /// </summary>
    public long MatchDuration
    {
        get
        {
            return this.matchDuration;
        }
        set
        {
            this.matchDuration = value;
        }
    }

    /// <summary>
    /// ID of the match
    /// </summary>
    public long MatchId
    {
        get
        {
            return this.matchId;
        }
        set
        {
            this.matchId = value;
        }
    }

    /// <summary>
    /// Match mode (Legal values: CLASSIC, ODIN, ARAM, TUTORIAL, ONEFORALL, ASCENSION, FIRSTBLOOD, KINGPORO)
    /// </summary>
    public string MatchMode
    {
        get
        {
            return this.matchMode;
        }
        set
        {
            this.matchMode = value;
        }
    }

    /// <summary>
    /// Match type (Legal values: CUSTOM_GAME, MATCHED_GAME, TUTORIAL_GAME)
    /// </summary>
    public string MatchType
    {
        get
        {
            return this.matchType;
        }
        set
        {
            this.matchType = value;
        }
    }

    /// <summary>
    /// Match version
    /// </summary>
    public string MatchVersion
    {
        get
        {
            return this.matchVersion;
        }
        set
        {
            this.matchVersion = value;
        }
    }
       
    /// <summary>
    /// Participant identity information
    /// </summary>
    public ParticipantIdentity[] ParticipantIdentities
    {
        get
        {
            return this.participantIdentities;
        }
        set
        {
            this.participantIdentities = value;
        }
    }
        
    /// <summary>
    /// Participant information
    /// </summary>
    public Participant[] Participants
    {
        get
        {
            return this.participants;
        }
        set
        {
            this.participants = value;
        }
    }

    /// <summary>
    /// Platform ID of the match
    /// </summary>
    public string PlatformId
    {
        get
        {
            return this.platformId;
        }
        set
        {
            this.platformId = value;
        }
    }

    /// <summary>
    /// Match queue type (Legal values: CUSTOM, NORMAL_5x5_BLIND, RANKED_SOLO_5x5, RANKED_PREMADE_5x5, BOT_5x5, NORMAL_3x3, RANKED_PREMADE_3x3, NORMAL_5x5_DRAFT, 
    ///                                 ODIN_5x5_BLIND, ODIN_5x5_DRAFT, BOT_ODIN_5x5, BOT_5x5_INTRO, BOT_5x5_BEGINNER, BOT_5x5_INTERMEDIATE, RANKED_TEAM_3x3, 
    ///                                 RANKED_TEAM_5x5, BOT_TT_3x3, GROUP_FINDER_5x5, ARAM_5x5, ONEFORALL_5x5, FIRSTBLOOD_1x1, FIRSTBLOOD_2x2, SR_6x6, URF_5x5, 
    ///                                 ONEFORALL_MIRRORMODE_5x5, BOT_URF_5x5, NIGHTMARE_BOT_5x5_RANK1, NIGHTMARE_BOT_5x5_RANK2, NIGHTMARE_BOT_5x5_RANK5, ASCENSION_5x5, 
    ///                                 HEXAKILL, KING_PORO_5x5, COUNTER_PICK)
    /// </summary>
    public string QueueType
    {
        get
        {
            return this.queueType;
        }
        set
        {
            this.queueType = value;
        }
    }

    /// <summary>
    /// Region where the match was played
    /// </summary>
    public string Region
    {
        get
        {
            return this.region;
        }
        set
        {
            this.region = value;
        }
    }

    /// <summary>
    /// Season match was played (Legal values: PRESEASON3, SEASON3, PRESEASON2014, SEASON2014, PRESEASON2015, SEASON2015)
    /// </summary>
    public string Season
    {
        get
        {
            return this.season;
        }
        set
        {
            this.season = value;
        }
    }

    /// <summary>
    /// Team information
    /// </summary>
    /*public List<Team> Teams
    {
        get
        {
            return this.teams;
        }
        set
        {
            this.teams = value;
        }
    }*/

    /// <summary>
    /// Match timeline data (not included by default)
    /// </summary>
    /*public Timeline timeline
    {
        get
        {
            return this.timeline;
        }
        set
        {
            this.timeline = value;
        }
    }*/

    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rawResponse"></param>
    /// <returns></returns>
    public static MatchDetail fromJSON(object rawResponse)
    {
        if (rawResponse is String)
        {
            String json = (String)rawResponse;
            JsonFx.Json.JsonReader reader = JSONUtils.getJsonReader(json);

            MatchDetail matchDetail = new MatchDetail();
            matchDetail = reader.Deserialize<MatchDetail>();

            return matchDetail;
        }

        return new MatchDetail();
    }
}

