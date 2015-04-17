#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: IPartyMember.cs
 * Date Created: 4/11/2015 10:36PM EST
 * 
 * Description: The interface for PartyMembers.
 * Note: The intent is to migrate away from the current naming convetion of "Being, Enemy, PartyMember" 
 * into a more understandable state. ( IPartyMember -> PartyMember -> PlayerPartyMember/EnemyPartyMember )
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/15/2015 10:48 PM
 *              - Modified: Matthew "Riktor" Baker - 4/16/2015 8:13 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;

#endregion

public interface IPartyMember
{
    #region Interface Declarations

    /// <summary>
    /// The name of the unit.
    /// </summary>
    String BeingName
    { 
        get; 
        set; 
    }

    /// <summary>
    /// The calculated attack damage of the unit.
    /// </summary>
    long AttackDamage
    {
        get;
        set;
    }

    /// <summary>
    /// The calculated health pool of the unit.
    /// </summary>
    long HealthPool
    {
        get;
        set;
    }

    /// <summary>
    /// The movementspeed of the unit.
    /// </summary>
    long MovementSpeed
    {
        get;
        set;
    }

    /// <summary>
    /// The actual Sprite icon fo the unit.
    /// </summary>
    UnityEngine.Sprite Icon
    {
        get;
        set;
    }

    /// <summary>
    /// The actual Sprite portrait of the unit.
    /// </summary>
    UnityEngine.Sprite Portrait
    {
        get;
        set;
    }

    /// <summary>
    /// The actual AudioClip of the unit's attack.
    /// </summary>
    UnityEngine.AudioClip AttackClip
    {
        get;
        set;
    }

    #endregion
}
