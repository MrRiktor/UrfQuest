#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: UpdateHealthBarScale.cs
 * Date Created: 4/14/2015 12:37AM EST
 * 
 * Description: This class is solely responsible for scaling the health bar it is attached to.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/15/2015 12:05 AM
 *              - Modified: Matthew "Riktor" Baker - 4/16/2015 8:56 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;

#endregion

public class UpdateHealthBarScale : MonoBehaviour
{
    #region Public Methods

    /// <summary>
    /// Scales the transform of the object this script is attached to.
    /// </summary>
    /// <param name="healthPercentage"> The health percentage we are to scale to. </param>
    public void SetHealth( float healthPercentage )
    {
        this.transform.localScale = new Vector3(healthPercentage, this.transform.localScale.y, this.transform.localScale.z);

        if(this.transform.localScale.x < 0)
        {
            this.transform.localScale = new Vector3(0.0f, this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    #endregion
}
