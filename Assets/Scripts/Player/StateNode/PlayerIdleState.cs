using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerStateNode
{
    public PlayerIdleState(Player player) : base(player) { }
    public override void OnEnter()
    {

    }
    public override void OnUpdata()
    {
        player.PlayerEvents.IdleEvent.CallIdleEvent(player.PlayerControl.Horizontal, 
            player.PlayerDetail.ModeInclineMaxAngle, player.PlayerDetail.ModeInclineSmoothness);
        if (player.IsOnGround && player.PlayerControl.MoveAbsoluteDirection.sqrMagnitude > 0)
        {
            player.SwitchNode(Setting.Move);
        }
        else if(player.IsOnGround && player.PlayerControl.IsJump)
        {
            player.SwitchNode(Setting.Jump);
        }
        else if(!player.IsOnGround)
        {
            player.SwitchNode(Setting.Fall);
        }
        else if (!GameManager.Instance.IsGamePause && !player.IsHold && player.PlayerControl.IsSpin)
        {
            player.SwitchNode(Setting.Spin);
        }
        else if(!GameManager.Instance.IsGamePause && !player.IsHold && player.PlayerControl.IsStomp)
        {
            player.SwitchNode(Setting.Stomp);
        }
        else if (player.IsOnGround && !GameManager.Instance.IsGamePause && player.PlayerControl.IsSquat)
        {
            player.SwitchNode(Setting.Squat);
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
