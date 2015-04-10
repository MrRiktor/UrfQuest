using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class FetchMatchExample : MonoBehaviour
{
    [SerializeField]
    private long [] matchIDs = { 1783499038,
                                 1783499704,
                                 1783499709,
                                 1783499209,
                                 1783517364 };
    
    private ChampionDB championDB = null;

    private List<Party> parties = new List<Party>();

    void Start()
    {
        JSONUtils.initJsonObjectConversion();
    }

    void Update()
    {
        if ( ChampionDBManager.GetInstance().ChampionDBReady )
        {
            if ( Input.GetKeyDown( KeyCode.A ) )
            {
                for (int i = 0; i < matchIDs.Length; ++i)
                {
                    StartCoroutine(getMatch(matchIDs[i]));
                }
            }
        }
        else
        {
            Debug.LogWarning("ChampionDBManager is not ready. Wait a little longer.");
        }

    }
    
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="date"></param>
    /// <returns></returns>
    public IEnumerator getMatch(long  matchID)
    {
        Fetch fetch = new Fetch(MatchGrabSuccess, failure, RiotAPIConstants.MATCHv2_2(Region.na, matchID), MatchDetail.fromJSON);
            
        return fetch.WaitForUrlData();
    }

    private void MatchGrabSuccess(object obj)
    {
        MatchDetail match = null;
        
        if (obj is MatchDetail)
        {
            match = (obj as MatchDetail);
            
            Debug.LogError("Match ID: " + match.MatchId.ToString());

            Party party = new Party();

            foreach (Participant p in match.Participants)
            {
                if (p.Stats.Winner == true)
                {
                    PartyMember partyMember = new PartyMember(p);

                    Debug.Log("Name: " + partyMember.BeingName + " Attack: " + partyMember.AttackDamage + " | Health: " + partyMember.HealthPool + " | MovementSpeed: " + partyMember.MovementSpeed);

                    party.AddPartyMember(partyMember);
                }
            }

            Debug.LogWarning("Party Averages - Attack: " + party.AttackAverage + " | Health: " + party.HealthAverage + " | MovementSpeed: " + party.MovementSpeedAverage);
            parties.Add(party);
        }
    }

    private void failure(string message)
    {
        Debug.LogError(message);
    }
}
