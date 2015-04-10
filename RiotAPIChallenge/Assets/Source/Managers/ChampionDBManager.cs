using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ChampionDBManager : MonoBehaviour
{
    #region Singleton

    /// <summary>
    /// 
    /// </summary>
    private static ChampionDBManager instance;

    /// <summary>
    /// Returns the singleton instance of ChampionDBManager
    /// </summary>
    /// <returns> the instance of ChampionDBManager </returns>
    public static ChampionDBManager GetInstance()
    {
        if (instance == null)
        {
            throw new UnityException("trying to access instance of a null instance.");
        }

        return instance;
    }

    #endregion

    #region Private Member Variables

    /// <summary>
    /// 
    /// </summary>
    private ChampionDB championDB;

    /// <summary>
    /// Entire DB is ready including Images.
    /// </summary>
    private bool championDBReady = false;

    /// <summary>
    /// Initial data is ready, sprites are now being retrieved.
    /// </summary>
    private bool championDBInitialized = false;

    /// <summary>
    /// A list to keep track of currently processing image requests.
    /// </summary>
    private List<string> championImageQueue = new List<string>();

    #endregion

    #region Accessors/Modifiers

    /// <summary>
    /// 
    /// </summary>
    public ChampionDB ChampionDB
    {
        get
        {
            return this.championDB;
        }
        set 
        {
            this.championDB = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public bool ChampionDBReady
    {
        get 
        { 
            return championDBReady; 
        }
    }

    #endregion

    #region Native Unity Methods

    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        StartCoroutine( InitializeChampionDatabase( Region.na, ChampData.all ) );
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        if (championImageQueue.Count.Equals(0) && championDBInitialized)
        {
            championDBReady = true;
        }
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    private void InitializationSuccess(object obj)
    {
        this.championDB = obj as ChampionDB;
        
        foreach(KeyValuePair<string, Champion> champion in championDB.Data)
        {
            PushChampionPortraitRequest(champion.Key.ToString());
            PushChampionIconRequest(champion.Key.ToString());
        }

        championDBInitialized = true;
    }

    private void PushChampionPortraitRequest( string name )
    {
        StartCoroutine(GrabChampionPortraits(name));
        championImageQueue.Add(name + "portrait");
    }


    private void PushChampionIconRequest(string name)
    {
        StartCoroutine(GrabChampionIcons(name));
        championImageQueue.Add(name + "icon");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    private void InitializationFailure(string message)
    {
        UnityEngine.Debug.LogError("ChampionDBManager::InitializationFailure - Failed to Initialize Champion Database.");
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="region"></param>
    /// <param name="champData"></param>
    /// <returns></returns>
    private IEnumerator InitializeChampionDatabase(Region region, ChampData champData)
    {
        Fetch fetch = new Fetch(InitializationSuccess, InitializationFailure, RiotAPIConstants.CHAMPIONv1_2(region, champData), ChampionDB.fromJSON);

        return fetch.WaitForUrlData();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private IEnumerator GrabChampionPortraits( string name )
    {
        WWW www = new WWW(RiotAPIConstants.CHAMPION_PORTRAIT_HYPERLINK(name));

        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError("Error: " + www.error + " - Champion '" + name + "' has no portrait available.");
        }

        Sprite newSprite = Sprite.Create(www.texture, new Rect(0f, 0f, www.texture.width, www.texture.height), new Vector2(0.5f, 0.5f), 128f);

        championDB.Data[name].Image.Portrait = newSprite;

        championImageQueue.Remove(name + "portrait");
    }

    private IEnumerator GrabChampionIcons( string name )
    {
        WWW www = new WWW(RiotAPIConstants.CHAMPION_ICON_HYPERLINK(name));
        
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.LogError("Error: " + www.error + " - Champion '" + name + "' has no icon available.");
        }

        Sprite newSprite = Sprite.Create(www.texture, new Rect(0f, 0f, www.texture.width, www.texture.height), new Vector2(0.0f, 0.0f), 128f);

        championDB.Data[name].Image.Icon = newSprite;

        championImageQueue.Remove(name + "icon");
    }


    #endregion
}

