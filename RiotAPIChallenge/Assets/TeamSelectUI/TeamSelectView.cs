﻿using UnityEngine;
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

    /// <summary>
    /// Adds a UI Game Object to the grid
    /// </summary>
    /// <param name="item">the item being added</param>
    public void AddItem( GameObject item )
    {
        if ( item == null || item.GetComponent<TeamSelectItem>() == null )
            return;

        item.transform.SetParent( Grid.transform );
        item.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        item.transform.localPosition = Vector3.zero;

        //scrollRect.verticalNormalizedPosition = 0;
        //scrollBar.value = 0;
        //scrollBar.Rebuild( CanvasUpdate.MaxUpdateValue );
    }

    #endregion
}