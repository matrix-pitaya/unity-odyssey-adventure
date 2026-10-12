using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerAirAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.AirEvent.OnAir += AirEvent_OnAir;
    }
    void OnDisable()
    {
        player.PlayerEvents.AirEvent.OnAir -= AirEvent_OnAir;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void AirEvent_OnAir(AirEvent jumpEvent, AirEventArgs jumpEventArgs)
    {
        MoveInAir(jumpEventArgs.direction, jumpEventArgs.acceleration, jumpEventArgs.maxSpeed);
        Rotate(jumpEventArgs.direction, jumpEventArgs.rotateSpeed);
    }
    void MoveInAir(Vector3 direction, float acceleration, float maxSpeed)
    {
        if (direction.sqrMagnitude > 0)
        {
            float speed = Vector3.Dot(direction, player.LateralVelocity);
            if(player.LateralVelocity.magnitude < maxSpeed || speed < 0)
            {
                speed += acceleration * Time.deltaTime;
                speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
            }
            player.LateralVelocity = direction * speed;
        }
        player.VerticalVelocity = player.Rigidbody.velocity;
        player.Rigidbody.velocity = player.LateralVelocity + player.VerticalVelocity;
    }
    void Rotate(Vector3 direction,float rotateSpeed)
    {
        if(direction.sqrMagnitude > 0)
        {
            player.gameObject.transform.rotation = Quaternion.RotateTowards(player.gameObject.transform.rotation,
                Quaternion.LookRotation(direction, Vector3.up),rotateSpeed * Time.deltaTime);
        }
    }
}
