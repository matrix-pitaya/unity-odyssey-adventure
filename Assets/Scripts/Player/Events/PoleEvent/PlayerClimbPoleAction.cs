using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerClimbPoleAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.ClimbPoleEvent.OnClimbPole += ClimbPoleEvent_OnClimbPole;
    }
    void OnDisable()
    {
        player.PlayerEvents.ClimbPoleEvent.OnClimbPole -= ClimbPoleEvent_OnClimbPole;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void ClimbPoleEvent_OnClimbPole(ClimbPoleEvent climbPoleEvent, ClimbPoleEventArgs climbPoleEventArgs)
    {
        ClimbPole(climbPoleEventArgs.direction, climbPoleEventArgs.climbUpSpeed, climbPoleEventArgs.climDownSpeed, climbPoleEventArgs.climbRotateSpeed);
    }
    void ClimbPole(Vector3 direction,float climbUpSpeed,float climbDownSpeed, float climbRotateSpeed)
    {
        Vector3 toPoleDirection = player.ClimbPoleTransform.position - player.gameObject.transform.position;
        toPoleDirection.y = 0.0f;
        toPoleDirection.Normalize();
        player.gameObject.transform.forward = toPoleDirection;
        player.LateralVelocity = player.gameObject.transform.right * direction.x * climbRotateSpeed;
        player.VerticalVelocity = (direction.z != 0) ? (direction.z > 0 ? 
            (player.gameObject.transform.position.y > player.ClimbPoleTransform.gameObject.GetComponent<Pole>().MaxHeight ? Vector3.zero
             : Vector3.up * climbUpSpeed) : Vector3.down * climbDownSpeed) : Vector3.zero;
        player.gameObject.transform.position += (player.LateralVelocity + player.VerticalVelocity) * Time.deltaTime;
    }
}
