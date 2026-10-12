using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerSquatAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.SquatEvent.OnSquat += SquatEvent_OnSquat;
    }
    void OnDisable()
    {
        player.PlayerEvents.SquatEvent.OnSquat -= SquatEvent_OnSquat;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void SquatEvent_OnSquat(SquatEvent squatEvent,SquatEventArgs squatEventArgs)
    {
        DecelerateRigidbodyLateralMove(squatEventArgs.deceleration);
        InclineMode(squatEventArgs.horizontal,  squatEventArgs.inlineMaxAngle, squatEventArgs.inclineSmoothness);
    }
    void DecelerateRigidbodyLateralMove(float deceleration)
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
    void InclineMode(float horizontal, float inlineMaxAngle,float inclineSmoothness)
    {
        player.SkinTransform.localRotation = Quaternion.Slerp(player.SkinTransform.localRotation,
            Quaternion.Euler(0, 0, -horizontal * inlineMaxAngle),
            inclineSmoothness * Time.deltaTime);
    }
}
