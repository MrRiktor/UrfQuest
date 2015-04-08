#region File Header

/**
 *   File Name:                 IGameStat.cs
 *   Author:                    Vincent Biancardi
 *   Creation Date:             April 8, 2015
 */

#endregion

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Test Data to unit test the TeamSelect UI Component
/// </summary>
public class TeamSelectTestData : MonoBehaviour
{
    [SerializeField]
    private GameObject TSUI_MainPrefab;
    [SerializeField]
    public  GameObject TSUI_TeamPrefab;

    private GameObject TSUI_MainPrefabObj;
    private TeamSelectView view;

    // Use this for initialization
    void Start( )
    {
        TeamSelectData data1 = new TeamSelectData( 111111, "Ahri", "Bard", "Darius", "Fiora", "Hecarim" );
        TeamSelectData data2 = new TeamSelectData( 222222, "Akali", "Blitzcrank", "Diana", "Fizz", "Heimerdinger" );
        TeamSelectData data3 = new TeamSelectData( 333333, "Alistar", "Brand", "DrMundo", "Galio", "Irelia" );
        TeamSelectData data4 = new TeamSelectData( 444444, "Amumu", "Braum", "Draven", "Gangplank", "Janna" );
        TeamSelectData data5 = new TeamSelectData( 555555, "Anivia", "Caitlyn", "Elise", "Garen", "JarvanIV" );
        TeamSelectData data6 = new TeamSelectData( 777777, "Annie", "Cassiopeia", "Evelynn", "Gnar", "Jax" );
        TeamSelectData data7 = new TeamSelectData( 888888, "Ashe", "ChoGath", "Ezreal", "Gragas", "Jayce" );
        TeamSelectData data8 = new TeamSelectData( 999999, "Azir", "Corki", "Fiddlesticks", "Graves", "Jinx" );

        TSUI_MainPrefabObj = (GameObject)Instantiate( TSUI_MainPrefab, Vector3.zero, Quaternion.identity );
        view = TSUI_MainPrefabObj.GetComponent<TeamSelectView>( );

        GameObject item = ( GameObject )Instantiate( TSUI_TeamPrefab, Vector3.zero, Quaternion.identity );
        TeamSelectItem itemData = item.GetComponent<TeamSelectItem>( );
        itemData.InitData( data1 );
        view.AddItem( item );

        item = ( GameObject )Instantiate( TSUI_TeamPrefab, Vector3.zero, Quaternion.identity );
        itemData = item.GetComponent<TeamSelectItem>( );
        itemData.InitData( data2 );
        view.AddItem( item );

        item = ( GameObject )Instantiate( TSUI_TeamPrefab, Vector3.zero, Quaternion.identity );
        itemData = item.GetComponent<TeamSelectItem>( );
        itemData.InitData( data3 );
        view.AddItem( item );

        item = ( GameObject )Instantiate( TSUI_TeamPrefab, Vector3.zero, Quaternion.identity );
        itemData = item.GetComponent<TeamSelectItem>( );
        itemData.InitData( data4 );
        view.AddItem( item );

        item = ( GameObject )Instantiate( TSUI_TeamPrefab, Vector3.zero, Quaternion.identity );
        itemData = item.GetComponent<TeamSelectItem>( );
        itemData.InitData( data5 );
        view.AddItem( item );

        item = ( GameObject )Instantiate( TSUI_TeamPrefab, Vector3.zero, Quaternion.identity );
        itemData = item.GetComponent<TeamSelectItem>( );
        itemData.InitData( data6 );
        view.AddItem( item );

        item = ( GameObject )Instantiate( TSUI_TeamPrefab, Vector3.zero, Quaternion.identity );
        itemData = item.GetComponent<TeamSelectItem>( );
        itemData.InitData( data7 );
        view.AddItem( item );

        item = ( GameObject )Instantiate( TSUI_TeamPrefab, Vector3.zero, Quaternion.identity );
        itemData = item.GetComponent<TeamSelectItem>( );
        itemData.InitData( data8 );
        view.AddItem( item );

    }
}