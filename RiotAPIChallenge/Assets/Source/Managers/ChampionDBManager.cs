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
        
        championDBInitialized = true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    private void InitializationFailure(string message)
    {
        UnityEngine.Debug.LogError("ChampionDBManager::InitializationFailure - Failed to Initialize Champion Database.");

        Fetch fetch = new Fetch(InitializationSuccess, null, ChampionDB.fromJSON);

    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="region"></param>
    /// <param name="champData"></param>
    /// <returns></returns>
    private IEnumerator InitializeChampionDatabase(Region region, ChampData champData)
    {
        string url = "";
        if ( Application.isWebPlayer)
        {
            url = "UrfQuest.php?apiCall=" + RiotAPIConstants.CHAMPIONv1_2( region, champData );
        }
        else
        {
            url = RiotAPIConstants.CHAMPIONv1_2( region, champData );
        }

        Fetch fetch = new Fetch(InitializationSuccess, InitializationFailure, url, ChampionDB.fromJSON);

        return fetch.WaitForUrlData();
    }

    #endregion
}

