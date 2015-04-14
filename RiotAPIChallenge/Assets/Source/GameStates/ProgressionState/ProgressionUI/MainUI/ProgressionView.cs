using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProgressionView : MonoBehaviour
{
    [SerializeField]
    private Image mainImage;

    void Start( )
    {
        Debug.Log( GameData.StageMap.Stages [ GameData.CurrentLevel ].StageImage );
        mainImage.sprite = Resources.Load<Sprite>(GameData.StageMap.Stages [ GameData.CurrentLevel ].StageImage);
    }

    /// <summary>
    /// Handles the play button press
    /// </summary>
    public void OnContinueHandler( )
    {
        Messenger<GameStateTypes>.Broadcast( MessengerEventTypes.GAME_STATE_CHANGE, GameStateTypes.BATTLE );
    }
}