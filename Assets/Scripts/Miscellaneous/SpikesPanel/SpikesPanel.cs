using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveObject))]
public class SpikesPanel : MonoBehaviour
{
    [Header("SPIKES TRIGGER CHECK TO HURT PLAYER")]
    [SerializeField] BoxCollider boxCollider;

    MoveObject moveObject;
    const float spikesStateChangeDuration = 10.0f;
    const int spikesDamage = 1;
    bool isSpikesDisapply = true;

    void Awake()
    {
        LoadComponent();
        InitCallBack();
    }
    void Start()
    {
        StartCoroutine(SpikesControlCoroutine());
    }

    void LoadComponent()
    {
        moveObject = gameObject.GetComponent<MoveObject>();
    }
    void InitCallBack()
    {
        moveObject.TargetCallBackEvent.AddListener(CloseCollider);
        moveObject.RecoverCallBackEvent.AddListener(OpenCollider);
    }

    void OpenCollider()
    {
        boxCollider.enabled = true;
    }
    void CloseCollider()
    {
        boxCollider.enabled = false;
    }

    IEnumerator SpikesControlCoroutine()
    {
        while(true)
        {
            if(isSpikesDisapply)
            {
                moveObject.MoveToTarget();
                isSpikesDisapply = false;
            }
            else
            {
                moveObject.MoveToRecover();
                isSpikesDisapply = true;
            }
            yield return new WaitForSeconds(spikesStateChangeDuration);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(Setting.Player))
        {
            if(other.gameObject.GetComponent<Player>() != null)
            {
                Player player = other.gameObject.GetComponent<Player>();
                if (!player.IsDead && !player.IsHurt && !player.IsInvincible)
                {
                    player.PlayerEvents.HurtEvent.CallHurtEvent(spikesDamage, player.PlayerDetail.InvincibleTime, player.PlayerDetail.HurtTime,
                        gameObject.transform.position, player.PlayerDetail.HurtForce);
                }
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Setting.Player))
        {
            if (other.gameObject.GetComponent<Player>() != null)
            {
                Player player = other.gameObject.GetComponent<Player>();
                if (!player.IsDead && !player.IsHurt && !player.IsInvincible)
                {
                    player.PlayerEvents.HurtEvent.CallHurtEvent(spikesDamage, player.PlayerDetail.InvincibleTime, player.PlayerDetail.HurtTime,
                        gameObject.transform.position, player.PlayerDetail.HurtForce);
                }
            }
        }
    }
}
