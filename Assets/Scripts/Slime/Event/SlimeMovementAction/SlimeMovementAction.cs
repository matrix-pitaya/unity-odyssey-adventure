using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Slime))]
[DisallowMultipleComponent]
public class SlimeMovementAction : MonoBehaviour
{
    Slime slime;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        slime.MovementEvent.OnMovement += MovementEvent_OnMovement;
    }
    void OnDisable()
    {
        slime.MovementEvent.OnMovement -= MovementEvent_OnMovement;
    }

    void LoadComponent()
    {
        slime = gameObject.GetComponent<Slime>();
    }
    void MovementEvent_OnMovement(MovementEvent movementEvent, MovementEventArgs movementEventArgs)
    {
        MoveRigidbody(movementEventArgs.direction, movementEventArgs.acceleration, movementEventArgs.maxSpeed);
        Rotate(movementEventArgs.direction, movementEventArgs.rotateSpeed);
    }
    void MoveRigidbody(Vector3 direction,float acceleration,float maxSpeed)
    {
        if(direction.sqrMagnitude > 0)
        {
            float speed = Vector3.Dot(direction, slime.LateralVelocity);
            if(slime.LateralVelocity.magnitude < maxSpeed || speed <= 0)
            {
                speed += acceleration * Time.deltaTime;
                speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
            }
            slime.LateralVelocity = speed * direction;
            slime.Rigidbody.velocity = slime.LateralVelocity;
        }
    }
    void Rotate(Vector3 direction, float rotateSpeed)
    {
        if(direction.sqrMagnitude > 0)
        {
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation,
                Quaternion.LookRotation(direction, Vector3.up), rotateSpeed * Time.deltaTime);
        }
    }
}
