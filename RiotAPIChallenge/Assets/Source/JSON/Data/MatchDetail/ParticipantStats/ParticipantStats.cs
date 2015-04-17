#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: ParticipantStats.cs
 * Date Created: 4/11/2015 8:28PM EST
 * 
 * Description: ParticipantStats Data Class
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;

#endregion

public class ParticipantStats
{
    #region Private Constants

    /// <summary>
    /// 
    /// </summary>
    public static class PropertyNames
    {
        public static readonly String Assists = "assists";
        public static readonly String ChampLevel = "champLevel";
        public static readonly String CombatPlayerScore = "combatPlayerScore";
        public static readonly String Deaths = "deaths";
        public static readonly String DoubleKills = "doubleKills";
        public static readonly String FirstBloodAssist = "firstBloodAssist";
        public static readonly String FirstBloodKill = "firstBloodKill";
        public static readonly String FirstInhibitorAssist = "firstInhibitorAssist";
        public static readonly String FirstInhibitorKill = "firstInhibitorKill";
        public static readonly String FirstTowerAssist = "firstTowerAssist";
        public static readonly String FirstTowerKill = "firstTowerKill";
        public static readonly String GoldEarned = "goldEarned";
        public static readonly String GoldSpent = "goldSpent";
        public static readonly String InhibitorKills = "inhibitorKills";
        public static readonly String Item0 = "item0";
        public static readonly String Item1 = "item1";
        public static readonly String Item2 = "item2";
        public static readonly String Item3 = "item3";
        public static readonly String Item4 = "item4";
        public static readonly String Item5 = "item5";
        public static readonly String Item6 = "item6";
        public static readonly String KillingSprees = "killingSprees";
        public static readonly String Kills = "kills";
        public static readonly String LargestCriticalStrike = "largestCriticalStrike";
        public static readonly String LargestKillingSpree = "largestKillingSpree";
        public static readonly String LargestMultiKill = "largestMultiKill";
        public static readonly String MagicDamageDealt = "magicDamageDealt";
        public static readonly String MagicDamageDealtToChampions = "magicDamageDealtToChampions";
        public static readonly String MagicDamageTaken = "magicDamageTaken";
        public static readonly String MinionsKilled = "minionsKilled";
        public static readonly String NeutralMinionsKilled = "neutralMinionsKilled";
        public static readonly String NeutralMinionsKilledEnemyJungle = "neutralMinionsKilledEnemyJungle";
        public static readonly String NeutralMinionsKilledTeamJungle = "neutralMinionsKilledTeamJungle";
        public static readonly String NodeCapture = "nodeCapture";
        public static readonly String NodeCaptureAssist = "nodeCaptureAssist";
        public static readonly String NodeNeutralize = "nodeNeutralize";
        public static readonly String NodeNeutralizeAssist = "nodeNeutralizeAssist";
        public static readonly String ObjectivePlayerScore = "objectivePlayerScore";
        public static readonly String PentaKills = "pentaKills";
        public static readonly String PhysicalDamageDealt = "physicalDamageDealt";
        public static readonly String PhysicalDamageDealtToChampions = "physicalDamageDealtToChampions";
        public static readonly String PhysicalDamageTaken = "physicalDamageTaken";
        public static readonly String QuadraKills = "quadraKills";
        public static readonly String SightWardsBoughtInGame = "sightWardsBoughtInGame";
        public static readonly String TeamObjective = "teamObjective";
        public static readonly String TotalDamageDealt = "totalDamageDealt";
        public static readonly String TotalDamageDealtToChampions = "totalDamageDealtToChampions";
        public static readonly String TotalDamageTaken = "totalDamageTaken";
        public static readonly String TotalHeal = "totalHeal";
        public static readonly String TotalPlayerScore = "totalPlayerScore";
        public static readonly String TotalScoreRank = "totalScoreRank";
        public static readonly String TotalTimeCrowdControlDealt = "totalTimeCrowdControlDealt";
        public static readonly String TotalUnitsHealed = "totalUnitsHealed";
        public static readonly String TowerKills = "towerKills";
        public static readonly String TripleKills = "tripleKills";
        public static readonly String TrueDamageDealt = "trueDamageDealt";
        public static readonly String TrueDamageDealtToChampions = "trueDamageDealtToChampions";
        public static readonly String TrueDamageTaken = "trueDamageTaken";
        public static readonly String VisionWardsBoughtInGame = "visionWardsBoughtInGame";
        public static readonly String WardsKilled = "wardsKilled";
        public static readonly String WardsPlaced = "wardsPlaced";
        public static readonly String Winner = "winner";       
    }

