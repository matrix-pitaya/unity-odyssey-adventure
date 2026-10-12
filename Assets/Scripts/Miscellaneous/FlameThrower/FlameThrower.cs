using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour
{
    const int flameThrowerDamage = 1;
    BoxCollider boxCollider;
    ParticleSystem _particleSystem;

    void Awake()
    {
        LoadComponent();
    }

    void LoadComponent()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        _particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    public void OpenFire()
    {
        boxCollider.enabled = true;
        _particleSystem.Play();
    }
    public void CloseFire()
    {
        boxCollider.enabled = false;
        _particleSystem.Stop();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(Setting.Player))
        {
            if(other.gameObject.GetComponent<Player>() != null)
            {
                Player player = other.gameObject.GetComponent<Player>();
                if(!player.IsDead && !player.IsHurt && !player.IsInvincible)
                {
                    player.PlayerEvents.HurtEvent.CallHurtEvent(flameThrowerDamage, player.PlayerDetail.InvincibleTime, player.PlayerDetail.HurtTime,
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
                    player.PlayerEvents.HurtEvent.CallHurtEvent(flameThrowerDamage, player.PlayerDetail.InvincibleTime, player.PlayerDetail.HurtTime,
                        gameObject.transform.position, player.PlayerDetail.HurtForce);
                }
            }
        }
    }
}
