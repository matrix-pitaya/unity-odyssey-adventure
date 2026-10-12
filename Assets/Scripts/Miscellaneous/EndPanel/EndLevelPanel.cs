using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelPanel : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer(Setting.Player))
        {
            if(collision.contacts.Length > 0)
            {
                if (!GameManager.Instance.IsGameOver && collision.contacts[0].normal.y < 0)
                {
                    GameEventManager.Instance.ExitLevelEvent.CallExitLevelEvent();
                    PlayerGameDataManager.Instance.SaveGameData();
                    SceneLoader.Instance.LoadScene(Setting.LevelSelectScene);
                }
            }
        }
    }
}
