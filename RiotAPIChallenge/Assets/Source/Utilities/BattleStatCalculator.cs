using UnityEngine;
using System.Collections;

public static class BattleStatCalculator
{
    private static float KillWeight = 2.0f;
    private static float AssistsWeight = 1.0f;
    private static float DamageWeight = 4.0f;
    private static long PercentScale = 1000;

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

    public static long HealthCalculation(long TotalDamageTaken, long deaths)
    {
        if(deaths <= 0)
        { 
            deaths = 1;
        }

        long damagePerDeath = (TotalDamageTaken / deaths) / 10;

        return damagePerDeath;
    }
}
