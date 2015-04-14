using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyPortraitItem : MonoBehaviour
{
    [SerializeField]
    Image mainBackground;

    public void SetEnemyPortrait( Sprite portrait )
    {
        mainBackground.sprite = portrait;
    }

}