#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: FadeInOverlay.cs
 * Date Created: 4/14/2015 12:38PM EST
 * 
 * Description: Used for the victory and defeat prefabs to fade themselves in when activated from the battle system.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:40 PM
 *              - Modified: Matthew "Riktor" Baker - 4/16/2015 9:45 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using UnityEngine.UI;

#endregion

public class FadeInOverlay : MonoBehaviour
{
    #region Private variables

    #region SerializeFields

    /// <summary>
    /// the image we are fading in.
    /// </summary>
    [SerializeField] private Image image;

    /// <summary>
    /// the continue button.
    /// </summary>
    [SerializeField] private GameObject button;
    
    /// <summary>
    /// the sound clip we want to play for this fade in.
    /// </summary>
    [SerializeField] private SoundManager.SoundClip soundClip;

    #endregion

    /// <summary>
    /// The rate of the interpolation.
    /// </summary>
    private float rate = 0.0f;

    /// <summary>
    /// The interpolation speed.
    /// </summary>
    private float interpolateSpeed = 1.0f;
   
    #endregion

    #region Native Unity Functionality

    /// <summary>
    /// Use this for initialization
    /// </summary>
	void Start () 
    {
        SoundManager.GetInstance().PlaySoundOnce(soundClip);
        this.image.color = Color.clear;
	}
	    	
	/// <summary>
    /// Update is called once per frame.
    /// 
    /// Interpolates the transparency of the image, when fully revealed it activates the button.
	/// </summary>
    void Update () 
    {
        rate += Time.deltaTime * interpolateSpeed;

        this.image.color = Color.Lerp(Color.clear, Color.white, rate);

        if(rate >= 1)
        {
            button.SetActive(true);
        }
    }

    #endregion
}
