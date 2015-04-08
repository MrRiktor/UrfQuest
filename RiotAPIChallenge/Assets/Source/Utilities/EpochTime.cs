using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class EpochTime
{
    public static DateTime FromEpoch(this long unixTime)
    {
        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return epoch.AddSeconds( unixTime );
    }

    public static long ToEpoch(this DateTime date)
    {
        var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        return Convert.ToInt64( ( date - epoch ).TotalSeconds );
    }    
}
