using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerDeadAction : MonoBehaviour
{
    Player player;
    const float waitTime = 3.0f;
    const float loadDelay = 1.5f;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.DeadEvent.OnDead += DeadEvent_OnDead;
    }
    void OnDisable()
    {
        player.PlayerEvents.DeadEvent.OnDead -= DeadEvent_OnDead;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void DeadEvent_OnDead(DeadEvent deadEvent)
    {
        PlayerDead();
    }
    void PlayerDead()
    {
        StartCoroutine(RestarGameCoroutine());
    }

    IEnumerator RestarGameCoroutine()
    {
        yield return new WaitForSeconds(waitTime);
        if(PlayerGameDataManager.Instance.Retries > 0)
        {
            if(GameManager.Instance.SpawnPoint != null)
            {
                GameManager.Instance.OnRestartCheckPoint();
                yield return new WaitForSeconds(loadDelay);
                UIManager.Instance.UpdataRetiresNumUI(PlayerGameDataManager.Instance.Retries);
                UIManager.Instance.UpdataHeartsNumUI(GameManager.Instance.Player.Health.IncreaseHealth(3));
                player.IsDead = false;
                player.SwitchNode(Setting.Idle);
            }
            else
            {
                GameManager.Instance.OnRestartLevel();
            }
        }
        else
        {
            GameManager.Instance.OnExitLevel();
        }
    }
}
