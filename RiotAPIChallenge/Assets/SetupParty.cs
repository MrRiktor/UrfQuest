using UnityEngine;
using System.Collections;

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
    public void SetupTheParty( Party party )
    {
        for( int i = 0; i < party.PartyMembers.Count; ++i )
        {
            GameObject partyMemberUI = (Instantiate(partyMemberPrefab, Vector3.zero, Quaternion.identity) as GameObject);

            partyMemberUI.GetComponent<PartyMemberItem>().InitPartyMember(party.PartyMembers[i]);

            partyMemberUI.transform.SetParent(this.transform);

            partyMemberUI.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            partyMemberUI.transform.localPosition = Vector3.zero;
        }
    }

    public void SetupTheParty( Enemy[] enemies )
    {
        foreach(Enemy enemy in enemies)
        {
            GameObject partyMemberUI = (Instantiate(partyMemberPrefab, Vector3.zero, Quaternion.identity) as GameObject);

            partyMemberUI.GetComponent<PartyMemberItem>().InitPartyMember(enemy);

            partyMemberUI.transform.SetParent(this.transform);

            partyMemberUI.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            partyMemberUI.transform.localPosition = Vector3.zero;
        }
    }

}
