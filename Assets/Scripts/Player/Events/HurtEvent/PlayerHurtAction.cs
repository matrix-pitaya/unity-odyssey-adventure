using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerHurtAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.HurtEvent.OnHurt += HurtEvent_OnHurt;
    }
    void OnDisable()
    {
        player.PlayerEvents.HurtEvent.OnHurt -= HurtEvent_OnHurt;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    void HurtEvent_OnHurt(HurtEvent hurtEvent, HurtEventArgs hurtEventArgs)
    {
        StartCoroutine(PlayerHurtCoroutine(hurtEventArgs.hurtTime));
        player.SwitchNode(Setting.Hurt);
        HurtHealth(hurtEventArgs.damage);
        HurtKnock(hurtEventArgs.invincibleTime, hurtEventArgs.origanl, hurtEventArgs.hurtForce);
    }
    void HurtHealth(int damage)
    {
        if (!player.IsDead && player.IsHurt && !player.IsInvincible)
        {
            if(player.Health.DecreaseHealth(damage) <= 0)
            {
                player.IsDead = true;
                UIManager.Instance.UpdataRetiresNumUI(PlayerGameDataManager.Instance.DecreastRetries(1));
            }
            UIManager.Instance.UpdataHeartsNumUI(player.Health.Value);
        }
    }
    void HurtKnock(float invincibleTime, Vector3 position, Vector2 hurtForce)
    {
        if (player.IsHurt && !player.IsInvincible)
        {
            StartCoroutine(PlayerInvincibleCoroutine(invincibleTime));
            Vector3 hurtDirection = position - player.gameObject.transform.position;
            hurtDirection.y = 0.0f;
            hurtDirection = hurtDirection.normalized;
            HurtFaceDirection(hurtDirection);
            HurtForce(hurtForce);
        }
    }
    void HurtFaceDirection(Vector3 direction)
    {
        if (direction.sqrMagnitude > 0)
        {
            player.gameObject.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }    
    void HurtForce(Vector2 force)
    {
        player.LateralVelocity = -player.gameObject.transform.forward * force.x;
        player.VerticalVelocity = Vector3.up * force.y;
        player.Rigidbody.velocity = player.LateralVelocity + player.VerticalVelocity;
    }

    IEnumerator PlayerHurtCoroutine(float hurtTime)
    {
        player.IsHurt = true;
        yield return new WaitForSeconds(hurtTime);
        player.IsHurt = false;
    }
    IEnumerator PlayerInvincibleCoroutine(float invincibleTime)
    {
        player.IsInvincible = true;
        yield return new WaitForSeconds(invincibleTime);
        player.IsInvincible = false;
    }
}
