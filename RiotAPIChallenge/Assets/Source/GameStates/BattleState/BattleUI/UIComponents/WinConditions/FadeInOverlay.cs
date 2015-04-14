using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class FadeInOverlay : MonoBehaviour 
{
    [SerializeField] private Image image;
    [SerializeField] private GameObject button;
    [SerializeField] private SoundManager.SoundClip soundClip;

    

    private float rate = 0.0f;

    private float interpolateSpeed = 1.0f;

	// Use this for initialization
	void Start () 
    {
        SoundManager.GetInstance().PlaySoundOnce(soundClip);
        this.image.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () 
    {
        rate += Time.deltaTime * interpolateSpeed;

        this.image.color = Color.Lerp(Color.clear, Color.white, rate);

        if(rate >= 1)
        {
            button.SetActive(true);
        }
	}
}
