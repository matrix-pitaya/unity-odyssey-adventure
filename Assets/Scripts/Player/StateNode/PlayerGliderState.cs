using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGliderState : PlayerStateNode
{
    public PlayerGliderState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.Rigidbody.velocity = Vector3.zero;
        player.PlayerEvents.GliderAction.EnableGlider(true);
        player.EnableGravity = false;
        player.VerticalVelocity = player.PlayerDetail.GliderFallSpeed * Vector3.down;
    }
    public override void OnUpdata()
    {
        player.PlayerEvents.GliderEvent.CallGliderEvent(player.PlayerControl.MoveRelativeDirection,
            player.PlayerDetail.GliderAcceleration, player.PlayerDetail.GliderMaxSpeed, player.PlayerDetail.GliderRotateSpeed,
            player.PlayerControl.Horizontal, player.PlayerDetail.ModeInclineMaxAngle, player.PlayerDetail.ModeInclineSmoothness);
        if(player.IsOnGround)
        {
            player.SwitchNode(Setting.Idle);
        }
        else if(!player.PlayerControl.IsGlider)
        {
            player.SwitchNode(Setting.Fall);
        }
        else if(player.IsDead)
        {
            player.SwitchNode(Setting.Dead);
        }
    }
    public override void OnExit()
    {
        player.PlayerEvents.GliderAction.EnableGlider(false);
        player.EnableGravity = true;
    }
}
