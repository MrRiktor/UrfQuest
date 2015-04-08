﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Source.JSON.Data.MatchDetail.Participant
{
    public class Participant
    {
        #region Private Member Variables

        /// <summary>
        /// Champion ID
        /// </summary>
        private int championId;

        /// <summary>
        /// Highest ranked tier achieved for the previous season, if any, otherwise null. Used to display border in game loading screen. 
        /// (Legal values: CHALLENGER, MASTER, DIAMOND, PLATINUM, GOLD, SILVER, BRONZE, UNRANKED)
        /// </summary>
        private String highestAchievedSeasonTier; 

        /// <summary>
        /// List of mastery information
        /// </summary>
        //private List<Mastery> masteries;

        /// <summary>
        /// Participant ID
        /// </summary>
        private int participantId;
        
        /// <summary>
        /// List of rune information
        /// </summary>
       // private List<Rune> runes;

        /// <summary>
        /// First summoner spell ID
        /// </summary>
        private int spell1Id;

        /// <summary>
        /// Second summoner spell ID
        /// </summary>
        private int spell2Id; 

        /// <summary>
        /// Participant statistics
        /// </summary>
        //private PartipantStats stats;

        /// <summary>
        /// Team ID
        /// </summary>
        private int teamId;

        /// <summary>
        /// Timeline data. Delta fields refer to values for the specified period (e.g., the gold per minute over the first 10 minutes of the game versus the second 20 minutes of the game. Diffs fields refer to the deltas versus the calculated lane opponent(s).
        /// </summary>
        //private ParticipantTimeline timeline;

        #endregion
    
        #region Accessors/Modifiers

        /// <summary>
        /// Champion ID
        /// </summary>
        public int ChampionId
        {
            get 
            {
                return championId;
            }
            set 
            {
                championId = value;
            }
        }

        /// <summary>
        /// Highest ranked tier achieved for the previous season, if any, otherwise null. Used to display border in game loading screen. 
        /// (Legal values: CHALLENGER, MASTER, DIAMOND, PLATINUM, GOLD, SILVER, BRONZE, UNRANKED)
        /// </summary>
        public String HighestAchievedSeasonTier
        {
            get 
            {
                return highestAchievedSeasonTier;
            }
            set 
            {
                highestAchievedSeasonTier = value;
            }
        }
        
        /// <summary>
        /// List of mastery information
        /// </summary>
        /*public List<Mastery> Masteries;
        {
            get 
            {
                return masteries;
            }
            set 
            {
                masteries = value;
            }
        }*/

        /// <summary>
        /// Participant ID
        /// </summary>
        public int ParticipantId
        {
            get 
            {
                return participantId;
            }
            set 
            {
                participantId = value;
            }
        }

        /// <summary>
        /// List of rune information
        /// </summary>
       /* public List<Rune> runes
        {
            get 
            {
                return runes;
            }
            set 
            {
                runes = value;
            }
        }*/

        /// <summary>
        /// First summoner spell ID
        /// </summary>
        public int Spell1Id
        {
            get 
            {
                return spell1Id;
            }
            set 
            {
                spell1Id = value;
            }
        }

        /// <summary>
        /// Second summoner spell ID
        /// </summary>
        public int Spell2Id
{
            get 
            {
                return spell2Id;
            }
            set 
            {
                spell2Id = value;
            }
        }

        /// <summary>
        /// Participant statistics
        /// </summary>
        /*public PartipantStats Stats
        {
            get 
            {
                return stats;
            }
            set 
            {
                stats = value;
            }
        }*/

        /// <summary>
        /// Team ID
        /// </summary>
        public int TeamId
        {
            get 
            {
                return teamId;
            }
            set 
            {
                teamId = value;
            }
        }

        /// <summary>
        /// Timeline data. Delta fields refer to values for the specified period (e.g., the gold per minute over the first 10 minutes of the game versus the second 20 minutes of the game. Diffs fields refer to the deltas versus the calculated lane opponent(s).
        /// </summary>
        /*public ParticipantTimeline Timeline
        {
            get 
            {
                return timeline;
            }
            set 
            {
                timeline = value;
            }
        }*/

        #endregion
    }
}
