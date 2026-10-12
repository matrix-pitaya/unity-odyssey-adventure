using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerStateNode
{
    public PlayerJumpState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.PlayerEvents.JumpMomentEvent.CallJumpMomentEvent((player.IsInWater || player.IsStomp || player.PlayerEvents.AirDiveAction.IsAirDive) ? player.PlayerDetail.SlightJumpForce :
            (player.IsOnBounce ? player.PlayerDetail.BounceJumpForce : player.PlayerDetail.JumpForce));
        player.PlayerAudio.PlayAudio(PlayerAudioClipType.Jump);
    }
    public override void OnUpdata()
    {
        player.PlayerEvents.AirEvent.CallAirEvent(player.PlayerControl.MoveRelativeDirection,
            player.PlayerDetail.AirAcceleration,
            player.PlayerDetail.WalkMaxSpeed,
            player.PlayerDetail.RotateSpeed);
        if (player.Rigidbody.velocity.y <= 0)
        {
            player.SwitchNode(Setting.Fall);
        }
        else if (!GameManager.Instance.IsGamePause && !player.IsHold && player.PlayerControl.IsSpin)
        {
            player.SwitchNode(Setting.Spin);
        }
        else if(!GameManager.Instance.IsGamePause && !player.IsHold && player.PlayerControl.IsStomp)
        {
            player.SwitchNode(Setting.AirStomp);
        }
        else if(!GameManager.Instance.IsGamePause && !player.IsHold && player.PlayerControl.IsSquat)
        {
            player.SwitchNode(Setting.AirDive);
        }
        else if(!GameManager.Instance.IsGamePause && !player.IsHold && player.PlayerControl.IsGlider)
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
