using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    const int spikesDamage = 1;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer(Setting.Player))
        {
            if(collision.gameObject.GetComponent<Player>() != null)
            {
                Player player = collision.gameObject.GetComponent<Player>();
                if (!player.IsDead && !player.IsHurt && !player.IsInvincible)
                {
                    player.PlayerEvents.HurtEvent.CallHurtEvent(spikesDamage, player.PlayerDetail.InvincibleTime, player.PlayerDetail.HurtTime,
                       gameObject.transform.position, player.PlayerDetail.HurtForce);
                }
            }
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(Setting.Player))
        {
            if (collision.gameObject.GetComponent<Player>() != null)
            {
                Player player = collision.gameObject.GetComponent<Player>();
                if (!player.IsDead && !player.IsHurt && !player.IsInvincible)
                {
                    player.PlayerEvents.HurtEvent.CallHurtEvent(spikesDamage, player.PlayerDetail.InvincibleTime, player.PlayerDetail.HurtTime,
                       gameObject.transform.position, player.PlayerDetail.HurtForce);
                }
            }
        }
    }
}
