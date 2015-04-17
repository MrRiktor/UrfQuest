#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: PartyMember.cs
 * Date Created: 4/9/2015 10:53PM EST
 * 
 * Description: The PartyMember data class.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 8:33 PM - Added Comments
 *******************************************************************************/

#endregion

public class PartyMember : Being
{
    #region Private Member Variables 

    /// <summary>
    /// The stats of the Player from the match they belong to.
    /// </summary>
    private ParticipantStats stats;

    #endregion
        
    #region Accessors/Modifiers

    /// <summary>
    /// Accessor for the stats object.
    /// </summary>
    public ParticipantStats Stats
    {
        get
        {
            return stats;
        }
    }

    #endregion

    #region Constructors

    /// <summary>
    /// Default Constructor
    /// </summary>
    public PartyMember() : base()
    {
        
    }

    /// <summary>
    /// Constructor which initializes the stats object based upon the participant passed in.
    /// </summary>
    /// <param name="participant"></param>
    public PartyMember( Participant participant ) : base ( participant )
    {
        stats = participant.Stats;
    }

    #endregion
}
