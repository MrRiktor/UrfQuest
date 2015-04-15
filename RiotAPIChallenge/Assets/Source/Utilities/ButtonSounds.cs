using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSounds : Button
{
    Color32 colorException = new Color32( 218, 165, 32, 255 );
    Color32 originColor;

    [SerializeField]
    private AudioClip buttonHover;

    [SerializeField]
    private AudioClip buttonPress;

    private AudioSource audioSource;

    private Image image;

    void Awake( )
    {
        image = GetComponent<Image>( );
        originColor = image.color;
    }

    public override void OnPointerEnter( PointerEventData eventData )
    {
        if ( audioSource == null )
            InitAudioSource( );

        if(image.color != colorException)
            image.color = colors.highlightedColor;

        audioSource.clip = buttonHover;
        audioSource.Play( );
    }

    public override void OnPointerExit( PointerEventData eventData )
    {
        if(image.color != colorException)
            image.color = originColor;
    }

    public override void OnPointerDown( PointerEventData eventData )
    {
        if(image.color != colorException)
            image.color = colors.pressedColor;

        if ( audioSource == null )
            InitAudioSource( );

        audioSource.clip = buttonPress;
        audioSource.Play( );
    }

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
}