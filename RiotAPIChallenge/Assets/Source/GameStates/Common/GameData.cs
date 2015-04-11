using System;

public class GameData
{
    #region Variables

    private static Int32 currentLevel=0;
    private static Party currentParty;

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

    #endregion
}