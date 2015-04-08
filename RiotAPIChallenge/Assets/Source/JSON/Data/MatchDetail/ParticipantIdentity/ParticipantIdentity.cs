using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
