#region File Header

/*******************************************************************************
 * Author: Vincent "Sabin" Biancardi
 * Filename: ManageHealth.cs
 * Date Created: 4/11/2015 12:11AM EST
 * 
 * Description: A class that manages health bars.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 8:13 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using UnityEngine.UI;

#endregion

public class ManageHealth : MonoBehaviour
{
    #region Private Variables

    /// <summary>
    /// Max Health
    /// </summary>
    private int MaxHealth = 1200;

    /// <summary>
    /// The Current health.
    /// </summary>
    public float CurrentHealth = 1200;

    /// <summary>
    /// The health bar value game object.
    /// </summary>
    [SerializeField]
    private GameObject healthBarValue = null;

    /// <summary>
    /// The health number 
    /// </summary>
    [SerializeField]
    private Text healthNumber = null;

    /// <summary>
    /// The rectTransform of the health bar.
    /// </summary>
    private RectTransform rectTrans = null;

    #endregion

    #region Native Unity Functionality

    /// <summary>
	/// Used for initialization
	/// </summary>
	void Start () 
    {
        rectTrans = healthBarValue.GetComponent<RectTransform>();

        CurrentHealth = MaxHealth;

        healthNumber.text = CurrentHealth.ToString();
	}
	
    ///<summary>
	/// Update is called once per frame
    ///</summary>
	void Update () 
    {
        HealthBarCalculation();
	}

    #endregion

    #region Private Methods

    /// <summary>
    /// Calculates the scale of the health bar.
    /// </summary>
    private void HealthBarCalculation()
    {
        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        rectTrans.localScale = new Vector3((CurrentHealth / MaxHealth), rectTrans.localScale.y);
        healthNumber.text = CurrentHealth.ToString();
    }

    #endregion
}
