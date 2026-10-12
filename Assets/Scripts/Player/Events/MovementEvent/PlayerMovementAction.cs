using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerMovementAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.MovementEvent.OnMovement += MovementEvent_OnMovementEvent;
    }
    void OnDisable()
    {
        player.PlayerEvents.MovementEvent.OnMovement -= MovementEvent_OnMovementEvent;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    void MovementEvent_OnMovementEvent(MovementEvent movementEvent, MovementEventArgs movementEventArgs)
    {
        MoveRigidbody(movementEventArgs.direction, movementEventArgs.acceleration, movementEventArgs.maxSpeed);
        Rotate(movementEventArgs.direction, movementEventArgs.rotateSpeed);
        InlineMode(movementEventArgs.horizontal, movementEventArgs.inlineMaxAngle, movementEventArgs.inclineSmoothness);
    }
    void MoveRigidbody(Vector3 direction, float acceleration, float maxSpeed)
    {
        if (direction.sqrMagnitude > 0)
        {
            float speed = Vector3.Dot(direction, player.LateralVelocity);
            if (player.LateralVelocity.magnitude < maxSpeed || speed < 0)
            {
                speed += acceleration * Time.deltaTime;
                speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
            }
            player.LateralVelocity = direction * speed;
            player.Rigidbody.velocity = player.LateralVelocity;
        }
    }
    void TrunMoveRigidbody(Vector3 direction, float speed,float acceleration, float maxSpeed)
    {
        if(player.LateralVelocity.magnitude < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
        }
        player.LateralVelocity = direction * speed;
        player.Rigidbody.velocity = player.LateralVelocity;
    }
    void ForwardMoveRigidbody(float acceleration, float maxSpeed)
    {
        float speed = player.LateralVelocity.magnitude;
        if(speed < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, 0, maxSpeed);
        }
        player.LateralVelocity = player.LateralVelocity.normalized * speed;
        player.Rigidbody.velocity = player.LateralVelocity;
    }
    void Rotate(Vector3 direction,float rotateSpeed)
    {
        if(direction.sqrMagnitude > 0)
        {
            player.gameObject.transform.rotation = Quaternion.RotateTowards(player.gameObject.transform.rotation,
                Quaternion.LookRotation(direction, Vector3.up), rotateSpeed * Time.deltaTime);
        }
    }
    void InlineMode(float horizontal,float inlineMaxAngle,float inclineSmoothness)
    {
        player.SkinTransform.localRotation = Quaternion.Slerp(player.SkinTransform.localRotation,
               Quaternion.Euler(0, 0, -horizontal * inlineMaxAngle),
               inclineSmoothness * Time.deltaTime);
    }
}
