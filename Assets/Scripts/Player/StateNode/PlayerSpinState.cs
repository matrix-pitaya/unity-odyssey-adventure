using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpinState : PlayerStateNode
{
    public PlayerSpinState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.SpinHitBox.BoxCollider.enabled = true;
        player.IsInvincible = true;
        player.PlayerEvents.SpinAction.StartSpinCoroutine(player.PlayerDetail.SpinDuration);
        player.PlayerAudio.PlayAudio(PlayerAudioClipType.Spin);
        player.SpinTrail.EnableSpinTrail(true);
    }
    public override void OnUpdata()
    {
        player.PlayerEvents.SpinEvent.CallSpinEvent(player.PlayerDetail.RunMaxSpeed, player.PlayerDetail.AirAcceleration,
            player.PlayerDetail.RotateSpeed, player.PlayerControl.MoveRelativeDirection, player.PlayerControl.Horizontal,
            player.PlayerDetail.ModeInclineMaxAngle, player.PlayerDetail.ModeInclineSmoothness);
        if (!player.PlayerEvents.SpinAction.IsSpine)
        {
            if(player.IsOnGround)
            {
                if (player.IsInWater)
                {
                    player.SwitchNode(Setting.Swim);
                }
                else
                {
                    if (player.PlayerControl.MoveAbsoluteDirection.sqrMagnitude > 0)
                    {
                        player.SwitchNode(Setting.Move);
                    }
                    else
                    {
                        player.SwitchNode(Setting.Idle);
                    }
                }
            }
            else
            {
                player.SwitchNode(Setting.Fall);
            }
        }
    }
    public override void OnExit()
    {
        player.SpinHitBox.BoxCollider.enabled = false;
        player.IsInvincible = false;
        player.SpinTrail.EnableSpinTrail(false);
    }
}
