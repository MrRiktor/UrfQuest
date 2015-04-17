#region File Header

/*******************************************************************************
 * Author: Vincent "Sabin" Biancardi
 * Filename: MaxPartyStats.cs
 * Date Created: 4/11/2015 6:50PM EST
 * 
 * Description: A class that stores the maximum stats for a party.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 8:13 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;

#endregion

public class MaxPartyStats
{
    #region Private Variables

    /// <summary>
    /// The maximum attack of the player.
    /// </summary>
    private Int64 maxPlayerAttack = 0;

    /// <summary>
    /// The maximum health pool of the player.
    /// </summary>
    private Int64 maxPlayerHealthPool = 0;

    /// <summary>
    /// The maximum team attack.
    /// </summary>
    private Int64 maxTeamAttack = 0;

    /// <summary>
    /// The maximum team health pool.
    /// </summary>
    private Int64 maxTeamHealthPool = 0;

    #endregion

    #region Accessors/Mutators

    /// <summary>
    /// Accessor/Modifier for the maximum player attack.
    /// </summary>
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

    /// <summary>
    /// Accessor/Modifier for the maximum player health pool.
    /// </summary>
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

    /// <summary>
    /// Accessor/Modifier for the maximum team attack.
    /// </summary>
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

    /// <summary>
    /// Accessor/Modifier for the maximum team health pool.
    /// </summary>
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