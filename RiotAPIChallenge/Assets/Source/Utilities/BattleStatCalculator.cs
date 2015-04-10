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

        float DamagePerKillParticipation = ( TotalDamageDone / ( kills + assists ) );

        attackDamage = (((DamagePerKillParticipation * DamageWeight) * ((kills * KillWeight) + (assists * AssistsWeight))) + (DamagePerKillParticipation * DamageWeight)) / PercentScale;

        return attackDamage;
    }

    public static long HealthCalculation(long TotalDamageTaken, long deaths)
    {
        long damagePerDeath = (TotalDamageTaken / deaths) / 10;

        return damagePerDeath;
    }
}