    #endregion

    #region Private Member Variables
        
    /// <summary>
    /// Number of assists
    /// </summary>
    private long assists;
        
    /// <summary>
    /// Champion level achieved
    /// </summary>
    private long champLevel;

    /// <summary>
    /// If game was a dominion game, player's combat score, otherwise 0
    /// </summary>
    private long combatPlayerScore;
        
    /// <summary>
    /// Number of deaths
    /// </summary>
    private long deaths;
        
    /// <summary>
    /// Number of double kills
    /// </summary>
    private long doubleKills;

    /// <summary>
    /// Flag indicating if participant got an assist on first blood
    /// </summary>
    private Boolean firstBloodAssist;

    /// <summary>
    /// Flag indicating if participant got first blood
    /// </summary>
    private Boolean firstBloodKill;

    /// <summary>
    /// Flag indicating if participant got an assist on the first inhibitor
    /// </summary>
    private Boolean firstInhibitorAssist;

    /// <summary>
    /// Flag indicating if participant destroyed the first inhibitor
    /// </summary>
    private Boolean firstInhibitorKill;

    /// <summary>
    /// Flag indicating if participant got an assist on the first tower
    /// </summary>
    private Boolean firstTowerAssist;

    /// <summary>
    /// Flag indicating if participant destroyed the first tower
    /// </summary>
    private Boolean firstTowerKill;

    /// <summary>
    /// Gold earned
    /// </summary>
    private long goldEarned;

    /// <summary>
    /// Gold spent
    /// </summary>
    private long goldSpent;

    /// <summary>
    /// Number of inhibitor kills
    /// </summary>
    private long inhibitorKills;

    /// <summary>
    /// First item ID
    /// </summary>
    private long item0;

    /// <summary>
    /// Second item ID
    /// </summary>
    private long item1;

    /// <summary>
    /// Third item ID
    /// </summary>
    private long item2;
        
    /// <summary>
    /// Fourth item ID
    /// </summary>
    private long item3;

    /// <summary>
    /// Fifth item ID
    /// </summary>
    private long item4;
	
    /// <summary>
    /// Sixth item ID
    /// </summary>
    private long item5;
                
    /// <summary>
    /// Seventh item ID
    /// </summary>
    private long item6;

    /// <summary>
    /// Number of killing sprees
    /// </summary>
    private long killingSprees;

    /// <summary>
    /// Number of kills
    /// </summary>
    private long kills;

    /// <summary>
    /// Largest critical strike
    /// </summary>
    private long largestCriticalStrike;

    /// <summary>
    /// Largest killing spree
    /// </summary>
    private long largestKillingSpree;

    /// <summary>
    /// Largest multi kill
    /// </summary>
    private long largestMultiKill;

    /// <summary>
    /// Magical damage dealt
    /// </summary>
    private long magicDamageDealt;

    /// <summary>
    /// Magical damage dealt to champions
    /// </summary>
    private long magicDamageDealtToChampions;

    /// <summary>
    /// Magic damage taken
    /// </summary>
    private long magicDamageTaken;

    /// <summary>
    /// Minions killed
    /// </summary>
    private long minionsKilled;

    /// <summary>
    /// Neutral minions killed
    /// </summary>
    private long neutralMinionsKilled;

    /// <summary>
    /// Neutral jungle minions killed in the enemy team's jungle
    /// </summary>
    private long neutralMinionsKilledEnemyJungle;

    /// <summary>
    /// Neutral jungle minions killed in your team's jungle
    /// </summary>
    private long neutralMinionsKilledTeamJungle;

    /// <summary>
    /// If game was a dominion game, number of node captures
    /// </summary>
    private long nodeCapture;

    /// <summary>
    /// If game was a dominion game, number of node capture assists
    /// </summary>
    private long nodeCaptureAssist;

    /// <summary>
    /// If game was a dominion game, number of node neutralizations
    /// </summary>
    private long nodeNeutralize;

    /// <summary>
    /// If game was a dominion game, number of node neutralization assists
    /// </summary>
    private long nodeNeutralizeAssist;

