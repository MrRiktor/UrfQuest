using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartyMemberItem : MonoBehaviour 
{
    [SerializeField]
    private Image portrait;
    [SerializeField]
    private GameObject healthBar;

    private int currentHealth;

    private IPartyMember partyMemberData;
    
	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void InitPartyMember( IPartyMember partyMember )
    {
        partyMemberData = partyMember;
        portrait.sprite = partyMemberData.Portrait;
    }
}
