using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour 
{
    [SerializeField]
    private GameObject EnemyParty = null;
    [SerializeField]
    private GameObject PlayerParty = null;

    private bool teamsInitialized = false;

    private List<IPartyMember> attackQueue = new List<IPartyMember>();


    public void PopulateAttackQueue()
    {
        foreach(IPartyMember partymember in GameData.CurrentParty.PartyMembers)
        {
            attackQueue.Add(partymember);
        }

        foreach(IPartyMember enemy in GameData.StageMap.Stages[GameData.CurrentLevel].Enemies)
        {
            attackQueue.Add(enemy);
        }

        attackQueue.Sort((p1, p2) => (-1 * p1.MovementSpeed.CompareTo(p2.MovementSpeed)));

        Debug.Log("Debug");
    }


	// Use this for initialization
	void Start () 
    {
        InitTeams();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(teamsInitialized)
        {

        }
	}

    private void InitTeams()
    {
        PlayerParty.GetComponent<SetupParty>().SetupTheParty( GameData.CurrentParty);
        EnemyParty.GetComponent<SetupParty>().SetupTheParty( GameData.StageMap.Stages[GameData.CurrentLevel].Enemies );
        PopulateAttackQueue();
        teamsInitialized = true;     
    }

    private IPartyMember GetRandomTarget()
    {
        return null;
    }

}
