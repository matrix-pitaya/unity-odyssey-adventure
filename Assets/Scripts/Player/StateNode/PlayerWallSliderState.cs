using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSliderState : PlayerStateNode
{
    public PlayerWallSliderState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.PlayerEvents.WallSliderEvent.CallWallSliderEvent(player.PlayerDetail.WallSliderSpeed);
    }
    public override void OnUpdata()
    {
        if (player.PlayerControl.IsJump)
        {
            player.SwitchNode(Setting.WallJump);
        }
        else if(player.IsOnGround)
        {
            player.SwitchNode(Setting.Idle);
        }
        else if(!player.IsBackWall)
        {
            player.SwitchNode(Setting.Fall);
        }
    }
    public override void OnExit()
    {
        player.EnableGravity = true;
        player.LateralVelocity = player.Rigidbody.velocity;
        player.VerticalVelocity = player.Rigidbody.velocity;
    }
}
