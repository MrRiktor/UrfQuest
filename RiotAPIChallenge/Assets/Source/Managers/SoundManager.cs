using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{    
    public enum SoundClip
    {
        None,
        WelcomeToSummonersRift,
        EnemySlain,
        AllySlain,
        Ace,
        Victory,
        Defeat,
        exitchampionselect,
    }

    [SerializeField] private AudioSource audioSource = null;

    private SoundClip lastSoundPlayed = SoundClip.None;

    private static SoundManager instance;    

    public static SoundManager GetInstance()
    {
        if(instance == null)
        {
            Debug.LogError("SoundManager is null... it is missing from the heirarchy most likely.");
        }
        return instance;
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void PlaySound(SoundClip soundClip)
    {
        audioSource.clip = Resources.Load<AudioClip>("Sound/" + soundClip.ToString());
        audioSource.Play();
    }

    public void PlaySoundOnce(SoundClip soundClip)
    {
        if (lastSoundPlayed != soundClip)
        {
            audioSource.clip = Resources.Load<AudioClip>("Sound/" + soundClip.ToString());
            audioSource.Play();
            lastSoundPlayed = soundClip;
        }
       
    }

    public string LastSoundPlayed()
    {
        return lastSoundPlayed.ToString();
    }

    public string CurrentClipName()
    {
        return audioSource.clip.name;
    }

    public bool IsClipPlaying()
    {
        return audioSource.isPlaying;
    }
}
