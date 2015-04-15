using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetupParty : MonoBehaviour 
{
    [SerializeField]
    private GameObject partyMemberPrefab;
    
	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    /// <summary>
    /// 
    /// </summary>
    /// <param name="party"></param>
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

}
