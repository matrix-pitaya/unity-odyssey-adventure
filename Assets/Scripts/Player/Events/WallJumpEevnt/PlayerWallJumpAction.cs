using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerWallJumpAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.WallJumpEvent.OnWallJump += WallJumpEvent_OnWallJump;
    }
    void OnDisable()
    {
        player.PlayerEvents.WallJumpEvent.OnWallJump -= WallJumpEvent_OnWallJump;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void WallJumpEvent_OnWallJump(WallJumpEvent wallJumpEvent, WallJumpEventArgs wallJumpEventArgs)
    {
        WallJump(wallJumpEventArgs.force);
    }
    void WallJump(Vector2 force)
    {
        player.LateralVelocity = player.gameObject.transform.forward * force.x;
        player.VerticalVelocity = Vector3.up * force.y;
        player.Rigidbody.velocity = player.LateralVelocity + player.VerticalVelocity;
    }
}
