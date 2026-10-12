using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerStateNode
{
    public PlayerMoveState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.PlayerParticle.PlayParticleSystem(PlayerParticleType.Dust);
    }
    public override void OnUpdata()
    {
        player.PlayerEvents.MovementEvent.CallMovementEvent(player.PlayerControl.MoveRelativeDirection,
           (player.PlayerControl.IsRunning ? player.PlayerDetail.RunAcceleration : player.PlayerDetail.WalkAcceleration),
           (player.PlayerControl.IsRunning ? player.PlayerDetail.RunMaxSpeed : player.PlayerDetail.WalkMaxSpeed),
           player.PlayerDetail.RotateSpeed,player.PlayerControl.Horizontal,player.PlayerDetail.ModeInclineMaxAngle,player.PlayerDetail.ModeInclineSmoothness);
        player.PlayerAudio.PlayAudio(PlayerAudioClipType.Move);
        if (player.IsOnGround && player.PlayerControl.IsJump)
        {
            player.SwitchNode(Setting.Jump);
        }
        else if(player.IsOnGround && player.PlayerControl.MoveAbsoluteDirection.sqrMagnitude <= 0)
        {
            player.SwitchNode(Setting.Break);
        }
        else if(!player.IsOnGround)
        {
            player.SwitchNode(Setting.Fall);
        }
        else if (!GameManager.Instance.IsGamePause && !player.IsHold && player.PlayerControl.IsSpin)
        {
            player.SwitchNode(Setting.Spin);
        }
        else if (!GameManager.Instance.IsGamePause && !player.IsHold && player.PlayerControl.IsStomp)
        {
            player.SwitchNode(Setting.Stomp);
        }
        else if (player.IsRailGrid)
        {
            player.SwitchNode(Setting.RailGrind);
        }
        else if (player.IsOnGround && !GameManager.Instance.IsGamePause && player.PlayerControl.IsSquat)
        {
            player.SwitchNode(Setting.Squat);
        }
        else if(!GameManager.Instance.IsGamePause && player.PlayerControl.IsDash && player.PlayerEvents.DashAction.CanDash)
        {
            player.SwitchNode(Setting.Dash);
        }
    }
    public override void OnExit()
    {
        player.PlayerParticle.StopParticleSystem(PlayerParticleType.Dust);
    }
}
