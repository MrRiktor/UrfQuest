using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 
/// </summary>
public enum Region
{
    na = 0, // NorthAmerica
    br,     // Brazil
    eune,   // EUNordicAndEast
    euw,    // EuropeWest
    kr,     // Korea
    lan,    // LatinAmericaNorth
    las,    // LatinAmericaSouth
    oce,    // Oceania
    ru,     // Russia
    tr,     // Turkey
}

/// <summary>
/// 
/// </summary>
public static class RiotAPIConstants
{
    private static String API_KEY_SUFFIX = "d0fed0d2-9eaf-4436-a5d3-d5e2be76474d";

    /// <summary>
    /// 
    /// </summary>
    private static String API_Prefix = "https://na.api.pvp.net/api/lol/";

    /// <summary>
    /// 
    /// </summary>
    private static String DD_API_Prefix = "http://ddragon.leagueoflegends.com/cdn/";

    private static String Global_API_Prefix = "https://global.api.pvp.net/api/lol/";

    /// <summary>
    /// 
    /// </summary>
    private static String DD_Version = "5.5.2/";
    
    /// <summary>
    /// 
    /// </summary>
    //private static String Observer_Prefix = "https://na.api.pvp.net/observer-mode/rest/";

    /// <summary>
    /// 
    /// </summary>
    //private static String Shard_Prefix = "http://status.leagueoflegends.com/shards/";

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ChampionName"></param>
    /// <param name="skinIndex"></param>
    /// <returns></returns>
    public static String CHAMPION_PORTRAIT_HYPERLINK(String ChampionName="Aatrox", byte skinIndex = 0)
    {
        // Example:  http//ddragon.leagueoflegends.com/cdn/img/champion/loading/Aatrox_0.jpg
        return DD_API_Prefix + "img/champion/loading/" + ChampionName + "_" + skinIndex.ToString() + ".jpg";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="ChampionName"></param>
    /// <returns></returns>
    public static String CHAMPION_ICON_HYPERLINK( String ChampionName="Aatrox" )
    {
        // Example: http//ddragon.leagueoflegends.com/cdn/5.2.1/img/champion/Aatrox.png
        return DD_API_Prefix + DD_Version + "img/champion/" + ChampionName + ".png";
    }

    /// <summary>
    /// Returns a link to a champions details JSON string.
    /// </summary>
    /// <param name="id"> The champion ID. </param>
    /// <param name="region"> The region we are looking to grab from. </param>
    /// <returns></returns>
    public static String CHAMPION_STATIC_DATA( int id=17, ChampData champData=ChampData.minimal, Region region=Region.na )
    {
        // EXAMPLE: https;//global.api.pvp.net/api/lol/static-data/na/v1.2/champion/30?api_key=1069372c-3d2d-4734-964c-53434511b8f8
        if (champData == ChampData.minimal)
        {
            return API_Prefix + "static-data/" + region.ToString() + "/" + "v1.2/champion/" + id.ToString() + "&api_key=" + API_KEY_SUFFIX;
        }
        else 
        {
            return API_Prefix + "static-data/" + region.ToString() + "/" + "v1.2/champion/" + id.ToString() + "?champData=" + champData.ToString() + "&api_key=" + API_KEY_SUFFIX;
        }
    }

    #region Public Methods

    public static String API_CHALLENGE_MATCH_LIST( Region region, long beginDate )
    {
        long remainder = (beginDate % 100);
        
        if ( remainder != 0 )
        {
            beginDate -= remainder;
        }

        UnityEngine.Debug.Log(beginDate);

        // https;//na.api.pvp.net//api/lol/{region}/v4.1/game/ids?beginDate={beginDate}&api_key=API_KEY_SUFFIX
        return API_Prefix + region.ToString() + "/" + "v4.1/game/ids?beginDate=" + beginDate + "&api_key=" + API_KEY_SUFFIX;
    }

    public static String CHAMPIONv1_2(Region region, ChampData champData)
    {
        // https;//global.api.pvp.net/api/lol/static-data/na/v1.2/champion?champData=stats&api_key=API_KEY_SUFFIX
        return Global_API_Prefix + "static-data/" + region.ToString() + "/" + "v1.2/champion?champData=" + champData.ToString() + "&api_key=" + API_KEY_SUFFIX;
    }

    public static String MATCHv2_2(Region region, long matchID)
    {
        // "/api/lol/{region}/v2.2/match/{matchID}?api_key=API_KEY_SUFFIX"
        return API_Prefix + region.ToString() + "/" + "v2.2/match/" + matchID + "?api_key=" + API_KEY_SUFFIX;
    }

    #endregion

}

