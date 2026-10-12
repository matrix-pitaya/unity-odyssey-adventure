using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerBreakAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.BreakEvent.OnBreak += BreakEvent_OnBreak;
    }
    void OnDisable()
    {
        player.PlayerEvents.BreakEvent.OnBreak -= BreakEvent_OnBreak;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void BreakEvent_OnBreak(BreakEvent breakEvent, BreakEventArgs breakEventArgs)
    {
        Deceleration(breakEventArgs.deceleration);
        InlineMode(breakEventArgs.horizontal, breakEventArgs.inlineMaxAngle, breakEventArgs.inclineSmoothness);
    }
    void Deceleration(float deceleration)
    {
        float speed = player.LateralVelocity.magnitude;
        if (speed > 0)
        {
            speed -= deceleration * Time.deltaTime;
            speed = speed > 0 ? speed : 0;
        }
        player.LateralVelocity = player.LateralVelocity.normalized * speed;
        player.Rigidbody.velocity = player.LateralVelocity;
    }
    void InlineMode(float horizontal, float inlineMaxAngle, float inclineSmoothness)
    {
        player.SkinTransform.localRotation = Quaternion.Slerp(player.SkinTransform.localRotation,
               Quaternion.Euler(0, 0, -horizontal * inlineMaxAngle),
               inclineSmoothness * Time.deltaTime);
    }
}
