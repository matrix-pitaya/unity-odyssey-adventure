using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerCrawAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.CrawEvent.OnCraw += CrawEvent_OnCraw;
    }
    void OnDisable()
    {
        player.PlayerEvents.CrawEvent.OnCraw -= CrawEvent_OnCraw;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void CrawEvent_OnCraw(CrawEvent crawEvent, CrawEventArgs crawEventArgs)
    {
        MoveRigidbody(crawEventArgs.direction, crawEventArgs.maxSpeed, crawEventArgs.acceleration, crawEventArgs.deceleration);
        Rotate(crawEventArgs.direction, crawEventArgs.rotateSpeed);
    }
    void MoveRigidbody(Vector3 direction,float maxSpeed, float acceleration, float deceleration)
    {
        if(direction.sqrMagnitude > 0)
        {
            float speed = Vector3.Dot(direction, player.LateralVelocity);
            if(player.LateralVelocity.magnitude < maxSpeed || speed < 0)
            {
                speed += acceleration * Time.deltaTime;
                speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
            }
            player.LateralVelocity = direction * speed;
            player.Rigidbody.velocity = player.LateralVelocity;
        }
        else if (player.PlayerControl.MoveAbsoluteDirection.sqrMagnitude <= 0)
        {
            float speed = player.LateralVelocity.magnitude;
            if(speed > 0)
            {
                speed -= deceleration * Time.deltaTime;
                speed = speed > 0 ? speed : 0;         
            }
            player.LateralVelocity = player.gameObject.transform.forward * speed;
            player.Rigidbody.velocity = player.LateralVelocity;
        }
    }
    void Rotate(Vector3 direction,float rotateSpeed)
    {
        if(direction.sqrMagnitude > 0)
        {
            player.gameObject.transform.rotation = Quaternion.RotateTowards(player.gameObject.transform.rotation,
                Quaternion.LookRotation(direction, Vector3.up), rotateSpeed * Time.deltaTime);
        }
    }
}
