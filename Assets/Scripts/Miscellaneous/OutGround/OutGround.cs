using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutGround : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(Setting.Player))
        {
            if (collision.gameObject.GetComponent<Player>() != null)
            {
                Player player = collision.gameObject.GetComponent<Player>();
                if (!player.IsDead && !player.IsHurt && !player.IsInvincible)
                {
                    player.PlayerEvents.HurtEvent.CallHurtEvent(player.Health.Value, player.PlayerDetail.InvincibleTime,
                        player.PlayerDetail.HurtTime, gameObject.transform.position, player.PlayerDetail.HurtForce);
                    player.gameObject.GetComponent<CapsuleCollider>().material = null;
                }
            }
        }
        else if(collision.gameObject.CompareTag(Setting.Crate))
        {
            if(collision.gameObject.GetComponent<Crate>() != null)
            {
                collision.gameObject.GetComponent<Crate>().ForceExplosion();
            }
        }
        else if(collision.gameObject.CompareTag(Setting.TagCoin))
        {
            ObjectPoolManager.Instance.ReleaseCoinGO(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag(Setting.TagHeart))
        {
            ObjectPoolManager.Instance.ReleaseHeartGO(collision.gameObject);
        }
    }
}
