#region File Header

/**
 *   File Name:                 TeamSelectView.cs
 *   Author:                    Vincent Biancardi
 *   Creation Date:             April 8, 2015
 */

#endregion

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TeamSelectView : MonoBehaviour
{
    #region Variables

    [SerializeField]
    private GridLayoutGroup grid;
    
    [SerializeField]
    private ScrollRect scrollRect;
    
    [SerializeField]
    private Scrollbar scrollBar;

    [SerializeField]
    private GameObject TeamSelectItem;

    #endregion

    #region UI Methods

    public void UpdateScrollSize( )
    {
        scrollBar.size = scrollRect.GetComponent<RectTransform>().rect.height/scrollRect.content.rect.height;
    }

    public void OnSubmit( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.PROGRESSION );
    }

    /// <summary>
    /// Adds a UI Game Object to the grid
    /// </summary>
    /// <param name="item">the item being added</param>
    public void AddParty( Party party )
    {
        GameObject item = ( GameObject )Instantiate( TeamSelectItem, Vector3.zero, Quaternion.identity );
        
        if ( item == null || item.GetComponent<TeamSelectItem>( ) == null )
            return;

        TeamSelectItem itemScript = item.GetComponent<TeamSelectItem>( );
        itemScript.InitData( party.MatchID, party.PartyMembers[0].Icon, party.PartyMembers[1].Icon, 
            party.PartyMembers[2].Icon, party.PartyMembers[3].Icon, party.PartyMembers[4].Icon );

        item.transform.SetParent( grid.transform );
        item.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        item.transform.localPosition = Vector3.zero;
    }

    #endregion
}