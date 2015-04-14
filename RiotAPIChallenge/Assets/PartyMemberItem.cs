using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PartyMemberItem : MonoBehaviour
{
    #region Private Variables

    private enum PlayerState
    {
        Waiting,
        Attacking,
        Returning
    };

    #region SerializeField Variables

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] public Image portrait = null;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private RectTransform healthBar = null;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Text healthBarText = null;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject combatText = null;

    #endregion

    /// <summary>
    /// The party members data. (Attack, HealthPool, Movementspeed, etc.)
    /// </summary>
    private IPartyMember partyMemberData;

    /// <summary>
    /// The partyMembers current health.
    /// </summary>
    private long currentHealth = 1;

    /// <summary>
    /// 
    /// </summary>
    private bool isAlive = true;

    /// <summary>
    /// 
    /// </summary>
    private bool isEnemy = false;

    /// <summary>
    /// 
    /// </summary>
    private float rate = 0.0f;

    /// <summary>
    /// 
    /// </summary>
    private float interpolationSpeed = 1.0f;

    /// <summary>
    /// 
    /// </summary>
    private PlayerState currentState = PlayerState.Waiting;

    /// <summary>
    /// 
    /// </summary>
    private PartyMemberItem target = null;


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
	}    

    ///
    public bool IsWaiting()
    {
        if (currentState == PlayerState.Waiting)
            return true;
        else
            return false;
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        if(currentState == PlayerState.Attacking)
        {
            MoveToTarget();
        }
        else if (currentState == PlayerState.Returning)
        {
            ReturnToOrigin();
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
    /// 
    /// </summary>
    /// <param name="Damage"></param>
    public void TakeDamage(long Damage)
    {
        currentHealth -= Damage;

        float healthPercent = ((float)currentHealth / (float)partyMemberData.HealthPool);
                
        healthBar.GetComponent<UpdateHealthBarScale>().SetHealth( currentHealth / partyMemberData.HealthPool );

        PlayCombatText( Damage );
        this.healthBarText.text = (currentHealth > 0 ? currentHealth.ToString() : "0");
        
        if (currentHealth <= 0)
        {
            this.portrait.GetComponent<Image>().color = Color.red;
            this.isAlive = false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="enemy"></param>
    public void SetTarget( PartyMemberItem enemy )
    {
        this.target = enemy;
        this.currentState = PlayerState.Attacking;
    }    
    
    #endregion
    
    #region Private Methods

    /// <summary>
    /// 
    /// </summary>
    private void MoveToTarget()
    {
        rate += Time.deltaTime * interpolationSpeed;
        
        // This is done so that we can correctly render the UI when attacks are happening. 
        // It looks ugly but I can't think of another way to access what I need.
        this.transform.parent.transform.parent.SetAsLastSibling();
        
        this.transform.GetChild(0).position = Vector3.Lerp(this.transform.GetChild(0).position, target.transform.position, rate);

        if(rate >= 0.75f)
        {
            rate = 0;
            target.TakeDamage( this.partyMemberData.AttackDamage );
            currentState = PlayerState.Returning;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void ReturnToOrigin()
    {
        rate += Time.deltaTime * interpolationSpeed;
        this.transform.GetChild(0).position = Vector3.Lerp(this.transform.GetChild(0).position, this.transform.position, rate);

        if (rate >= 1)
        {
            rate = 0;
            currentState = PlayerState.Waiting;
        }
    }

    private void PlayCombatText( long damage )
    {
        combatText.GetComponent<Text>().text = ("-" + damage.ToString());
        combatText.GetComponent<Animator>().SetTrigger("PlayCombatText");
    }

    #endregion
}
