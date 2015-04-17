#region File Header

/*******************************************************************************
 * Author: Vincent "Sabin" Biancardi
 * Filename: ButtonSounds.cs
 * Date Created: 4/12/2015 6:50PM EST
 * 
 * Description: A class that is used to plays sounds on button events.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 8:13 PM - Added Comments
 *******************************************************************************/
#endregion

#region Using Directives

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#endregion

public class ButtonSounds : Button
{
    #region Private Methods

    #region SerializeFields

    /// <summary>
    /// the sound for button hover
    /// </summary>
    [SerializeField]
    private AudioClip buttonHover;

    /// <summary>
    /// the sound for button press
    /// </summary>
    [SerializeField]
    private AudioClip buttonPress;

    #endregion

    /// <summary>
    /// The Color exception.
    /// </summary>
    private Color32 colorException = new Color32( 218, 165, 32, 255 );
    
    /// <summary>
    /// The origin color
    /// </summary>
    private Color32 originColor;

    /// <summary>
    /// The audio source
    /// </summary>
    private AudioSource audioSource;

    /// <summary>
    /// The image of the button
    /// </summary>
    private Image image;

    #endregion

    #region Native Unity Functionality

    /// <summary>
    /// Called before the first frame
    /// </summary>
    void Awake( )
    {
        image = GetComponent<Image>( );
        originColor = image.color;
    }

    #endregion

    #region Public Methods
    
    /// <summary>
    /// Overrides UGUI's OnPointerEnter event.
    /// </summary>
    /// <param name="eventData"></param>
    public override void OnPointerEnter( PointerEventData eventData )
    {
        if ( audioSource == null )
            InitAudioSource( );

        if(image.color != colorException)
            image.color = colors.highlightedColor;

        audioSource.clip = buttonHover;
        audioSource.Play( );
    }

    /// <summary>
    /// Overrides UGUI's OnPointerExit event.
    /// </summary>
    /// <param name="eventData"></param>
    public override void OnPointerExit( PointerEventData eventData )
    {
        if(image.color != colorException)
            image.color = originColor;
    }

    /// <summary>
    /// Overrides UGUI's OnPointerDown event.
    /// </summary>
    /// <param name="eventData"></param>
    public override void OnPointerDown( PointerEventData eventData )
    {
        if(image.color != colorException)
            image.color = colors.pressedColor;

        if ( audioSource == null )
            InitAudioSource( );

        audioSource.clip = buttonPress;
        audioSource.Play( );
    }

    #endregion
    
    #region Private Methods

    /// <summary>
    /// Initializes the audio source.
    /// </summary>
    private void InitAudioSource( )
    {
        if ( audioSource == null )
            audioSource = GetComponent<AudioSource>( );

        if ( audioSource == null )
            audioSource = transform.parent.GetComponent<AudioSource>( );

        if ( audioSource == null )
            audioSource = gameObject.AddComponent<AudioSource>( );

        audioSource.playOnAwake = false;
        audioSource.volume = 0.1f;
    }

    #endregion 
}