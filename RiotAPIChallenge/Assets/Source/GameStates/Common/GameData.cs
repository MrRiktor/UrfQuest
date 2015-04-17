#region File Header

/*******************************************************************************
 * Author: Vincent "Sabin" Biancardi
 * Filename: GameData.cs
 * Date Created: 4/11/2015 1:54 AM EST
 * 
 * Description: The Global gamedata data class
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 8:13 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;

#endregion

public class GameData
{
    #region Private Variables

    /// <summary>
    /// The current stage the user is on.
    /// </summary>
    private static Int32 currentLevel = 0;
    
    /// <summary>
    /// the current number of strikes/losses the player has.
    /// </summary>
    private static Int32 strikes = 0;
    
    /// <summary>
    /// The players score.
    /// </summary>
    private static float score = 0.0f;
    
    /// <summary>
    /// Whether they have beaten the entire game or not.
    /// </summary>
    private static Boolean victorious = false;
    
    /// <summary>
    /// The current party of the user.
    /// </summary>
    private static Party currentParty;

    /// <summary>
    /// the stage data.
    /// </summary>
    private static StageMap stageMap = null;

    #endregion

    #region Accessors/Mutators

    /// <summary>
    /// Accessor/Modifier for the current level
    /// </summary>
    public static Int32 CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
        }
    }

    /// <summary>
    /// Accessor/Modifier for the strikes
    /// </summary>
    public static Int32 Strikes
    {
        get
        {
            return strikes;
        }
        set
        {
            strikes = value;
        }
    }

    /// <summary>
    /// Accessor/Modifier for the current party
    /// </summary>
    public static Party CurrentParty
    {
        get
        {
            return currentParty;
        }
        set
        {
            currentParty = value;
        }
    }

    /// <summary>
    /// Accessor/Modifier for the stage map
    /// </summary>
    public static StageMap StageMap
    {
        get
        {
            if (stageMap == null)
            {
                stageMap = new StageMap();
                stageMap.Initialize();
            }

            return stageMap;
        }
    }

    /// <summary>
    /// Accessor/Modifier for the victorious boolean
    /// </summary>
    public static Boolean Victorious
    {
        get
        {
            return victorious;
        }
        set
        {
            victorious = value;
        }
    }

    /// <summary>
    /// Accessor/Modifier for the score
    /// </summary>
    public static float Score
    {
        get
        {
            return score;
        }
        set
        {
            score = (value < 0) ? 0 : value;
        }
    }

    #endregion
}