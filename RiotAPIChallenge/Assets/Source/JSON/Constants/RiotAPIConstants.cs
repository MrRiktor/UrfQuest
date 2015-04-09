using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 
/// </summary>
public enum Region
{
    NorthAmerica = 0,
    Brazil,
    EUNordicAndEast,
    EuropeWest,
    Korea,
    LatinAmericaNorth,
    LatinAmericaSouth,
    Oceania,
    Russia,
    Turkey,
}

/// <summary>
/// 
/// </summary>
public static class RiotAPIConstants
{
    private static Dictionary<Region, String> regionMap = new Dictionary<Region, String>
    {
        { Region.NorthAmerica, "na"},
        { Region.Brazil, "br"},
        { Region.EUNordicAndEast, "eune"},
        { Region.EuropeWest, "euw"},
        { Region.Korea, "kr"},
        { Region.LatinAmericaNorth, "lan"},
        { Region.LatinAmericaSouth, "las"},
        { Region.Oceania, "oce"},
        { Region.Russia, "ru"},
        { Region.Turkey, "tr"}
    };

    private static String API_KEY_SUFFIX = "1069372c-3d2d-4734-964c-53434511b8f8";

    /// <summary>
    /// 
    /// </summary>
    private static String API_Prefix = "https://na.api.pvp.net/api/lol/";

    /// <summary>
    /// 
    /// </summary>
    private static String DD_API_Prefix = "http://ddragon.leagueoflegends.com/cdn/";

    /// <summary>
    /// 
    /// </summary>
    private static String DD_Version = "5.2.1/";

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
    public static String CHAMPION_STATIC_DATA( int id=17, ChampData champData=ChampData.minimal, Region region=Region.NorthAmerica )
    {
        // EXAMPLE: https;//global.api.pvp.net/api/lol/static-data/na/v1.2/champion/30?api_key=1069372c-3d2d-4734-964c-53434511b8f8
        if (champData == ChampData.minimal)
        {
            return API_Prefix + "static-data/" + regionMap[region] + "/" + "v1.2/champion/" + id.ToString() + "&api_key=" + API_KEY_SUFFIX;
        }
        else 
        {
            return API_Prefix + "static-data/" + regionMap[region] + "/" + "v1.2/champion/" + id.ToString() + "?champData=" + champData.ToString() + "&api_key=" + API_KEY_SUFFIX;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    //private static String Observer_Prefix = "https://na.api.pvp.net/observer-mode/rest/";

    /// <summary>
    /// 
    /// </summary>
    //private static String Shard_Prefix = "http://status.leagueoflegends.com/shards/";

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
        return API_Prefix + regionMap[region] + "/" + "v4.1/game/ids?beginDate=" + beginDate + "&api_key=" + API_KEY_SUFFIX;
    }

    public static String CHAMPIONv1_2(Region region)
    {
        // https;//na.api.pvp.net/api/lol/na/v1.2/champion?api_key=API_KEY_SUFFIX
        return API_Prefix + regionMap[region] + "/" + "v1.2/champion/" + "?api_key=" + API_KEY_SUFFIX;
    }

    public static String MATCHv2_2(Region region, long matchID)
    {
        // "/api/lol/{region}/v2.2/match/{matchID}?api_key=API_KEY_SUFFIX"
        return API_Prefix + regionMap[region] + "/" + "v2.2/match/" + matchID + "?api_key=" + API_KEY_SUFFIX;
    }

    #endregion

}

