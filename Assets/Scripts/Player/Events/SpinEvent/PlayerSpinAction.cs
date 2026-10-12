using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerSpinAction : MonoBehaviour
{
    Player player;
    bool isSpine;

    public bool IsSpine
    {
        get
        {
            return isSpine;
        }
    }

    void Awake()
    {
        LoadComponnet();
    }
    void OnEnable()
    {
        player.PlayerEvents.SpinEvent.OnSpin += SpinEvent_OnSpin;
    }
    void OnDisable()
    {
        player.PlayerEvents.SpinEvent.OnSpin -= SpinEvent_OnSpin;
    }

    void LoadComponnet()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void SpinEvent_OnSpin(SpinEvent spinEvent, SpinEventArgs spinEventArgs)
    {
        MoveRigidbody(spinEventArgs.acceleration, spinEventArgs.moveMaxSpeed, spinEventArgs.moveDirection);
        Rotate(spinEventArgs.rotateSpeed, spinEventArgs.moveDirection);
        InlineMode(spinEventArgs.horizontal, spinEventArgs.inlineMaxAngle, spinEventArgs.inclineSmoothness);
    }
    void MoveRigidbody(float acceleration,float moveMaxSpeed,Vector3 direction)
    {
        if (isSpine)
        {
            if (direction.sqrMagnitude > 0)
            {
                float speed = Vector3.Dot(direction, player.LateralVelocity);
                if (player.LateralVelocity.magnitude < moveMaxSpeed && speed <= 0)
                {
                    speed += acceleration * Time.deltaTime;
                    speed = Mathf.Clamp(speed, -moveMaxSpeed, moveMaxSpeed);
                }
                player.LateralVelocity = direction * speed;
            }
            player.VerticalVelocity = player.Rigidbody.velocity;
            player.Rigidbody.velocity = player.LateralVelocity + player.VerticalVelocity;
        }
    }
    void Rotate(float rotateSpeed, Vector3 direction)
    {
        if(isSpine && direction.sqrMagnitude > 0)
        {
            player.gameObject.transform.rotation = Quaternion.RotateTowards(player.gameObject.transform.rotation,
                Quaternion.LookRotation(direction, Vector3.up), rotateSpeed * Time.deltaTime);
        }
    }
    void InlineMode(float horizontal, float inlineMaxAngle, float inclineSmoothness)
    {
        player.SkinTransform.localRotation = Quaternion.Slerp(player.SkinTransform.localRotation,
               Quaternion.Euler(0, 0, -horizontal * inlineMaxAngle),
               inclineSmoothness * Time.deltaTime);
    }

    public void StartSpinCoroutine(float duration)
    {
        StartCoroutine(SpinCoroutine(duration));
    }

    IEnumerator SpinCoroutine(float duration)
    {
        isSpine = true;
        yield return new WaitForSeconds(duration);
        isSpine = false;
    }
}
