using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartyMemberItem : MonoBehaviour
{
    #region Private Variables

    #region SerializeField Variables

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] public Image portrait;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private RectTransform healthBar;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Text healthBarText;

    #endregion

    /// <summary>
    /// The party members data. (Attack, HealthPool, Movementspeed, etc.)
    /// </summary>
    private IPartyMember partyMemberData;

    /// <summary>
    /// The partyMembers current health.
    /// </summary>
    private long currentHealth = 1;

    private float lastHealth = 1;

    private bool isAlive = true;

    private bool isEnemy = false;

    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// The party members data, this is all readonly data.
    /// </summary>
    public IPartyMember PartyMemberData
    {
        get
        {
            return this.partyMemberData;
        }
    }

    /// <summary>
    /// Is the partyMember still alive or is he dead.
    /// </summary>
    public bool IsAlive
    {
        get
        {
            return isAlive;
        }
    }

    /// <summary>
    /// Is the partyMember still alive or is he dead.
    /// </summary>
    public bool IsEnemy
    {
        get
        {
            return isEnemy;
        }
    }

    #endregion

    #region Native Unity Functionality

    /// <summary>
    /// Use this for initialization
    /// </summary>
	void Start () 
    {
        currentHealth = partyMemberData.HealthPool;
        lastHealth = partyMemberData.HealthPool;
	}

    void Update()
    {
        if (lastHealth > currentHealth && lastHealth > 0)
        {
            UpdateHealthBar();
        }
        
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="partyMember"></param>
    public void InitPartyMember( IPartyMember partyMember, bool isEnemy )
    {
        this.isEnemy = isEnemy;
        this.healthBarText.text = partyMember.HealthPool.ToString();

        partyMemberData = partyMember;
        portrait.sprite = partyMemberData.Portrait;
    }

    /// <summary>
    /// This function updates the healthBar's scale based upon the currentHealth and the maximum health of this party Member.
    /// </summary>
    /// <param name="healthPercent"></param>
    private void UpdateHealthBar()
    {        
        lastHealth -= (Time.deltaTime * 50);

        if (lastHealth < currentHealth)
        {
            lastHealth = currentHealth;
        }        

        if(lastHealth <= 0)
        {
            this.portrait.GetComponent<Image>().color = Color.red;
        }

       /* float tempCurrentHealth = float.Parse(currentHealth.ToString());
        float partyMemberHealthPool =  float.Parse(partyMemberData.HealthPool.ToString());

        float lastHealthPercentage = tempCurrentHealth / partyMemberHealthPool;

        healthBar.localScale = new Vector3(lastHealthPercentage, healthBar.localScale.y);*/

        healthBarText.text = ((long)lastHealth).ToString();
    }

    /// <summary>
    /// Accesses the currentHealth of the partyMember.
    /// </summary>
    /// <returns> The current health of the party member. </returns>
    public long GetCurrentHealth()
    {
        return this.currentHealth;
    }

    public void TakeDamage( long Damage )
    {
        currentHealth -= Damage;

        if(currentHealth <= 0)
        {
            this.isAlive = false;
        }
    }

    #endregion
}
