using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PartyMember : Being
{
    #region Private Member Variables 

    private ParticipantStats stats;

    #endregion
        
    #region Accessors/Modifiers

    public ParticipantStats Stats
    {
        get
        {
            return stats;
        }
    }

    #endregion

    #region Constructors

    public PartyMember() : base()
    {
        
    }

    public PartyMember( Participant participant ) : base ( participant )
    {
        stats = participant.Stats;
    }

    #endregion
}
