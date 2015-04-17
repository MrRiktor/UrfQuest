#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: PartyMemberItem.cs
 * Date Created: 4/14/2015 12:37PM EST
 * 
 * Description: PartyMemberItem is the monobehavior that is attached to the PartyMember GameObject.
 *              This class handles all of the interaction between the party members objects.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 3:56 AM
 *              - Modified: Matthew "Riktor" Baker - 4/16/2015 8:37 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using UnityEngine.UI;

#endregion

public class PartyMemberItem : MonoBehaviour
{
    #region Private Variables

    /// <summary>
    /// The state of the party member concerning combat.
    /// </summary>
    public enum CombatStates
    {
        None,
        Ready,
        Attacking,
        Taunting,
    };
    
    /// <summary>
    /// The state of the party member concerning physical movement.
    /// </summary>
    private enum PlayerStates
    {
        Waiting,
        Ready,
        MoveToTarget,
        ReturnToOrigin,
        OnCooldown,
    }

    #region SerializeField Variables

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Image portrait = null;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private RectTransform healthBar = null;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Text healthBarText = null;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private GameObject combatText = null;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] 
    private GameObject attackTauntBar = null;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private GameObject targetIcon = null;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private GameObject tauntIcon = null;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private GameObject borderPanel = null;

    #endregion

    #region Game Information

    /// <summary>
    /// The party members data. (Attack, HealthPool, Movementspeed, etc.)
    /// </summary>
    private IPartyMember partyMemberData;

    /// <summary>
    /// Combat stats for the partyMember (Alive, IsEnemy, CurrentHealth).
    /// </summary>
    private CombatStatus combatStatus = new CombatStatus();

    private bool isMitigating = false;

    #endregion

    #region Movement Variables

    /// <summary>
    /// 
    /// </summary>
    private float rate = 0.0f;
    
    /// <summary>
    /// 
    /// </summary>
    private float interpolationSpeed = 1.0f;

    #endregion

    #region PartyMemberItem States

    /// <summary>
    /// 
    /// </summary>
    private PlayerStates playerState = PlayerStates.Waiting;

    /// <summary>
    /// Defines what state of their turn the player is in.
    /// </summary>
    public CombatStates combatState = CombatStates.None;

    public CombatStates CombatState
    {
        get
        {
            return this.combatState;
        }
        set
        {
            this.combatState = value;
        }
    }

    public bool IsMitigating
    {
        get
        {
            return this.isMitigating;
        }
        set
        {
            this.isMitigating = value;
        }
    }


    #endregion

    #region Targets

    /// <summary>
    /// The Target I would like to attack.
    /// </summary>
    private PartyMemberItem desiredTarget = null;

    /// <summary>
    /// The target I am forced to attack even if my desired is different.
    /// </summary>
    private PartyMemberItem forcedTarget = null;

    #endregion

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
    /// Accessor for the combatstatus data.
    /// </summary>
    public CombatStatus CombatStatus
    {
        get
        {
            return this.combatStatus;
        }
    }

    #endregion

    #region Native Unity Functionality

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        this.combatStatus.CurrentHealth = partyMemberData.HealthPool;
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        if (this.playerState.Equals(PlayerStates.MoveToTarget))
        {
            MoveToTarget( GetAttackTarget() );
        }
        else if (this.playerState.Equals(PlayerStates.ReturnToOrigin))
        {
            ReturnToOrigin();
        }
    }

    #endregion

    #region Public Methods
   
    #region Initialization

    /// <summary>
    /// 
    /// </summary>
    /// <param name="partyMember"></param>
    public void InitPartyMember(IPartyMember partyMember, Being.BeingType beingType)
    {
        this.combatStatus.BeingType = beingType;
        this.healthBarText.text = partyMember.HealthPool.ToString();

        partyMemberData = partyMember;
        portrait.sprite = partyMemberData.Portrait;
    }

    /// <summary>
    /// Resets the states of the PartyMember
    /// </summary>
    public void ResetState()
    {
        this.CombatState = CombatStates.None;
        this.playerState = PlayerStates.Waiting;
    }

    #endregion

    /// <summary>
    /// Returns whether the party member is waiting to move or not.
    /// </summary>
    /// <returns> If the party member is waiting to attack this turn. </returns>
    public bool IsWaiting()
    {
        return (this.playerState.Equals(PlayerStates.Waiting)) ? true : false;
    }

    /// <summary>
    /// Returns whether the party member is on cooldown or not.
    /// </summary>
    /// <returns> If the party member has already attacked this turn. </returns>
    public bool IsOnCooldown()
    {
        return (this.playerState.Equals(PlayerStates.OnCooldown)) ? true : false;
    }

    /// <summary>
    /// Sets the Active state of the attack/taunt bar GameObject.
    /// </summary>
    /// <param name="isActive"> The intended state of the attack/taunt bar </param>
    public void SetAttackTauntBarActive( bool isActive )
    {
        if (this.attackTauntBar != null)
        {
            this.attackTauntBar.SetActive(isActive);
        }
    }

    /// <summary>
    /// Sets the Active state of the border panel GameObject
    /// </summary>
    /// <param name="isActive"> The intended state of the border panel. </param>
    public void SetBorderPanelActive( bool isActive )
    {
        if (this.borderPanel != null)
        {
            this.borderPanel.SetActive(isActive);
        }
    }

    /// <summary>
    /// Called when the mouse pointer hovers over the PartyMember's gameObject,
    /// is called from the EventTriggers OnPointerEnter and OnPointerExit.
    /// </summary>
    /// <param name="isActive"> The intended state of the border panel. </param>
    public void OnHover(bool isActive)
    {
        if (this.borderPanel != null && this.CombatStatus.BeingType == Being.BeingType.Enemy)
        {
            if (this.playerState == PlayerStates.MoveToTarget || this.playerState == PlayerStates.ReturnToOrigin)
            {
                this.borderPanel.SetActive(false);
            }
            else if ( this.CombatStatus.IsAlive() )
            {
                this.borderPanel.SetActive(isActive);
            }
            else
            {
                this.borderPanel.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Sets the Active state of the target icon GameObject
    /// </summary>
    /// <param name="isActive"> The intended state of the target icon. </param>
    public void SetTargetIconActive( bool isActive )
    {
        this.targetIcon.SetActive(isActive);
    }

    /// <summary>
    /// Sets the Active state of the taunt icon GameObject
    /// </summary>
    /// <param name="isActive"> The intended state of the taunt icon. </param>
    public void SetTauntIconActive( bool isActive )
    {
        this.tauntIcon.SetActive(isActive);
    }

    /// <summary>
    /// Is called on a PartyMember when they take damage from another PartyMember object.
    /// </summary>
    /// <param name="Damage"> the amount of damage to be taken. </param>
    public void TakeDamage( long incomingDamage )
    {
        float modifiedDamage = Mathf.Round(ApplyDamageReduction(incomingDamage));

        this.UpdateScore(modifiedDamage);

        this.CombatStatus.CurrentHealth -= modifiedDamage;

        float healthPercent = (this.CombatStatus.CurrentHealth / (float)partyMemberData.HealthPool);

        this.healthBar.GetComponent<UpdateHealthBarScale>().SetHealth(healthPercent);

        PlayCombatText(modifiedDamage);

        this.healthBarText.text = (this.CombatStatus.CurrentHealth > 0 ? this.CombatStatus.CurrentHealth.ToString() : "0");
    }
    
    /// <summary>
    /// Updates the game score based upon the damage taken or dealt.
    /// </summary>
    /// <param name="damageDone"> the damage done to this PartyMember. </param>
    private void UpdateScore( float damageDone )
    {
        //If the player attacked an enemy.
        if (this.CombatStatus.BeingType == Being.BeingType.Enemy)
        {
            GameData.Score += damageDone;
        }
        else // An enemy attacked a player
        {
            float healthDifference = Mathf.Round(this.CombatStatus.CurrentHealth - damageDone);

            if (healthDifference < 0.0f)
            {
                GameData.Score -= (healthDifference + damageDone);
            }
            else
            {
                GameData.Score -= damageDone;
            }
        }
    }
    
    /// <summary>
    /// Calculates a mitigated damage based upon the Damage value passed in.
    /// Note: Can be used in the future if we want to apply more damage reduction from items or other things.
    /// </summary>
    /// <param name="Damage"></param>
    /// <returns></returns>
    private float ApplyDamageReduction( long Damage )
    {
        if (this.isMitigating)
        {
            float reducedDamage = (float)(Damage * 0.75f);
            return reducedDamage;
        }
        return Damage;
    }

    /// <summary>
    /// Command to attack the current target...
    /// </summary>
    /// <param name="target"></param>
    public void AttackTarget()
    {
        PartyMemberItem target = GetAttackTarget();

        if (target != null)
        {
            this.playerState = PlayerStates.MoveToTarget;

            //Place attack execution here:
            target.TakeDamage(this.partyMemberData.AttackDamage);
            this.CombatState = CombatStates.None;
        }
        else
        {
            Debug.LogError("PartyMemberItem::AttackTarget() - target was null");
        }
    }
   
    /// <summary>
    /// Called by BattleManager when the attack button for this PartyMember is clicked.
    /// </summary>
    public void AttackClicked()
    {
        this.CombatState = CombatStates.Attacking;
        this.SetAttackTauntBarActive(false);
    }

    /// <summary>
    /// Command to Taunt the current target.
    /// </summary>
    public void TauntTarget()
    {
        if (this.desiredTarget != null)
        {
            this.desiredTarget.forcedTarget = this;
            this.playerState = PlayerStates.OnCooldown;
            this.CombatState = CombatStates.Taunting;
            this.IsMitigating = true;
        }
    }

    /// <summary>
    /// Called by BattleManager when the taunt button for this PartyMember is clicked.
    /// </summary>
    public void TauntClicked()
    {
        if (this.desiredTarget != null && this.desiredTarget.CombatStatus.IsAlive() == true)
        {
            SetTauntIconActive(true);
            SoundManager.GetInstance().PlayPrioritySound(SoundManager.SoundClip.TauntSound);
            this.CombatState = PartyMemberItem.CombatStates.Taunting;
            SetAttackTauntBarActive(false);
        }
        else
        {
            SoundManager.GetInstance().PlaySound(SoundManager.SoundClip.FailClick);
            //TODO: Add a UI element for this warning. OR a sound feedback.
            //Debug.Log("You must pick a target to taunt.");
        }
    }

    /// <summary>
    /// Sets my desired Target
    /// </summary>
    /// <param name="target"></param>
    public void SetTarget( PartyMemberItem target )
    {
        if (target != null)
        {
            this.desiredTarget = target;
        }
    }

    /// <summary>
    /// Returns the attack target of this PartyMemberItem.
    /// </summary>
    /// <returns></returns>
    public PartyMemberItem GetAttackTarget()
    {
        if (this.forcedTarget != null && this.forcedTarget.CombatStatus.IsAlive() == true)
        {
            return this.forcedTarget;
        }
        else if (this.desiredTarget != null && desiredTarget.CombatStatus.IsAlive() == true)
        {
            return this.desiredTarget;
        }
        else 
        { 
            return null;
        }
    }

    /// <summary>
    /// Returns the taunt target of this PartyMemberItem.
    /// </summary>
    /// <returns> the taunted target. </returns>
    public PartyMemberItem GetTauntTarget()
    {
        if (this.desiredTarget != null && this.desiredTarget.CombatStatus.IsAlive() == true)
        {
            return this.desiredTarget;
        }
        else
        {
            return null;
        }
    }
        
    #endregion

    #region Private Methods
    
    /// <summary>
    /// Translates the PartyMemberItem GameObject to a target location
    /// </summary>
    private void MoveToTarget( PartyMemberItem target )
    {
        rate += Time.deltaTime * interpolationSpeed;

        // This is done so that we can correctly render the UI when attacks are happening. 
        // It looks ugly but I can't think of another way to access what I need.
        this.transform.parent.transform.parent.SetAsLastSibling();

        this.transform.GetChild(1).position = Vector3.Lerp( this.transform.GetChild(1).position, target.transform.position, rate);

        if (rate >= 0.75f)
        {
            rate = 0;
            SoundManager.GetInstance().PlayPrioritySound(this.PartyMemberData.AttackClip);
            playerState = PlayerStates.ReturnToOrigin;
        }
    }

    /// <summary>
    /// Returns the PartyMemberItem GameObject to its original position.
    /// </summary>
    private void ReturnToOrigin()
    {
        rate += Time.deltaTime * interpolationSpeed;
        this.transform.GetChild(1).position = Vector3.Lerp(this.transform.GetChild(1).position, this.transform.position, rate);

        if (rate >= 1 && !SoundManager.GetInstance().IsPriorityClipPlaying())
        {
            rate = 0;
            playerState = PlayerStates.OnCooldown;

            PartyMemberItem target = (this.forcedTarget == null) ? this.desiredTarget : this.forcedTarget;

            if (target.combatStatus.HealthState == CombatStatus.HealthStates.Dying)
            {
                target.portrait.color = Color.red;
                SetBorderPanelActive(false);
                target.SetTargetIconActive(false);
                target.combatStatus.HealthState = CombatStatus.HealthStates.Dead;
            }

            // After I attack, Clear my forced target.
            this.forcedTarget = null;
        }
    }

    private void PlayCombatText(float damage)
    {
        combatText.GetComponent<Text>().text = ("-" + damage.ToString());
        combatText.GetComponent<Animator>().SetTrigger("PlayCombatText");
    }

    #endregion
}
