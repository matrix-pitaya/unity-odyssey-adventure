using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerIdleAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.IdleEvent.OnIdle += IdleEvent_OnIdle;
    }
    void OnDisable()
    {
        player.PlayerEvents.IdleEvent.OnIdle -= IdleEvent_OnIdle;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void IdleEvent_OnIdle(IdleEvent idleEvent, IdleEventArgs idleEventArgs)
    {
        StopRigidbodyLateralMove();
        InlineMode(idleEventArgs.horizontal, idleEventArgs.inlineMaxAngle, idleEventArgs.inclineSmoothness);
    }
    void StopRigidbodyLateralMove()
    {
        if(player.Rigidbody.velocity != Vector3.zero)
        {
            player.Rigidbody.velocity = Vector3.zero;
        }
        if (player.LateralVelocity != Vector3.zero)
        {
            player.LateralVelocity = Vector3.zero;
        }
        if(player.VerticalVelocity != player.Rigidbody.velocity)
        {
            player.VerticalVelocity = player.Rigidbody.velocity;
        }
    }
    void InlineMode(float horizontal, float inlineMaxAngle, float inclineSmoothness)
    {
        player.SkinTransform.localRotation = Quaternion.Slerp(player.SkinTransform.localRotation,
               Quaternion.Euler(0, 0, -horizontal * inlineMaxAngle),
               inclineSmoothness * Time.deltaTime);
    }
}