    /// <summary>
    /// If game was a dominion game, player's objectives score, otherwise 0
    /// </summary>
    private long objectivePlayerScore;

    /// <summary>
    /// Number of penta kills
    /// </summary>
    private long pentaKills;
        
    /// <summary>
    /// Physical damage dealt
    /// </summary>
    private long physicalDamageDealt;

    /// <summary>
    /// Physical damage dealt to champions
    /// </summary>
    private long physicalDamageDealtToChampions;

    /// <summary>
    /// Physical damage taken
    /// </summary>
    private long physicalDamageTaken;
        
    /// <summary>
    /// Number of quadra kills
    /// </summary>
    private long quadraKills;

    /// <summary>
    /// Sight wards purchased
    /// </summary>
    private long sightWardsBoughtInGame;

    /// <summary>
    /// If game was a dominion game, number of completed team objectives (i.e., quests)
    /// </summary>
    private long teamObjective;

    /// <summary>
    /// Total damage dealt
    /// </summary>
    private long totalDamageDealt;

    /// <summary>
    /// Total damage dealt to champions
    /// </summary>
    private long totalDamageDealtToChampions;

    /// <summary>
    /// Total damage taken
    /// </summary>
    private long totalDamageTaken;

    /// <summary>
    /// Total heal amount
    /// </summary>
    private long totalHeal;

    /// <summary>
    /// If game was a dominion game, player's total score, otherwise 0
    /// </summary>
    private long totalPlayerScore;

    /// <summary>
    /// If game was a dominion game, team rank of the player's total score (e.g., 1-5)
    /// </summary>
    private long totalScoreRank;

    /// <summary>
    /// Total dealt crowd control time
    /// </summary>
    private long totalTimeCrowdControlDealt;

    /// <summary>
    /// Total units healed
    /// </summary>
    private long totalUnitsHealed;

    /// <summary>
    /// Number of tower kills
    /// </summary>
    private long towerKills;
        
    /// <summary>
    /// Number of triple kills
    /// </summary>
    private long tripleKills;
        
    /// <summary>
    /// True damage dealt
    /// </summary>
    private long trueDamageDealt;

    /// <summary>
    /// True damage dealt to champions
    /// </summary>
    private long trueDamageDealtToChampions;

    /// <summary>
    /// True damage taken
    /// </summary>
    private long trueDamageTaken;

    /// <summary>
    /// Number of unreal kills
    /// </summary>
    private long unrealKills;

    /// <summary>
    /// Vision wards purchased
    /// </summary>
    private long visionWardsBoughtInGame;

    /// <summary>
    /// Number of wards killed
    /// </summary>
    private long wardsKilled;

    /// <summary>
    /// Number of wards placed
    /// </summary>
    private long wardsPlaced;

    /// <summary>
    /// Flag indicating whether or not the participant won
    /// </summary>
    private Boolean winner;

    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// Number of assists
    /// </summary>
    public long Assists
    {
        get 
        {
            return assists;
        }
        set
        {
            this.assists = value;
        }
    }

    /// <summary>
    /// Champion level achieved
    /// </summary>
    public long ChampLevel
    {
        get
        {
            return champLevel;
        }
        set
        {
            this.champLevel = value;
        }
    }

    /// <summary>
    /// If game was a dominion game, player's combat score, otherwise 0
    /// </summary>
    public long CombatPlayerScore
    {
        get
        {
            return combatPlayerScore;
        }
        set
        {
            this.combatPlayerScore = value;
        }
    }

    /// <summary>
    /// Number of deaths
    /// </summary>
    public long Deaths
    {
        get
        {
            return deaths;
        }
        set
        {
            this.deaths = value;
        }
    }

    /// <summary>
    /// Number of double kills
    /// </summary>
    public long DoubleKills
    {
        get
        {
            return doubleKills;
        }
        set
        {
            this.doubleKills = value;
        }
    }

    /// <summary>
    /// Flag indicating if participant got an assist on first blood
    /// </summary>
    public Boolean FirstBloodAssist
    {
        get
        {
            return firstBloodAssist;
        }
        set
        {
            this.firstBloodAssist = value;
        }
    }

    /// <summary>
    /// Flag indicating if participant got first blood
    /// </summary>
    public Boolean FirstBloodKill
    {
        get
        {
            return firstBloodKill;
        }
        set
        {
            this.firstBloodKill = value;
        }
    }

