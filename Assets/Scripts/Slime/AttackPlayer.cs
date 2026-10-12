using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AttackPlayer : MonoBehaviour
{
    Slime slime;
    BoxCollider boxCollider;
    bool canAttack = true;

    public BoxCollider BoxCollider
    {
        get
        {
            return boxCollider;
        }
    }
    public bool CanAttack
    {
        get
        {
            return canAttack;
        }
    }

    void Awake()
    {
        LoadComponent();
    }

    void LoadComponent()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        slime = gameObject.GetComponentInParent<Slime>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(canAttack && other.gameObject.CompareTag(Setting.Player))
        {
            if(other.gameObject.GetComponent<Player>() != null)
            {
                Player player = other.gameObject.GetComponent<Player>();
                if (!player.IsDead && !player.IsHurt && !player.IsInvincible)
                {
                    player.PlayerEvents.HurtEvent.CallHurtEvent(1, player.PlayerDetail.InvincibleTime, player.PlayerDetail.HurtTime,
                   slime.gameObject.transform.position, player.PlayerDetail.HurtForce);
                    StartCoroutine(AttackCoolDownCoroutine());
                }
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (canAttack && other.gameObject.CompareTag(Setting.Player))
        {
            if (other.gameObject.GetComponent<Player>() != null)
            {
                Player player = other.gameObject.GetComponent<Player>();
                if (!player.IsDead && !player.IsHurt && !player.IsInvincible)
                {
                    player.PlayerEvents.HurtEvent.CallHurtEvent(1, player.PlayerDetail.InvincibleTime, player.PlayerDetail.HurtTime,
                        slime.gameObject.transform.position, player.PlayerDetail.HurtForce);
                    StartCoroutine(AttackCoolDownCoroutine());
                }
            }
        }
    }

    IEnumerator AttackCoolDownCoroutine()
    {
        if(slime.IsDead)
        {
            slime.SwitchNode(Setting.Dead);
        }
        else
        {
            slime.SwitchNode(Setting.Idle);
        }
        canAttack = false;
        boxCollider.enabled = false;
        yield return new WaitForSeconds(slime.SlimeDetails.AttackCD);
        if (!slime.IsDead)
        {
            canAttack = true;
            boxCollider.enabled = true;
        }
    }
}
