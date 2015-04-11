using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManageHealth : MonoBehaviour 
{
    private int MaxHealth = 1200;
    public float CurrentHealth = 1200;

    [SerializeField]
    private GameObject healthBarValue = null;

    [SerializeField]
    private Text healthNumber = null;

    RectTransform rectTrans = null;

	// Use this for initialization
	void Start () 
    {
        rectTrans = healthBarValue.GetComponent<RectTransform>();

        CurrentHealth = MaxHealth;

        healthNumber.text = CurrentHealth.ToString();
	}
	
	// Update is called once per frame
	void Update () 
    {
        HealthBarCalculation();
	}

    private void HealthBarCalculation()
    {
        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        rectTrans.localScale = new Vector3((CurrentHealth / MaxHealth), rectTrans.localScale.y);
        healthNumber.text = CurrentHealth.ToString();
    }

}