    /// <summary>
    /// Flag indicating if participant got an assist on the first inhibitor
    /// </summary>
    public Boolean FirstInhibitorAssist
    {
        get
        {
            return firstInhibitorAssist;
        }
        set
        {
            this.firstInhibitorAssist = value;
        }
    }

    /// <summary>
    /// Flag indicating if participant destroyed the first inhibitor
    /// </summary>
    public Boolean FirstInhibitorKill
    {
        get
        {
            return firstInhibitorKill;
        }
        set
        {
            this.firstInhibitorKill = value;
        }
    }

    /// <summary>
    /// Flag indicating if participant got an assist on the first tower
    /// </summary>
    public Boolean FirstTowerAssist
    {
        get
        {
            return firstTowerAssist;
        }
        set
        {
            this.firstTowerAssist = value;
        }
    }

    /// <summary>
    /// Flag indicating if participant destroyed the first tower
    /// </summary>
    public Boolean FirstTowerKill
    {
        get
        {
            return firstTowerKill;
        }
        set
        {
            this.firstTowerKill = value;
        }
    }

    /// <summary>
    /// Gold earned
    /// </summary>
    public long GoldEarned
    {
        get
        {
            return goldEarned;
        }
        set
        {
            this.goldEarned = value;
        }
    }

    /// <summary>
    /// Gold spent
    /// </summary>
    public long GoldSpent
    {
        get
        {
            return goldSpent;
        }
        set
        {
            this.goldSpent = value;
        }
    }

    /// <summary>
    /// Number of inhibitor kills
    /// </summary>
    public long InhibitorKills
    {
        get
        {
            return inhibitorKills;
        }
        set
        {
            this.inhibitorKills = value;
        }
    }

    /// <summary>
    /// First item ID
    /// </summary>
    public long Item0
    {
        get
        {
            return item0;
        }
        set
        {
            this.item0 = value;
        }
    }

    /// <summary>
    /// Second item ID
    /// </summary>
    public long Item1
    {
        get
        {
            return item1;
        }
        set
        {
            this.item1 = value;
        }
    }

    /// <summary>
    /// Third item ID
    /// </summary>
    public long Item2
    {
        get
        {
            return item2;
        }
        set
        {
            this.item2 = value;
        }
    }

    /// <summary>
    /// Fourth item ID
    /// </summary>
    public long Item3
    {
        get
        {
            return item3;
        }
        set
        {
            this.item3 = value;
        }
    }

    /// <summary>
    /// Fifth item ID
    /// </summary>
    public long Item4
    {
        get
        {
            return item4;
        }
        set
        {
            this.item4 = value;
        }
    }

    /// <summary>
    /// Sixth item ID
    /// </summary>
    public long Item5
    {
        get
        {
            return item5;
        }
        set
        {
            this.item5 = value;
        }
    }

    /// <summary>
    /// Seventh item ID
    /// </summary>
    public long Item6
    {
        get
        {
            return item6;
        }
        set
        {
            this.item6 = value;
        }
    }

    /// <summary>
    /// Number of killing sprees
    /// </summary>
    public long KillingSprees
    {
        get
        {
            return killingSprees;
        }
        set
        {
            this.killingSprees = value;
        }
    }

    /// <summary>
    /// Number of kills
    /// </summary>
    public long Kills
    {
        get
        {
            return kills;
        }
        set
        {
            this.kills = value;
        }
    }

    /// <summary>
    /// Largest critical strike
    /// </summary>
    public long LargestCriticalStrike
    {
        get
        {
            return largestCriticalStrike;
        }
        set
        {
            this.largestCriticalStrike = value;
        }
    }

    /// <summary>
    /// Largest killing spree
    /// </summary>
    public long LargestKillingSpree
    {
        get
        {
            return largestKillingSpree;
        }
        set
        {
            this.largestKillingSpree = value;
        }
    }

    /// <summary>
    /// Largest multi kill
    /// </summary>
    public long LargestMultiKill
    {
        get
        {
            return largestMultiKill;
        }
        set
        {
            this.largestMultiKill = value;
        }
    }

    /// <summary>
    /// Magical damage dealt
    /// </summary>
    public long MagicDamageDealt
    {
        get
        {
            return magicDamageDealt;
        }
        set
        {
            this.magicDamageDealt = value;
        }
    }

