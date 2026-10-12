using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbPoleState : PlayerStateNode
{
    public PlayerClimbPoleState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.EnableGravity = false;
        player.LateralVelocity = Vector3.zero;
        player.VerticalVelocity = Vector3.zero;
        player.Rigidbody.velocity = Vector3.zero;
        player.Rigidbody.isKinematic = true;
    }
    public override void OnUpdata()
    {
        player.PlayerEvents.ClimbPoleEvent.CallClimbPoleEvent(player.PlayerControl.MoveAbsoluteDirection,
            player.PlayerDetail.ClimbPoleUpSpeed, player.PlayerDetail.ClimbPoleDownSpeed, player.PlayerDetail.ClimbPoleRotateSpeed);
        if(player.PlayerControl.IsJump)
        {
            player.LateralVelocity = Vector3.zero;
            player.VerticalVelocity = Vector3.zero;
            Vector3 facingPoleDirection = player.ClimbPoleTransform.position - player.gameObject.transform.position;
            facingPoleDirection.y = 0.0f;
            facingPoleDirection.Normalize();
            player.gameObject.transform.forward = -facingPoleDirection;
            player.SwitchNode(Setting.WallJump);
        }
        else if(player.IsOnGround)
        {
            player.SwitchNode(Setting.Idle);
        }
        else if (player.IsInWater)
        {
            player.SwitchNode(Setting.Swim);
        }
    }
    public override void OnExit()
    {
        player.EnableGravity = true;
        player.Rigidbody.isKinematic = false;
    }
}
