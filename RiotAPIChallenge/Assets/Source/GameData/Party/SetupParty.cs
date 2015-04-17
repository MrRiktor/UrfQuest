#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: SetupParty.cs
 * Date Created: 4/14/2015 12:37AM EST
 * 
 * Description: Responsible for setting up the Party GameObjects
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/14/2015 7:23 PM
 *              - Modified: Matthew "Riktor" Baker - 4/16/2015 8:50 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using System.Collections.Generic;

#endregion

public class SetupParty : MonoBehaviour
{
    #region Private Member Variables

    /// <summary>
    /// The PartyMember GameObject prefab instance.
    /// </summary>
    [SerializeField]
    private GameObject partyMemberPrefab;

    #endregion

    #region Public Methods

    /// <summary>
    /// Sets up the players party. Instantiating 5 instances of the Partymember GameObject.
    /// </summary>
    /// <param name="party"> The Party we are setting up. </param>
    /// <returns> the list of party member's created. </returns>
    public List<PartyMemberItem> SetupTheParty( Party partyData )
    {
        List<PartyMemberItem> party = new List<PartyMemberItem>(); ;

        for (int i = 0; i < partyData.PartyMembers.Count; ++i)
        {
            GameObject partyMemberUI = (Instantiate(partyMemberPrefab, Vector3.zero, Quaternion.identity) as GameObject);

            partyMemberUI.GetComponent<PartyMemberItem>().InitPartyMember(partyData.PartyMembers[i], Being.BeingType.Player);

            partyMemberUI.transform.SetParent(this.transform);

            partyMemberUI.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            partyMemberUI.transform.localPosition = Vector3.zero;

            party.Add(partyMemberUI.GetComponent<PartyMemberItem>());
        }

        return party;
    }

    /// <summary>
    /// Sets up the enemy's party. Instantiating 5 instances of the Partymember GameObject.
    /// </summary>
    /// <param name="party"> The Party we are setting up. </param>
    /// <returns>the list of enemy party member's created. </returns>
    public List<PartyMemberItem> SetupTheParty(Enemy[] enemies)
    {
        List<PartyMemberItem> party = new List<PartyMemberItem>(); ;

        foreach(Enemy enemy in enemies)
        {
            GameObject partyMemberUI = (Instantiate(partyMemberPrefab, Vector3.zero, Quaternion.identity) as GameObject);

            partyMemberUI.GetComponent<PartyMemberItem>().InitPartyMember(enemy, Being.BeingType.Enemy);

            partyMemberUI.transform.SetParent(this.transform);

            partyMemberUI.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            partyMemberUI.transform.localPosition = Vector3.zero;

            party.Add(partyMemberUI.GetComponent<PartyMemberItem>());
        }

        return party;
    }

    #endregion
}