    /// <summary>
    /// Magical damage dealt to champions
    /// </summary>
    public long MagicDamageDealtToChampions
    {
        get
        {
            return magicDamageDealtToChampions;
        }
        set
        {
            this.magicDamageDealtToChampions = value;
        }
    }

    /// <summary>
    /// Magic damage taken
    /// </summary>
    public long MagicDamageTaken
    {
        get
        {
            return magicDamageTaken;
        }
        set
        {
            this.magicDamageTaken = value;
        }
    }

    /// <summary>
    /// Minions killed
    /// </summary>
    public long MinionsKilled
    {
        get
        {
            return minionsKilled;
        }
        set
        {
            this.minionsKilled = value;
        }
    }

    /// <summary>
    /// Neutral minions killed
    /// </summary>
    public long NeutralMinionsKilled
    {
        get
        {
            return neutralMinionsKilled;
        }
        set
        {
            this.neutralMinionsKilled = value;
        }
    }

    /// <summary>
    /// Neutral jungle minions killed in the enemy team's jungle
    /// </summary>
    public long NeutralMinionsKilledEnemyJungle
    {
        get
        {
            return neutralMinionsKilledEnemyJungle;
        }
        set
        {
            this.neutralMinionsKilledEnemyJungle = value;
        }
    }

    /// <summary>
    /// Neutral jungle minions killed in your team's jungle
    /// </summary>
    public long NeutralMinionsKilledTeamJungle
    {
        get
        {
            return neutralMinionsKilledTeamJungle;
        }
        set
        {
            this.neutralMinionsKilledTeamJungle = value;
        }
    }

    /// <summary>
    /// If game was a dominion game, number of node captures
    /// </summary>
    public long NodeCapture
    {
        get
        {
            return nodeCapture;
        }
        set
        {
            this.nodeCapture = value;
        }
    }

    /// <summary>
    /// If game was a dominion game, number of node capture assists
    /// </summary>
    public long NodeCaptureAssist
    {
        get
        {
            return nodeCaptureAssist;
        }
        set
        {
            this.nodeCaptureAssist = value;
        }
    }

    /// <summary>
    /// If game was a dominion game, number of node neutralizations
    /// </summary>
    public long NodeNeutralize
    {
        get
        {
            return nodeNeutralize;
        }
        set
        {
            this.nodeNeutralize = value;
        }
    }

    /// <summary>
    /// If game was a dominion game, number of node neutralization assists
    /// </summary>
    public long NodeNeutralizeAssist
    {
        get
        {
            return nodeNeutralizeAssist;
        }
        set
        {
            this.nodeNeutralizeAssist = value;
        }
    }

    /// <summary>
    /// If game was a dominion game, player's objectives score, otherwise 0
    /// </summary>
    public long ObjectivePlayerScore
    {
        get
        {
            return objectivePlayerScore;
        }
        set
        {
            this.objectivePlayerScore = value;
        }
    }

    /// <summary>
    /// Number of penta kills
    /// </summary>
    public long PentaKills
    {
        get
        {
            return pentaKills;
        }
        set
        {
            this.pentaKills = value;
        }
    }

    /// <summary>
    /// Physical damage dealt
    /// </summary>
    public long PhysicalDamageDealt
    {
        get
        {
            return physicalDamageDealt;
        }
        set
        {
            this.physicalDamageDealt = value;
        }
    }

    /// <summary>
    /// Physical damage dealt to champions
    /// </summary>
    public long PhysicalDamageDealtToChampions
    {
        get
        {
            return physicalDamageDealtToChampions;
        }
        set
        {
            this.physicalDamageDealtToChampions = value;
        }
    }

    /// <summary>
    /// Physical damage taken
    /// </summary>
    public long PhysicalDamageTaken
    {
        get
        {
            return physicalDamageTaken;
        }
        set
        {
            this.physicalDamageTaken = value;
        }
    }

    /// <summary>
    /// Number of quadra kills
    /// </summary>
    public long QuadraKills
    {
        get
        {
            return quadraKills;
        }
        set
        {
            this.quadraKills = value;
        }
    }

    /// <summary>
    /// Sight wards purchased
    /// </summary>
    public long SightWardsBoughtInGame
    {
        get
        {
            return sightWardsBoughtInGame;
        }
        set
        {
            this.sightWardsBoughtInGame = value;
        }
    }

