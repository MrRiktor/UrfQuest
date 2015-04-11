using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartyMemberItem : MonoBehaviour 
{

    private Image portrait;
    private GameObject healthBar;

    private PartyMember partyMemberStats;
    
	// Use this for initialization
	void Start () 
    {
        portrait.sprite = partyMemberStats.Portrait;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    private void InitData( PartyMember partyMember )
    {
        
    }
}
