#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: DateMath.cs
 * 
 * Description: Static class used when writing our fetch match ID's functionality.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;

#endregion

public class DateMath
{
    #region Public Methods

    /// <summary>
    /// A Math Function that rounds the epoch time to either 5 or 0 so that 
    /// it conforms to riots API challenge match list call standard.
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public static DateTime RoundDateToFive( DateTime date )
    {
        int remainder = date.Minute % 10;

        if (remainder < 5)
        {
            date = date.AddMinutes(-remainder);
        }
        else
        {
            date = date.AddMinutes((5 - remainder));
        }

        return date;
    }

    #endregion
}
