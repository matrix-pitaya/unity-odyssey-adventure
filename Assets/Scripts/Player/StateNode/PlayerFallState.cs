using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerStateNode
{
    public PlayerFallState(Player player) : base(player) { }
    public override void OnEnter()
    {

    }
    public override void OnUpdata()
    {
        player.PlayerEvents.AirEvent.CallAirEvent(player.PlayerControl.MoveRelativeDirection,
            player.PlayerDetail.AirAcceleration,
            player.PlayerDetail.WalkMaxSpeed,
            player.PlayerDetail.RotateSpeed);
        if (player.IsOnGround)
        {
            player.SwitchNode(Setting.Idle);
            player.PlayerParticle.PlayParticleSystem(PlayerParticleType.Land);
        }
        else if (!GameManager.Instance.IsGamePause && !player.IsHold && player.PlayerControl.IsSpin)
        {
            player.SwitchNode(Setting.Spin);
        }
        else if(!player.IsHold && player.CanHang)
        {
            player.SwitchNode(Setting.Hang);
        }
        else if (!GameManager.Instance.IsGamePause && !player.IsHold && player.PlayerControl.IsStomp)
        {
            player.SwitchNode(Setting.AirStomp);
        }
        else if(player.IsRailGrid)
        {
            player.SwitchNode(Setting.RailGrind);
        }
        else if(player.IsInWater)
        {
            player.SwitchNode(Setting.Swim);
        }
        else if (!GameManager.Instance.IsGamePause && !player.IsHold && player.PlayerControl.IsGlider)
        {
            player.SwitchNode(Setting.Glider);
        }
        else if (!GameManager.Instance.IsGamePause && player.PlayerControl.IsDash && player.PlayerEvents.DashAction.CanDash)
        {
            player.SwitchNode(Setting.Dash);
        }
        else if (!player.IsHold && player.CanWallSlider)
        {
            player.SwitchNode(Setting.WallSlider);
        }
        else if(!player.IsHold && player.IsClimbPole)
        {
            player.SwitchNode(Setting.ClimbPole);
        }
    }
    public override void OnExit()
    {

    }
}
