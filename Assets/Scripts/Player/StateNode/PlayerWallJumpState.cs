using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerStateNode
{
    public PlayerWallJumpState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.PlayerEvents.WallJumpEvent.CallWallJumpEvent(player.PlayerDetail.WallJumpForce);
    }
    public override void OnUpdata()
    {
        if (!player.IsOnGround && player.Rigidbody.velocity.y < 0)
        {
            player.SwitchNode(Setting.Fall);
        }
        else if (!GameManager.Instance.IsGamePause && !player.IsHold && player.PlayerControl.IsSpin)
        {
            player.SwitchNode(Setting.Spin);
        }
        else if (!GameManager.Instance.IsGamePause && !player.IsHold && player.PlayerControl.IsStomp)
        {
            player.SwitchNode(Setting.AirStomp);
        }
        else if (!GameManager.Instance.IsGamePause && !player.IsHold && player.PlayerControl.IsSquat)
        {
            player.SwitchNode(Setting.AirDive);
        }
        else if (!GameManager.Instance.IsGamePause && !player.IsHold && player.PlayerControl.IsGlider)
        {
            player.SwitchNode(Setting.Glider);
        }
        else if (!GameManager.Instance.IsGamePause && player.PlayerControl.IsDash && player.PlayerEvents.DashAction.CanDash)
        {
            player.SwitchNode(Setting.Dash);
        }
    }
    public override void OnExit()
    {

    }
}
