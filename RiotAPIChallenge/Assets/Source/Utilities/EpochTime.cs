#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: EpochTime.cs
 * 
 * Description: Static class used for interpretting a DateTime object to Epochtime.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;

#endregion

public static class EpochTime
{
    #region Public Methods

    /// <summary>
    /// Converters Epochtime to a DateTime
    /// </summary>
    /// <param name="unixTime"></param>
    /// <returns></returns>
    public static DateTime FromEpoch(this long unixTime)
    {
        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return epoch.AddSeconds( unixTime );
    }

    /// <summary>
    /// Converts a DateTime to EpochTime
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static long ToEpoch(this DateTime date)
    {
        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return Convert.ToInt64( ( date - epoch ).TotalSeconds );
    }

    #endregion
}
