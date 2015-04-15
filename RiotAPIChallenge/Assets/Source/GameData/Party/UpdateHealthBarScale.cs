using UnityEngine;
using System.Collections;

public class UpdateHealthBarScale : MonoBehaviour 
{
    public void SetHealth( float healthPercentage )
    {
        this.transform.localScale = new Vector3(healthPercentage, this.transform.localScale.y, this.transform.localScale.z);

        if(this.transform.localScale.x < 0)
        {
            this.transform.localScale = new Vector3(0.0f, this.transform.localScale.y, this.transform.localScale.z);
        }
    }
}
