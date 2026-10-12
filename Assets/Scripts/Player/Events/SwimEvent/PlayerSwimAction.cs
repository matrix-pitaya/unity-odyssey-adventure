using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerSwimAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.SwimEvent.OnSwim += SwimEvent_OnSwim;
    }
    void OnDisable()
    {
        player.PlayerEvents.SwimEvent.OnSwim -= SwimEvent_OnSwim;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void SwimEvent_OnSwim(SwimEvent swimEvent, SwimEventArgs swimEventArgs)
    {
        Swim(swimEventArgs.direction, swimEventArgs.maxSpeed, swimEventArgs.acceleration, swimEventArgs.deceleration);
        Rotate(swimEventArgs.direction, swimEventArgs.rotateSpeed);
    }
    void Swim(Vector3 direction, float maxSpeed, float acceleration, float deceleration)
    {
        if(direction.sqrMagnitude > 0)
        {
            float speed = Vector3.Dot(direction, player.LateralVelocity);
            if(player.LateralVelocity.magnitude < maxSpeed || speed <= 0)
            {
                speed += acceleration * Time.deltaTime;
                speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
            }
            player.LateralVelocity = direction * speed;
        }
        else if(player.PlayerControl.MoveAbsoluteDirection.sqrMagnitude <= 0)
        {
            float speed = player.LateralVelocity.magnitude;
            if(speed >= 0)
            {
                speed -= deceleration * Time.deltaTime;
                speed = Mathf.Clamp(speed, 0, maxSpeed);
            }
            player.LateralVelocity = player.gameObject.transform.forward * speed;
        }
        player.VerticalVelocity = player.EnableFloatForce ? player.Rigidbody.velocity : Vector3.zero;
        player.Rigidbody.velocity = player.LateralVelocity + player.VerticalVelocity;
    }
    void Rotate(Vector3 direction, float rotateSpeed)
    {
        if(direction.sqrMagnitude > 0)
        {
            player.gameObject.transform.rotation = Quaternion.RotateTowards(player.gameObject.transform.rotation,
                     Quaternion.LookRotation(direction, Vector3.up), rotateSpeed * Time.deltaTime);
        }
    }
}
