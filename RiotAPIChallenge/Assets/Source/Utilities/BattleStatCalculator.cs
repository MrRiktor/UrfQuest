#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: BattleStatCalculator.cs
 * 
 * Description: Static class used to convert participant data into our battle stats.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using System.Collections;

#endregion

public static class BattleStatCalculator
{
    #region Private Variables

    /// <summary>
    /// The weight applied to kills in the equation
    /// </summary>
    private static float KillWeight = 2.0f;

    /// <summary>
    /// The weight applied to assists in the equation
    /// </summary>
    private static float AssistsWeight = 1.0f;

    /// <summary>
    /// The weight applied to damage in the equation
    /// </summary>
    private static float DamageWeight = 4.0f;
    
    /// <summary>
    /// A number used merely to normalize the attack and health pools derived from our equation.
    /// </summary>
    private static long PercentScale = 1000;

    #endregion

    #region Public Methods

    /// <summary>
    /// Calculates the damage of a PartyMember based upon KA and DamageDone
    /// </summary>
    /// <param name="TotalDamageDone">The total amount of damage dealt to champions.</param>
    /// <param name="kills">The total number of kills by the participant. </param>
    /// <param name="assists">the total number of assists by the participant. </param>
    /// <returns></returns>
    public static float DamageCalculation( float TotalDamageDone, float kills, float assists)
    {
        float attackDamage;

        float kaRatio = kills + assists;
        
        if(kaRatio <= 0)
        {
            kaRatio = 1;
        }

        float DamagePerKillParticipation = (TotalDamageDone / ( kaRatio ));

        attackDamage = (((DamagePerKillParticipation * DamageWeight) * ((kills * KillWeight) + (assists * AssistsWeight))) + (DamagePerKillParticipation * DamageWeight)) / PercentScale;
        
        // if they were afk... you have 1 attack.
        if(attackDamage < 1)
        {
            attackDamage = 1;
        }

        return attackDamage;
    }

    /// <summary>
    /// Calculates health pool by using the total damage taken and total number of deaths.
    /// </summary>
    /// <param name="TotalDamageTaken">The total amount of damage taken. </param>
    /// <param name="deaths">The total number of deaths. </param>
    /// <returns></returns>
    public static long HealthCalculation(long TotalDamageTaken, long deaths)
    {
        if(deaths <= 0)
        { 
            deaths = 1;
        }

        long damagePerDeath = (TotalDamageTaken / deaths) / 10;

        return damagePerDeath;
    }

    #endregion
}
