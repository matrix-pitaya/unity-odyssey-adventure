using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerStompAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.StompEvent.OnStomp += StompEvent_OnStomp;
    }
    void OnDisable()
    {
        player.PlayerEvents.StompEvent.OnStomp -= StompEvent_OnStomp;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void StompEvent_OnStomp(StompEvent stompEvent, StompEventArgs stompEventArgs)
    {
        MoveRigidbody(stompEventArgs.direction, stompEventArgs.acceleration, stompEventArgs.maxSpeed, stompEventArgs.minSpeed);
        FaceToDirection(stompEventArgs.direction, stompEventArgs.rotateSpeed);
    }
    void MoveRigidbody(Vector3 direction, float acceleration, float maxSpeed,float minSpeed)
    {
        if (direction.sqrMagnitude > 0)
        {
            float speed = Vector3.Dot(direction, player.LateralVelocity);
            if(speed < 0)
            {
                StompForward(acceleration, maxSpeed, minSpeed);
                return;
            }
            StompTurn(direction, acceleration, speed, maxSpeed, minSpeed);
            return;
        }
        StompForward(acceleration, maxSpeed, minSpeed);
    }
    void FaceToDirection(Vector3 direction, float rotateSpeed)
    {
        if (direction.sqrMagnitude > 0)
        {
            player.gameObject.transform.rotation = Quaternion.RotateTowards(player.gameObject.transform.rotation,
                Quaternion.LookRotation(direction, Vector3.up),rotateSpeed * Time.deltaTime);
        }
    }
    void StompForward(float acceleration, float maxSpeed, float minSpeed)
    {
        float speed = player.LateralVelocity.magnitude;
        if (speed < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
            speed = (speed <= minSpeed) ? minSpeed : speed;
        }
        player.LateralVelocity = player.transform.forward * speed;
        player.Rigidbody.velocity = player.LateralVelocity;
    }
    void StompTurn(Vector3 direction, float acceleration,float speed,float maxSpeed,float minSpeed)
    {
        if (player.LateralVelocity.magnitude < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, 0, maxSpeed);
            speed = (speed <= minSpeed) ? minSpeed : speed;
        }
        player.LateralVelocity = direction * speed;
        player.Rigidbody.velocity = player.LateralVelocity;
    }

    public void StartStompCoroutine(float duration)
    {
        StartCoroutine(StompCoroutine(duration));
    }

    IEnumerator StompCoroutine(float duration)
    {
        player.IsStomp = true;
        yield return new WaitForSeconds(duration);
        player.IsStomp = false;
    }
}
