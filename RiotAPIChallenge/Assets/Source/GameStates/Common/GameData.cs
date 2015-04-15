using System;

public class GameData
{
    #region Variables

    private static Int32 currentLevel = 0;
    private static Int32 strikes = 0;
    private static float score = 0.0f;
    private static Boolean victorious = false;
    private static Party currentParty;


    private static StageMap stageMap = null;

    #endregion

    #region Accessors/Mutators

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