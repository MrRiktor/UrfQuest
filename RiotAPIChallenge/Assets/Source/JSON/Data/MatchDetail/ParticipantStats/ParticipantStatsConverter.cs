#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: ParticipantStatsConverter.cs
 * Date Created: 4/11/2015 8:28PM EST
 * 
 * Description: Converter for ParticipantStats Data Class
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;
using System.Collections.Generic;
using JsonFx.Json;

#endregion

public class ParticipantStatsConverter : JsonConverter
{
    #region Public Methods

    #region Converters

    /// <summary>
    /// 
    /// </summary>
    /// <param name="propToValueMap"></param>
    /// <returns></returns>
    public static ParticipantStats DictionaryToParticipantStats( Dictionary<String, Object> propToValueMap )
    {
        ParticipantStats participantStats = new ParticipantStats();

        #region Assists Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Assists ) && propToValueMap[ParticipantStats.PropertyNames.Assists] is long )
        {
            participantStats.Assists = (long)propToValueMap[ParticipantStats.PropertyNames.Assists];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Assists ) && propToValueMap[ParticipantStats.PropertyNames.Assists] is int )
        {
            participantStats.Assists = (int)propToValueMap[ParticipantStats.PropertyNames.Assists];
        }

        #endregion

        #region ChampLevel Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.ChampLevel ) && propToValueMap[ParticipantStats.PropertyNames.ChampLevel] is long )
        {
            participantStats.ChampLevel = (long)propToValueMap[ParticipantStats.PropertyNames.ChampLevel];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.ChampLevel ) && propToValueMap[ParticipantStats.PropertyNames.ChampLevel] is int )
        {
            participantStats.ChampLevel = (int)propToValueMap[ParticipantStats.PropertyNames.ChampLevel];
        }

        #endregion

        #region CombatPlayerScore Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.CombatPlayerScore ) && propToValueMap[ParticipantStats.PropertyNames.CombatPlayerScore] is long )
        {
            participantStats.CombatPlayerScore = (long)propToValueMap[ParticipantStats.PropertyNames.CombatPlayerScore];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.CombatPlayerScore ) && propToValueMap[ParticipantStats.PropertyNames.CombatPlayerScore] is int )
        {
            participantStats.CombatPlayerScore = (int)propToValueMap[ParticipantStats.PropertyNames.CombatPlayerScore];
        }

        #endregion

        #region Deaths Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Deaths ) && propToValueMap[ParticipantStats.PropertyNames.Deaths] is long )
        {
            participantStats.Deaths = (long)propToValueMap[ParticipantStats.PropertyNames.Deaths];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Deaths ) && propToValueMap[ParticipantStats.PropertyNames.Deaths] is int )
        {
            participantStats.Deaths = (int)propToValueMap[ParticipantStats.PropertyNames.Deaths];
        }

        #endregion

        #region DoubleKills Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.DoubleKills ) && propToValueMap[ParticipantStats.PropertyNames.DoubleKills] is long )
        {
            participantStats.DoubleKills = (long)propToValueMap[ParticipantStats.PropertyNames.DoubleKills];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.DoubleKills ) && propToValueMap[ParticipantStats.PropertyNames.DoubleKills] is int )
        {
            participantStats.DoubleKills = (int)propToValueMap[ParticipantStats.PropertyNames.DoubleKills];
        }

        #endregion

        #region FirstBloodAssist Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.FirstBloodAssist ) && propToValueMap[ParticipantStats.PropertyNames.FirstBloodAssist] is bool )
        {
            participantStats.FirstBloodAssist = (bool)propToValueMap[ParticipantStats.PropertyNames.FirstBloodAssist];
        }

        #endregion

        #region FirstBloodKill Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.FirstBloodKill ) && propToValueMap[ParticipantStats.PropertyNames.FirstBloodKill] is bool )
        {
            participantStats.FirstBloodKill = (bool)propToValueMap[ParticipantStats.PropertyNames.FirstBloodKill];
        }

        #endregion

        #region FirstInhibitorAssist Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.FirstInhibitorAssist ) && propToValueMap[ParticipantStats.PropertyNames.FirstInhibitorAssist] is bool )
        {
            participantStats.FirstInhibitorAssist = (bool)propToValueMap[ParticipantStats.PropertyNames.FirstInhibitorAssist];
        }

        #endregion

        #region FirstInhibitorKill Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.FirstInhibitorKill ) && propToValueMap[ParticipantStats.PropertyNames.FirstInhibitorKill] is bool )
        {
            participantStats.FirstInhibitorKill = (bool)propToValueMap[ParticipantStats.PropertyNames.FirstInhibitorKill];
        }

        #endregion

        #region FirstTowerAssist Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.FirstTowerAssist ) && propToValueMap[ParticipantStats.PropertyNames.FirstTowerAssist] is bool )
        {
            participantStats.FirstTowerAssist = (bool)propToValueMap[ParticipantStats.PropertyNames.FirstTowerAssist];
        }

        #endregion

        #region FirstTowerKill Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.FirstTowerKill ) && propToValueMap[ParticipantStats.PropertyNames.FirstTowerKill] is bool )
        {
            participantStats.FirstTowerKill = (bool)propToValueMap[ParticipantStats.PropertyNames.FirstTowerKill];
        }

        #endregion

        #region GoldEarned Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.GoldEarned ) && propToValueMap[ParticipantStats.PropertyNames.GoldEarned] is long )
        {
            participantStats.GoldEarned = (long)propToValueMap[ParticipantStats.PropertyNames.GoldEarned];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.GoldEarned ) && propToValueMap[ParticipantStats.PropertyNames.GoldEarned] is int )
        {
            participantStats.GoldEarned = (int)propToValueMap[ParticipantStats.PropertyNames.GoldEarned];
        }

        #endregion

        #region GoldSpent Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.GoldSpent ) && propToValueMap[ParticipantStats.PropertyNames.GoldSpent] is long )
        {
            participantStats.GoldSpent = (long)propToValueMap[ParticipantStats.PropertyNames.GoldSpent];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.GoldSpent ) && propToValueMap[ParticipantStats.PropertyNames.GoldSpent] is int )
        {
            participantStats.GoldSpent = (int)propToValueMap[ParticipantStats.PropertyNames.GoldSpent];
        }

        #endregion

        #region InhibitorKills Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.InhibitorKills ) && propToValueMap[ParticipantStats.PropertyNames.InhibitorKills] is long )
        {
            participantStats.InhibitorKills = (long)propToValueMap[ParticipantStats.PropertyNames.InhibitorKills];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.InhibitorKills ) && propToValueMap[ParticipantStats.PropertyNames.InhibitorKills] is int )
        {
            participantStats.InhibitorKills = (int)propToValueMap[ParticipantStats.PropertyNames.InhibitorKills];
        }

        #endregion

        #region Item0 Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Item0 ) && propToValueMap[ParticipantStats.PropertyNames.Item0] is long )
        {
            participantStats.Item0 = (long)propToValueMap[ParticipantStats.PropertyNames.Item0];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Item0 ) && propToValueMap[ParticipantStats.PropertyNames.Item0] is int )
        {
            participantStats.Item0 = (int)propToValueMap[ParticipantStats.PropertyNames.Item0];
        }

        #endregion

        #region Item1 Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Item1 ) && propToValueMap[ParticipantStats.PropertyNames.Item1] is long )
        {
            participantStats.Item1 = (long)propToValueMap[ParticipantStats.PropertyNames.Item1];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Item1 ) && propToValueMap[ParticipantStats.PropertyNames.Item1] is int )
        {
            participantStats.Item1 = (int)propToValueMap[ParticipantStats.PropertyNames.Item1];
        }

        #endregion

        #region Item2 Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Item2 ) && propToValueMap[ParticipantStats.PropertyNames.Item2] is long )
        {
            participantStats.Item2 = (long)propToValueMap[ParticipantStats.PropertyNames.Item2];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Item2 ) && propToValueMap[ParticipantStats.PropertyNames.Item2] is int )
        {
            participantStats.Item2 = (int)propToValueMap[ParticipantStats.PropertyNames.Item2];
        }

        #endregion

        #region Item3 Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Item3 ) && propToValueMap[ParticipantStats.PropertyNames.Item3] is long )
        {
            participantStats.Item3 = (long)propToValueMap[ParticipantStats.PropertyNames.Item3];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Item3 ) && propToValueMap[ParticipantStats.PropertyNames.Item3] is int )
        {
            participantStats.Item3 = (int)propToValueMap[ParticipantStats.PropertyNames.Item3];
        }

        #endregion

        #region Item4 Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Item4 ) && propToValueMap[ParticipantStats.PropertyNames.Item4] is long )
        {
            participantStats.Item4 = (long)propToValueMap[ParticipantStats.PropertyNames.Item4];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Item4 ) && propToValueMap[ParticipantStats.PropertyNames.Item4] is int )
        {
            participantStats.Item4 = (int)propToValueMap[ParticipantStats.PropertyNames.Item4];
        }

        #endregion

        #region Item5 Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Item5 ) && propToValueMap[ParticipantStats.PropertyNames.Item5] is long )
        {
            participantStats.Item5 = (long)propToValueMap[ParticipantStats.PropertyNames.Item5];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Item5 ) && propToValueMap[ParticipantStats.PropertyNames.Item5] is int )
        {
            participantStats.Item5 = (int)propToValueMap[ParticipantStats.PropertyNames.Item5];
        }

        #endregion

        #region Item6 Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Item6 ) && propToValueMap[ParticipantStats.PropertyNames.Item6] is long )
        {
            participantStats.Item6 = (long)propToValueMap[ParticipantStats.PropertyNames.Item6];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Item6 ) && propToValueMap[ParticipantStats.PropertyNames.Item6] is int )
        {
            participantStats.Item6 = (int)propToValueMap[ParticipantStats.PropertyNames.Item6];
        }

        #endregion

        #region KillingSprees Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.KillingSprees ) && propToValueMap[ParticipantStats.PropertyNames.KillingSprees] is long )
        {
            participantStats.KillingSprees = (long)propToValueMap[ParticipantStats.PropertyNames.KillingSprees];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.KillingSprees ) && propToValueMap[ParticipantStats.PropertyNames.KillingSprees] is int )
        {
            participantStats.KillingSprees = (int)propToValueMap[ParticipantStats.PropertyNames.KillingSprees];
        }

        #endregion

        #region Kills Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Kills ) && propToValueMap[ParticipantStats.PropertyNames.Kills] is long )
        {
            participantStats.Kills = (long)propToValueMap[ParticipantStats.PropertyNames.Kills];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Kills ) && propToValueMap[ParticipantStats.PropertyNames.Kills] is int )
        {
            participantStats.Kills = (int)propToValueMap[ParticipantStats.PropertyNames.Kills];
        }

        #endregion

        #region LargestCriticalStrike Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.LargestCriticalStrike ) && propToValueMap[ParticipantStats.PropertyNames.LargestCriticalStrike] is long )
        {
            participantStats.LargestCriticalStrike = (long)propToValueMap[ParticipantStats.PropertyNames.LargestCriticalStrike];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.LargestCriticalStrike ) && propToValueMap[ParticipantStats.PropertyNames.LargestCriticalStrike] is int )
        {
            participantStats.LargestCriticalStrike = (int)propToValueMap[ParticipantStats.PropertyNames.LargestCriticalStrike];
        }

        #endregion

        #region LargestKillingSpree Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.LargestKillingSpree ) && propToValueMap[ParticipantStats.PropertyNames.LargestKillingSpree] is long )
        {
            participantStats.LargestKillingSpree = (long)propToValueMap[ParticipantStats.PropertyNames.LargestKillingSpree];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.LargestKillingSpree ) && propToValueMap[ParticipantStats.PropertyNames.LargestKillingSpree] is int )
        {
            participantStats.LargestKillingSpree = (int)propToValueMap[ParticipantStats.PropertyNames.LargestKillingSpree];
        }

        #endregion

        #region LargestMultiKill Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.LargestMultiKill ) && propToValueMap[ParticipantStats.PropertyNames.LargestMultiKill] is long )
        {
            participantStats.LargestMultiKill = (long)propToValueMap[ParticipantStats.PropertyNames.LargestMultiKill];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.LargestMultiKill ) && propToValueMap[ParticipantStats.PropertyNames.LargestMultiKill] is int )
        {
            participantStats.LargestMultiKill = (int)propToValueMap[ParticipantStats.PropertyNames.LargestMultiKill];
        }

        #endregion

        #region MagicDamageDealt Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.MagicDamageDealt ) && propToValueMap[ParticipantStats.PropertyNames.MagicDamageDealt] is long )
        {
            participantStats.MagicDamageDealt = (long)propToValueMap[ParticipantStats.PropertyNames.MagicDamageDealt];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.MagicDamageDealt ) && propToValueMap[ParticipantStats.PropertyNames.MagicDamageDealt] is int )
        {
            participantStats.MagicDamageDealt = (int)propToValueMap[ParticipantStats.PropertyNames.MagicDamageDealt];
        }

        #endregion

        #region MagicDamageDealtToChampions Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.MagicDamageDealtToChampions ) && propToValueMap[ParticipantStats.PropertyNames.MagicDamageDealtToChampions] is long )
        {
            participantStats.MagicDamageDealtToChampions = (long)propToValueMap[ParticipantStats.PropertyNames.MagicDamageDealtToChampions];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.MagicDamageDealtToChampions ) && propToValueMap[ParticipantStats.PropertyNames.MagicDamageDealtToChampions] is int )
        {
            participantStats.MagicDamageDealtToChampions = (int)propToValueMap[ParticipantStats.PropertyNames.MagicDamageDealtToChampions];
        }

        #endregion

        #region MagicDamageTaken Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.MagicDamageTaken ) && propToValueMap[ParticipantStats.PropertyNames.MagicDamageTaken] is long )
        {
            participantStats.MagicDamageTaken = (long)propToValueMap[ParticipantStats.PropertyNames.MagicDamageTaken];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.MagicDamageTaken ) && propToValueMap[ParticipantStats.PropertyNames.MagicDamageTaken] is int )
        {
            participantStats.MagicDamageTaken = (int)propToValueMap[ParticipantStats.PropertyNames.MagicDamageTaken];
        }

        #endregion

        #region MinionsKilled Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.MinionsKilled ) && propToValueMap[ParticipantStats.PropertyNames.MinionsKilled] is long )
        {
            participantStats.MinionsKilled = (long)propToValueMap[ParticipantStats.PropertyNames.MinionsKilled];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.MinionsKilled ) && propToValueMap[ParticipantStats.PropertyNames.MinionsKilled] is int )
        {
            participantStats.MinionsKilled = (int)propToValueMap[ParticipantStats.PropertyNames.MinionsKilled];
        }

        #endregion

        #region NeutralMinionsKilled Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.NeutralMinionsKilled ) && propToValueMap[ParticipantStats.PropertyNames.NeutralMinionsKilled] is long )
        {
            participantStats.NeutralMinionsKilled = (long)propToValueMap[ParticipantStats.PropertyNames.NeutralMinionsKilled];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.NeutralMinionsKilled ) && propToValueMap[ParticipantStats.PropertyNames.NeutralMinionsKilled] is int )
        {
            participantStats.NeutralMinionsKilled = (int)propToValueMap[ParticipantStats.PropertyNames.NeutralMinionsKilled];
        }

        #endregion

        #region NeutralMinionsKilledEnemyJungle Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.NeutralMinionsKilledEnemyJungle ) && propToValueMap[ParticipantStats.PropertyNames.NeutralMinionsKilledEnemyJungle] is long )
        {
            participantStats.NeutralMinionsKilledEnemyJungle = (long)propToValueMap[ParticipantStats.PropertyNames.NeutralMinionsKilledEnemyJungle];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.NeutralMinionsKilledEnemyJungle ) && propToValueMap[ParticipantStats.PropertyNames.NeutralMinionsKilledEnemyJungle] is int )
        {
            participantStats.NeutralMinionsKilledEnemyJungle = (int)propToValueMap[ParticipantStats.PropertyNames.NeutralMinionsKilledEnemyJungle];
        }

        #endregion

        #region NeutralMinionsKilledTeamJungle Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.NeutralMinionsKilledTeamJungle ) && propToValueMap[ParticipantStats.PropertyNames.NeutralMinionsKilledTeamJungle] is long )
        {
            participantStats.NeutralMinionsKilledTeamJungle = (long)propToValueMap[ParticipantStats.PropertyNames.NeutralMinionsKilledTeamJungle];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.NeutralMinionsKilledTeamJungle ) && propToValueMap[ParticipantStats.PropertyNames.NeutralMinionsKilledTeamJungle] is int )
        {
            participantStats.NeutralMinionsKilledTeamJungle = (int)propToValueMap[ParticipantStats.PropertyNames.NeutralMinionsKilledTeamJungle];
        }

        #endregion

        #region NodeCapture Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.NodeCapture ) && propToValueMap[ParticipantStats.PropertyNames.NodeCapture] is long )
        {
            participantStats.NodeCapture = (long)propToValueMap[ParticipantStats.PropertyNames.NodeCapture];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.NodeCapture ) && propToValueMap[ParticipantStats.PropertyNames.NodeCapture] is int )
        {
            participantStats.NodeCapture = (int)propToValueMap[ParticipantStats.PropertyNames.NodeCapture];
        }

        #endregion

        #region NodeCaptureAssist Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.NodeCaptureAssist ) && propToValueMap[ParticipantStats.PropertyNames.NodeCaptureAssist] is long )
        {
            participantStats.NodeCaptureAssist = (long)propToValueMap[ParticipantStats.PropertyNames.NodeCaptureAssist];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.NodeCaptureAssist ) && propToValueMap[ParticipantStats.PropertyNames.NodeCaptureAssist] is int )
        {
            participantStats.NodeCaptureAssist = (int)propToValueMap[ParticipantStats.PropertyNames.NodeCaptureAssist];
        }

        #endregion

        #region NodeNeutralize Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.NodeNeutralize ) && propToValueMap[ParticipantStats.PropertyNames.NodeNeutralize] is long )
        {
            participantStats.NodeNeutralize = (long)propToValueMap[ParticipantStats.PropertyNames.NodeNeutralize];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.NodeNeutralize ) && propToValueMap[ParticipantStats.PropertyNames.NodeNeutralize] is int )
        {
            participantStats.NodeNeutralize = (int)propToValueMap[ParticipantStats.PropertyNames.NodeNeutralize];
        }

        #endregion

        #region NodeNeutralizeAssist Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.NodeNeutralizeAssist ) && propToValueMap[ParticipantStats.PropertyNames.NodeNeutralizeAssist] is long )
        {
            participantStats.NodeNeutralizeAssist = (long)propToValueMap[ParticipantStats.PropertyNames.NodeNeutralizeAssist];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.NodeNeutralizeAssist ) && propToValueMap[ParticipantStats.PropertyNames.NodeNeutralizeAssist] is int )
        {
            participantStats.NodeNeutralizeAssist = (int)propToValueMap[ParticipantStats.PropertyNames.NodeNeutralizeAssist];
        }

        #endregion

        #region ObjectivePlayerScore Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.ObjectivePlayerScore ) && propToValueMap[ParticipantStats.PropertyNames.ObjectivePlayerScore] is long )
        {
            participantStats.ObjectivePlayerScore = (long)propToValueMap[ParticipantStats.PropertyNames.ObjectivePlayerScore];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.ObjectivePlayerScore ) && propToValueMap[ParticipantStats.PropertyNames.ObjectivePlayerScore] is int )
        {
            participantStats.ObjectivePlayerScore = (int)propToValueMap[ParticipantStats.PropertyNames.ObjectivePlayerScore];
        }

        #endregion

        #region PentaKills Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.PentaKills ) && propToValueMap[ParticipantStats.PropertyNames.PentaKills] is long )
        {
            participantStats.PentaKills = (long)propToValueMap[ParticipantStats.PropertyNames.PentaKills];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.PentaKills ) && propToValueMap[ParticipantStats.PropertyNames.PentaKills] is int )
        {
            participantStats.PentaKills = (int)propToValueMap[ParticipantStats.PropertyNames.PentaKills];
        }

        #endregion

        #region PhysicalDamageDealt Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.PhysicalDamageDealt ) && propToValueMap[ParticipantStats.PropertyNames.PhysicalDamageDealt] is long )
        {
            participantStats.PhysicalDamageDealt = (long)propToValueMap[ParticipantStats.PropertyNames.PhysicalDamageDealt];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.PhysicalDamageDealt ) && propToValueMap[ParticipantStats.PropertyNames.PhysicalDamageDealt] is int )
        {
            participantStats.PhysicalDamageDealt = (int)propToValueMap[ParticipantStats.PropertyNames.PhysicalDamageDealt];
        }

        #endregion

        #region PhysicalDamageDealtToChampions Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.PhysicalDamageDealtToChampions ) && propToValueMap[ParticipantStats.PropertyNames.PhysicalDamageDealtToChampions] is long )
        {
            participantStats.PhysicalDamageDealtToChampions = (long)propToValueMap[ParticipantStats.PropertyNames.PhysicalDamageDealtToChampions];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.PhysicalDamageDealtToChampions ) && propToValueMap[ParticipantStats.PropertyNames.PhysicalDamageDealtToChampions] is int )
        {
            participantStats.PhysicalDamageDealtToChampions = (int)propToValueMap[ParticipantStats.PropertyNames.PhysicalDamageDealtToChampions];
        }

        #endregion

        #region PhysicalDamageTaken Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.PhysicalDamageTaken ) && propToValueMap[ParticipantStats.PropertyNames.PhysicalDamageTaken] is long )
        {
            participantStats.PhysicalDamageTaken = (long)propToValueMap[ParticipantStats.PropertyNames.PhysicalDamageTaken];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.PhysicalDamageTaken ) && propToValueMap[ParticipantStats.PropertyNames.PhysicalDamageTaken] is int )
        {
            participantStats.PhysicalDamageTaken = (int)propToValueMap[ParticipantStats.PropertyNames.PhysicalDamageTaken];
        }

        #endregion

        #region QuadraKills Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.QuadraKills ) && propToValueMap[ParticipantStats.PropertyNames.QuadraKills] is long )
        {
            participantStats.QuadraKills = (long)propToValueMap[ParticipantStats.PropertyNames.QuadraKills];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.QuadraKills ) && propToValueMap[ParticipantStats.PropertyNames.QuadraKills] is int )
        {
            participantStats.QuadraKills = (int)propToValueMap[ParticipantStats.PropertyNames.QuadraKills];
        }

        #endregion

        #region SightWardsBoughtInGame Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.SightWardsBoughtInGame ) && propToValueMap[ParticipantStats.PropertyNames.SightWardsBoughtInGame] is long )
        {
            participantStats.SightWardsBoughtInGame = (long)propToValueMap[ParticipantStats.PropertyNames.SightWardsBoughtInGame];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.SightWardsBoughtInGame ) && propToValueMap[ParticipantStats.PropertyNames.SightWardsBoughtInGame] is int )
        {
            participantStats.SightWardsBoughtInGame = (int)propToValueMap[ParticipantStats.PropertyNames.SightWardsBoughtInGame];
        }

        #endregion

        #region TeamObjective Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TeamObjective ) && propToValueMap[ParticipantStats.PropertyNames.TeamObjective] is long )
        {
            participantStats.TeamObjective = (long)propToValueMap[ParticipantStats.PropertyNames.TeamObjective];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TeamObjective ) && propToValueMap[ParticipantStats.PropertyNames.TeamObjective] is int )
        {
            participantStats.TeamObjective = (int)propToValueMap[ParticipantStats.PropertyNames.TeamObjective];
        }

        #endregion

        #region TotalDamageDealt Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalDamageDealt ) && propToValueMap[ParticipantStats.PropertyNames.TotalDamageDealt] is long )
        {
            participantStats.TotalDamageDealt = (long)propToValueMap[ParticipantStats.PropertyNames.TotalDamageDealt];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalDamageDealt ) && propToValueMap[ParticipantStats.PropertyNames.TotalDamageDealt] is int )
        {
            participantStats.TotalDamageDealt = (int)propToValueMap[ParticipantStats.PropertyNames.TotalDamageDealt];
        }

        #endregion

        #region TotalDamageDealtToChampions Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalDamageDealtToChampions ) && propToValueMap[ParticipantStats.PropertyNames.TotalDamageDealtToChampions] is long )
        {
            participantStats.TotalDamageDealtToChampions = (long)propToValueMap[ParticipantStats.PropertyNames.TotalDamageDealtToChampions];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalDamageDealtToChampions ) && propToValueMap[ParticipantStats.PropertyNames.TotalDamageDealtToChampions] is int )
        {
            participantStats.TotalDamageDealtToChampions = (int)propToValueMap[ParticipantStats.PropertyNames.TotalDamageDealtToChampions];
        }

        #endregion

        #region TotalDamageTaken Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalDamageTaken ) && propToValueMap[ParticipantStats.PropertyNames.TotalDamageTaken] is long )
        {
            participantStats.TotalDamageTaken = (long)propToValueMap[ParticipantStats.PropertyNames.TotalDamageTaken];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalDamageTaken ) && propToValueMap[ParticipantStats.PropertyNames.TotalDamageTaken] is int )
        {
            participantStats.TotalDamageTaken = (int)propToValueMap[ParticipantStats.PropertyNames.TotalDamageTaken];
        }

        #endregion

        #region TotalHeal Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalHeal ) && propToValueMap[ParticipantStats.PropertyNames.TotalHeal] is long )
        {
            participantStats.TotalHeal = (long)propToValueMap[ParticipantStats.PropertyNames.TotalHeal];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalHeal ) && propToValueMap[ParticipantStats.PropertyNames.TotalHeal] is int )
        {
            participantStats.TotalHeal = (int)propToValueMap[ParticipantStats.PropertyNames.TotalHeal];
        }

        #endregion

        #region TotalPlayerScore Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalPlayerScore ) && propToValueMap[ParticipantStats.PropertyNames.TotalPlayerScore] is long )
        {
            participantStats.TotalPlayerScore = (long)propToValueMap[ParticipantStats.PropertyNames.TotalPlayerScore];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalPlayerScore ) && propToValueMap[ParticipantStats.PropertyNames.TotalPlayerScore] is int )
        {
            participantStats.TotalPlayerScore = (int)propToValueMap[ParticipantStats.PropertyNames.TotalPlayerScore];
        }

        #endregion

        #region TotalScoreRank Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalScoreRank ) && propToValueMap[ParticipantStats.PropertyNames.TotalScoreRank] is long )
        {
            participantStats.TotalScoreRank = (long)propToValueMap[ParticipantStats.PropertyNames.TotalScoreRank];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalScoreRank ) && propToValueMap[ParticipantStats.PropertyNames.TotalScoreRank] is int )
        {
            participantStats.TotalScoreRank = (int)propToValueMap[ParticipantStats.PropertyNames.TotalScoreRank];
        }

        #endregion

        #region TotalTimeCrowdControlDealt Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalTimeCrowdControlDealt ) && propToValueMap[ParticipantStats.PropertyNames.TotalTimeCrowdControlDealt] is long )
        {
            participantStats.TotalTimeCrowdControlDealt = (long)propToValueMap[ParticipantStats.PropertyNames.TotalTimeCrowdControlDealt];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalTimeCrowdControlDealt ) && propToValueMap[ParticipantStats.PropertyNames.TotalTimeCrowdControlDealt] is int )
        {
            participantStats.TotalTimeCrowdControlDealt = (int)propToValueMap[ParticipantStats.PropertyNames.TotalTimeCrowdControlDealt];
        }

        #endregion

        #region TotalUnitsHealed Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalUnitsHealed ) && propToValueMap[ParticipantStats.PropertyNames.TotalUnitsHealed] is long )
        {
            participantStats.TotalUnitsHealed = (long)propToValueMap[ParticipantStats.PropertyNames.TotalUnitsHealed];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TotalUnitsHealed ) && propToValueMap[ParticipantStats.PropertyNames.TotalUnitsHealed] is int )
        {
            participantStats.TotalUnitsHealed = (int)propToValueMap[ParticipantStats.PropertyNames.TotalUnitsHealed];
        }

        #endregion

        #region TowerKills Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TowerKills ) && propToValueMap[ParticipantStats.PropertyNames.TowerKills] is long )
        {
            participantStats.TowerKills = (long)propToValueMap[ParticipantStats.PropertyNames.TowerKills];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TowerKills ) && propToValueMap[ParticipantStats.PropertyNames.TowerKills] is int )
        {
            participantStats.TowerKills = (int)propToValueMap[ParticipantStats.PropertyNames.TowerKills];
        }

        #endregion

        #region TripleKills Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TripleKills ) && propToValueMap[ParticipantStats.PropertyNames.TripleKills] is long )
        {
            participantStats.TripleKills = (long)propToValueMap[ParticipantStats.PropertyNames.TripleKills];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TripleKills ) && propToValueMap[ParticipantStats.PropertyNames.TripleKills] is int )
        {
            participantStats.TripleKills = (int)propToValueMap[ParticipantStats.PropertyNames.TripleKills];
        }

        #endregion

        #region TrueDamageDealt Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TrueDamageDealt ) && propToValueMap[ParticipantStats.PropertyNames.TrueDamageDealt] is long )
        {
            participantStats.TrueDamageDealt = (long)propToValueMap[ParticipantStats.PropertyNames.TrueDamageDealt];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TrueDamageDealt ) && propToValueMap[ParticipantStats.PropertyNames.TrueDamageDealt] is int )
        {
            participantStats.TrueDamageDealt = (int)propToValueMap[ParticipantStats.PropertyNames.TrueDamageDealt];
        }

        #endregion

        #region TrueDamageDealtToChampions Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TrueDamageDealtToChampions ) && propToValueMap[ParticipantStats.PropertyNames.TrueDamageDealtToChampions] is long )
        {
            participantStats.TrueDamageDealtToChampions = (long)propToValueMap[ParticipantStats.PropertyNames.TrueDamageDealtToChampions];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TrueDamageDealtToChampions ) && propToValueMap[ParticipantStats.PropertyNames.TrueDamageDealtToChampions] is int )
        {
            participantStats.TrueDamageDealtToChampions = (int)propToValueMap[ParticipantStats.PropertyNames.TrueDamageDealtToChampions];
        }

        #endregion

        #region TrueDamageTaken Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TrueDamageTaken ) && propToValueMap[ParticipantStats.PropertyNames.TrueDamageTaken] is long )
        {
            participantStats.TrueDamageTaken = (long)propToValueMap[ParticipantStats.PropertyNames.TrueDamageTaken];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.TrueDamageTaken ) && propToValueMap[ParticipantStats.PropertyNames.TrueDamageTaken] is int )
        {
            participantStats.TrueDamageTaken = (int)propToValueMap[ParticipantStats.PropertyNames.TrueDamageTaken];
        }

        #endregion

        #region VisionWardsBoughtInGame Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.VisionWardsBoughtInGame ) && propToValueMap[ParticipantStats.PropertyNames.VisionWardsBoughtInGame] is long )
        {
            participantStats.VisionWardsBoughtInGame = (long)propToValueMap[ParticipantStats.PropertyNames.VisionWardsBoughtInGame];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.VisionWardsBoughtInGame ) && propToValueMap[ParticipantStats.PropertyNames.VisionWardsBoughtInGame] is int )
        {
            participantStats.VisionWardsBoughtInGame = (int)propToValueMap[ParticipantStats.PropertyNames.VisionWardsBoughtInGame];
        }

        #endregion

        #region WardsKilled Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.WardsKilled ) && propToValueMap[ParticipantStats.PropertyNames.WardsKilled] is long )
        {
            participantStats.WardsKilled = (long)propToValueMap[ParticipantStats.PropertyNames.WardsKilled];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.WardsKilled ) && propToValueMap[ParticipantStats.PropertyNames.WardsKilled] is int )
        {
            participantStats.WardsKilled = (int)propToValueMap[ParticipantStats.PropertyNames.WardsKilled];
        }

        #endregion

        #region WardsPlaced Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.WardsPlaced ) && propToValueMap[ParticipantStats.PropertyNames.WardsPlaced] is long )
        {
            participantStats.WardsPlaced = (long)propToValueMap[ParticipantStats.PropertyNames.WardsPlaced];
        }

        else if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.WardsPlaced ) && propToValueMap[ParticipantStats.PropertyNames.WardsPlaced] is int )
        {
            participantStats.WardsPlaced = (int)propToValueMap[ParticipantStats.PropertyNames.WardsPlaced];
        }

        #endregion

        #region Winner Property

        if( propToValueMap.ContainsKey( ParticipantStats.PropertyNames.Winner ) && propToValueMap[ParticipantStats.PropertyNames.Winner] is bool )
        {
            participantStats.Winner = (bool)propToValueMap[ParticipantStats.PropertyNames.Winner];
        }

        #endregion

        return participantStats;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="matchDetail"></param>
    /// <returns></returns>
    public static Dictionary<String, Object> ParticipantStatsToDictionary( ParticipantStats participantStats )
    {
        if( participantStats == null )
        {
            throw new ArgumentException( "parameter participant is required." );
        }

        Dictionary<String, Object> propToValueMap = new Dictionary<String, Object>();

        //#region ChampionId Property

        //propToValueMap.Add( Participant.PropertyNames.ChampionId, participantStats.ChampionId );

        //#endregion

        return propToValueMap;
    }

    #endregion

    #region Json Converter Inherited Methods

    /// <summary>
    /// Tests to see if the current type can be converted by this converter class
    /// </summary>
    /// <param name="t">Optional - the type to be tested</param>
    /// <returns>true if the type can be converted, false otherwise</returns>
    public override bool CanConvert( Type t )
    {
        if( typeof( MatchDetail ).Equals( t ) )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Converts a dictionary into a MatchDetail
    /// </summary>
    /// <param name="type">Optional - the type of the value parameter</param>
    /// <param name="value">Optional - the dictionary that is to be converted into an instance</param>
    /// <returns>A MatchDetail instance if type and value are not null, null otherwise</returns>
    public override Object ReadJson( Type type, Dictionary<String, Object> value )
    {
        if( !CanConvert( type ) )
        {
            return null;
        }

        if( ( type == null ) || ( value == null ) )
        {
            return null;
        }

        return DictionaryToParticipantStats( value );
    }

    /// <summary>
    /// Converts a ParticipantStats into a dictionary
    /// </summary>
    /// <param name="type">Optional - the type of the value parameter</param>
    /// <param name="value">Optional - the instance that is to be converted into a dictionary</param>
    /// <returns>A Dictionary containing the data contained in the value parameter</returns>
    public override Dictionary<String, Object> WriteJson( Type type, Object value )
    {
        ParticipantStats participantStats = (ParticipantStats)value;
        return ParticipantStatsToDictionary( participantStats );
    }

    #endregion

    #endregion
}
