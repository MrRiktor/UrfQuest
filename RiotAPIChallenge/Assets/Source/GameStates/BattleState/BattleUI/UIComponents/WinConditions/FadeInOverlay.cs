using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class FadeInOverlay : MonoBehaviour 
{
    [SerializeField] private Image image;

    private float rate = 0.0f;

    private float interpolateSpeed = 1.0f;

	// Use this for initialization
	void Start () 
    {
        this.image.color = Color.clear;
	}
	
	// Update is called once per frame
	void Update () 
    {
        rate += Time.deltaTime * interpolateSpeed;

        this.image.color = Color.Lerp(Color.clear, Color.white, rate);
	}
}
