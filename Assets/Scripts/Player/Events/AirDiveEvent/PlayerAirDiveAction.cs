using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerAirDiveAction : MonoBehaviour
{
    Player player;
    IEnumerator airDiveCoroutine;
    bool isAirDive;

    public bool IsAirDive
    {
        get
        {
            return isAirDive;
        }
    }

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.AirDiveEvent.OnAirDive += AirDiveEvent_OnAirDive;
    }
    void OnDisable()
    {
        player.PlayerEvents.AirDiveEvent.OnAirDive -= AirDiveEvent_OnAirDive;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void AirDiveEvent_OnAirDive(AirDiveEvent airDiveEvent, AirDiveEventArgs airDiveEventArgs)
    {
        Rotate(airDiveEventArgs.direction, airDiveEventArgs.rotateSpeed);
    }
    void MoveRigidbody(Vector3 direction,float maxSpeed,float minSpeed,float acceleration)
    {
        if(direction.sqrMagnitude > 0)
        {
            float speed = Vector3.Dot(direction, player.LateralVelocity);
            if(speed < 0)
            {
                MoveForward(maxSpeed, minSpeed, acceleration);
                return;
            }
            MoveTurn(direction, speed, maxSpeed, minSpeed, acceleration);
            return;
        }
        MoveForward(maxSpeed, minSpeed, acceleration);
    }
    void MoveTurn(Vector3 direction,float speed,float maxSpeed,float minSpeed,float acceleration)
    {
        if (player.LateralVelocity.magnitude < maxSpeed || speed < 0)
        {
            speed += acceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
            speed = (speed < minSpeed) ? minSpeed : speed;
        }
        player.LateralVelocity = direction * speed;
        player.Rigidbody.velocity = player.LateralVelocity + player.VerticalVelocity;
    }
    void MoveForward(float maxSpeed,float minSpeed,float acceleration)
    {
        float speed = player.LateralVelocity.magnitude;
        if (speed < maxSpeed)
        {
            speed += acceleration * Time.deltaTime;
            speed = Mathf.Clamp(speed, 0, maxSpeed);
            speed = (speed < minSpeed) ? minSpeed : speed;
        }
        player.LateralVelocity = player.gameObject.transform.forward * speed;
        player.Rigidbody.velocity = player.LateralVelocity + player.VerticalVelocity;
    }
    void Rotate(Vector3 direction, float rotateSpeed)
    {
        if(direction.sqrMagnitude > 0)
        {
            if(Vector3.Dot(direction, player.LateralVelocity) <= 0)
            {
                return;
            }

            player.gameObject.transform.rotation = Quaternion.RotateTowards(player.gameObject.transform.rotation,
                Quaternion.LookRotation(direction, Vector3.up), rotateSpeed * Time.deltaTime);
        }
    }
    void ForceRigidbody(Vector2 force)
    {
        player.LateralVelocity = player.gameObject.transform.forward * force.x;
        player.VerticalVelocity = Vector3.up * force.y;
        player.Rigidbody.velocity = player.LateralVelocity + player.VerticalVelocity;
    }

    public void StartAirDiveCoroutine(Vector2 force, float duration)
    {
        if(airDiveCoroutine != null)
        {
            StopCoroutine(airDiveCoroutine);
        }
        airDiveCoroutine = AirDiveCoroutine(force, duration);
        StartCoroutine(airDiveCoroutine);
    }
    public void StopAirDiveCoroutine()
    {
        if (airDiveCoroutine != null)
        {
            StopCoroutine(airDiveCoroutine);
        }
    }

    IEnumerator AirDiveCoroutine(Vector2 force,float duration)
    {
        isAirDive = true;
        ForceRigidbody(force);
        while (!player.IsOnGround)
        {
            yield return null;
        }
        player.PlayerParticle.PlayParticleSystem(PlayerParticleType.Land);
        yield return new WaitForSeconds(duration);
        player.SwitchNode(Setting.Jump);
        isAirDive = false;
    }
}