    /// <summary>
    /// If game was a dominion game, number of completed team objectives (i.e., quests)
    /// </summary>
    public long TeamObjective
    {
        get
        {
            return teamObjective;
        }
        set
        {
            this.teamObjective = value;
        }
    }

    /// <summary>
    /// Total damage dealt
    /// </summary>
    public long TotalDamageDealt
    {
        get
        {
            return totalDamageDealt;
        }
        set
        {
            this.totalDamageDealt = value;
        }
    }

    /// <summary>
    /// Total damage dealt to champions
    /// </summary>
    public long TotalDamageDealtToChampions
    {
        get
        {
            return totalDamageDealtToChampions;
        }
        set
        {
            this.totalDamageDealtToChampions = value;
        }
    }

    /// <summary>
    /// Total damage taken
    /// </summary>
    public long TotalDamageTaken
    {
        get
        {
            return totalDamageTaken;
        }
        set
        {
            this.totalDamageTaken = value;
        }
    }

    /// <summary>
    /// Total heal amount
    /// </summary>
    public long TotalHeal
    {
        get
        {
            return totalHeal;
        }
        set
        {
            this.totalHeal = value;
        }
    }

    /// <summary>
    /// If game was a dominion game, player's total score, otherwise 0
    /// </summary>
    public long TotalPlayerScore
    {
        get
        {
            return totalPlayerScore;
        }
        set
        {
            this.totalPlayerScore = value;
        }
    }

    /// <summary>
    /// If game was a dominion game, team rank of the player's total score (e.g., 1-5)
    /// </summary>
    public long TotalScoreRank
    {
        get
        {
            return totalScoreRank;
        }
        set
        {
            this.totalScoreRank = value;
        }
    }

    /// <summary>
    /// Total dealt crowd control time
    /// </summary>
    public long TotalTimeCrowdControlDealt
    {
        get
        {
            return totalTimeCrowdControlDealt;
        }
        set
        {
            this.totalTimeCrowdControlDealt = value;
        }
    }

    /// <summary>
    /// Total units healed
    /// </summary>
    public long TotalUnitsHealed
    {
        get
        {
            return totalUnitsHealed;
        }
        set
        {
            this.totalUnitsHealed = value;
        }
    }

    /// <summary>
    /// Number of tower kills
    /// </summary>
    public long TowerKills
    {
        get
        {
            return towerKills;
        }
        set
        {
            this.towerKills = value;
        }
    }

    /// <summary>
    /// Number of triple kills
    /// </summary>
    public long TripleKills
    {
        get
        {
            return tripleKills;
        }
        set
        {
            this.tripleKills = value;
        }
    }

    /// <summary>
    /// True damage dealt
    /// </summary>
    public long TrueDamageDealt
    {
        get
        {
            return trueDamageDealt;
        }
        set
        {
            this.trueDamageDealt = value;
        }
    }

    /// <summary>
    /// True damage dealt to champions
    /// </summary>
    public long TrueDamageDealtToChampions
    {
        get
        {
            return trueDamageDealtToChampions;
        }
        set
        {
            this.trueDamageDealtToChampions = value;
        }
    }

    /// <summary>
    /// True damage taken
    /// </summary>
    public long TrueDamageTaken
    {
        get
        {
            return trueDamageTaken;
        }
        set
        {
            this.trueDamageTaken = value;
        }
    }

    /// <summary>
    /// Number of unreal kills
    /// </summary>
    public long UnrealKills
    {
        get
        {
            return unrealKills;
        }
        set
        {
            this.unrealKills = value;
        }
    }

    /// <summary>
    /// Vision wards purchased
    /// </summary>
    public long VisionWardsBoughtInGame
    {
        get
        {
            return visionWardsBoughtInGame;
        }
        set
        {
            this.visionWardsBoughtInGame = value;
        }
    }

    /// <summary>
    /// Number of wards killed
    /// </summary>
    public long WardsKilled
    {
        get
        {
            return wardsKilled;
        }
        set
        {
            this.wardsKilled = value;
        }
    }

    /// <summary>
    /// Number of wards placed
    /// </summary>
    public long WardsPlaced
    {
        get
        {
            return wardsPlaced;
        }
        set
        {
            this.wardsPlaced = value;
        }
    }

    /// <summary>
    /// Flag indicating whether or not the participant won
    /// </summary>
    public Boolean Winner
    {
        get
        {
            return winner;
        }
        set
        {
            this.winner = value;
        }
    }

    #endregion
}

