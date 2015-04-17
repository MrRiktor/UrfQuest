#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: ParticipantIdentity.cs
 * Date Created: 4/11/2015 8:28PM EST
 * 
 * Description: ParticipantIdentity Data Class
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using System;

#endregion

public class ParticipantIdentity
{
    #region Private Constants

    public static class PropertyNames
    {
        public static readonly String ParticipantId = "participantId";
        public static readonly String Player = "player";
    };

    #endregion

    #region Private Memeber Variables
    
    /// <summary>
    /// Participant ID
    /// </summary>
    private int participantId;

    /// <summary>
    /// Player information
    /// </summary>
    private Player player;

    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// Participant ID
    /// </summary>
    public int ParticipantId
    {
        get 
        {
            return participantId;
        }
        set 
        {
            this.participantId = value;
        }
    }

    /// <summary>
    /// Player information
    /// </summary>
    public Player Player
    {
        get
        {
            return player;
        }
        set
        {
            this.player = value;
        }
    }

    #endregion

    public ParticipantIdentity fromJSON( object obj )
    {
        return this;
    }

}
