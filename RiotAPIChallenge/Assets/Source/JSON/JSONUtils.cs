using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonFx.Json;

public class JSONUtils
{
    private static JsonConverter[] jsonConverters;
    private static JsonReaderSettings jsonReaderSettings;
    private static JsonWriterSettings jsonWriterSettings;
    private static bool isInitialized = false;

    public static JsonReader getJsonReader( string json )
    {
        return new JsonReader( json, jsonReaderSettings );
    }

    public static JsonWriterSettings getJsonWriterSettings()
    {
        return jsonWriterSettings;
    }

    public static string objectToJson( object entity )
    {
        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
        JsonWriter writer = new JsonWriter( stringBuilder, getJsonWriterSettings() );

        writer.Write( entity );

        return stringBuilder.ToString();
    }

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

    private static JsonConverter[] createJsonConverters()
    {
        JsonConverter[] converters = new JsonConverter[]
        {
            new MatchIDListConverter(),
        };

        return converters;
    }

}

