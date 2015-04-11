using System;

public class MaxPartyStats
{
    #region Variables

    private Int64 maxPlayerAttack = 0;

    private Int64 maxPlayerHealthPool = 0;

    private Int64 maxTeamAttack = 0;

    private Int64 maxTeamHealthPool = 0;

    #endregion

    #region Accessors/Mutators

    public Int64 MaxPlayerAttack
    {
        get 
        {
            return maxPlayerAttack;
        }
        set 
        {
            maxPlayerAttack = value;
        }
    }

    public Int64 MaxPlayerHealthPool
    {
        get
        {
            return maxPlayerHealthPool;
        }
        set
        {
            maxPlayerHealthPool = value;
        }
    }

    public Int64 MaxTeamAttack
    {
        get
        {
            return maxTeamAttack;
        }
        set
        {
            maxTeamAttack = value;
        }
    }

    public Int64 MaxTeamHealthPool
    {
        get
        {
            return maxTeamHealthPool;
        }
        set
        {
            maxTeamHealthPool = value;
        }
    }

    #endregion
}