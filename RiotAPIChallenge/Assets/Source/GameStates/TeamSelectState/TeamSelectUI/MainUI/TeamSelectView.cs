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
    [SerializeField]
    private GridLayoutGroup Grid;
    [SerializeField]
    private ScrollRect scrollRect;
    [SerializeField]
    private Scrollbar scrollBar;

    #region UI Methods

    public void UpdateScrollSize( )
    {
        scrollBar.size = scrollRect.GetComponent<RectTransform>().rect.height/scrollRect.content.rect.height;
    }

    /// <summary>
    /// Adds a UI Game Object to the grid
    /// </summary>
    /// <param name="item">the item being added</param>
    public void OnAddMatchDetail( MatchDetail matchDetail )
    {
        //TODO Create Item set items model data attach item

        /*if ( item == null || item.GetComponent<TeamSelectItemView>() == null )
            return;

        item.transform.SetParent( Grid.transform );
        item.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        item.transform.localPosition = Vector3.zero;*/

    }

    #endregion
}