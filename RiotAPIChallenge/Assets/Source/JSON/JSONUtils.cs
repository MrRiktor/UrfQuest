#region File Header

/*******************************************************************************
 * Author: Matthew "Riktor" Baker
 * Filename: JSONUtils.cs
 * Date Created: 4/11/2015 8:28PM EST
 * 
 * Description: Our JsonFX Utilities class
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 9:01 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using JsonFx.Json;

#endregion

public class JSONUtils
{
    #region Private Variables

    /// <summary>
    /// An array of JsonConverters
    /// </summary>
    private static JsonConverter[] jsonConverters;
    
    /// <summary>
    /// Our JsonReaderSettings
    /// </summary>
    private static JsonReaderSettings jsonReaderSettings;
    
    /// <summary>
    /// Our JsonWriterSettings - Not currently used.
    /// </summary>
    private static JsonWriterSettings jsonWriterSettings;
    
    /// <summary>
    /// A boolean as to whether this class ahs been initialized.
    /// </summary>    
    private static bool isInitialized = false;

    #endregion

    #region Public Methods

    /// <summary>
    /// Returns a new JsonReader
    /// </summary>
    /// <param name="json"> the string of json </param>
    /// <returns> a JsonReader instance </returns>
    public static JsonReader getJsonReader( string json )
    {
        return new JsonReader( json, jsonReaderSettings );
    }

    /// <summary>
    /// Returns the JsonWriterSettings
    /// </summary>
    public static JsonWriterSettings getJsonWriterSettings()
    {
        return jsonWriterSettings;
    }

    /// <summary>
    /// Converts an object to a string of json
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public static string objectToJson( object entity )
    {
        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
        JsonWriter writer = new JsonWriter( stringBuilder, getJsonWriterSettings() );

        writer.Write( entity );

        return stringBuilder.ToString();
    }

    /// <summary>
    /// Initializes the Json Object Conversion
    /// </summary>
    public static void initJsonObjectConversion()
    {
        if( isInitialized )
        {
            return;
        }

        jsonReaderSettings = new JsonReaderSettings();
        jsonWriterSettings = new JsonWriterSettings();
        jsonWriterSettings.PrettyPrint = false;

        jsonConverters = createJsonConverters();

        foreach( JsonConverter jsonConverter in jsonConverters )
        {
            jsonReaderSettings.AddTypeConverter( jsonConverter );
            jsonWriterSettings.AddTypeConverter( jsonConverter );
        }

        isInitialized = true;
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Creates an array of JsonConverters.
    /// </summary>
    /// <returns>returns an array of json converters </returns>
    private static JsonConverter[] createJsonConverters()
    {
        JsonConverter[] converters = new JsonConverter[]
        {
            new MatchIDListConverter(),
            new MatchDetailConverter(),
            new ChampionDBConverter(),
            new ChampionConverter(),
            new ChampionStatsConverter(),
            new RiotImageConverter(),
            new ParticipantConverter(),
            new ParticipantIdentityConverter(),
            new ParticipantStatsConverter(),
            new PlayerConverter(),
        };

        return converters;
    }

    #endregion
}