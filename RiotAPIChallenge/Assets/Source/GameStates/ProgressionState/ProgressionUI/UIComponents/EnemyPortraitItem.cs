#region File Header

/*******************************************************************************
 * Author: Vincent "Sabin" Biancardi
 * Filename: EnemyPortraitItem.cs
 * Date Created: 4/14/2015 12:02AM EST
 * 
 * Description: The enemy's portait item.
 * 
 * Changelog:   - Modified: Matthew "Riktor" Baker - 4/16/2015 8:13 PM - Added Comments
 *******************************************************************************/

#endregion

#region Using Directives

using UnityEngine;
using UnityEngine.UI;

#endregion

public class EnemyPortraitItem : MonoBehaviour
{
    #region Private Variables

    /// <summary>
    /// 
    /// </summary>
    [SerializeField]
    private Image mainBackground;

    #endregion

    #region Public Methods

    public void SetEnemyPortrait( Sprite portrait )
    {
        mainBackground.sprite = portrait;
    }

    #endregion
}