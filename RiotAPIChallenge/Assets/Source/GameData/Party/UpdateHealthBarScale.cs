using UnityEngine;
using System.Collections;

public class UpdateHealthBarScale : MonoBehaviour 
{
    public void SetHealth( float healthPercentage )
    {
        this.transform.localScale = new Vector3(healthPercentage, this.transform.localScale.y);
    }
}
