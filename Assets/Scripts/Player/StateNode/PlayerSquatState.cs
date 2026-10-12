using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSquatState : PlayerStateNode
{
    public PlayerSquatState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.CapsuleCollider.center = player.PlayerDetail.CapsuleColliderSquatCenter;
        player.CapsuleCollider.height = player.PlayerDetail.CapsuleColliderSquatHeight;
    }
    public override void OnUpdata()
    {
        player.PlayerEvents.SquatEvent.CallSquatEvent(player.PlayerControl.Horizontal, player.PlayerDetail.ModeInclineMaxAngle,
                player.PlayerDetail.ModeInclineSmoothness, player.PlayerDetail.CrawDeceleration);
        if (player.IsDead)
        {
            player.SwitchNode(Setting.Dead);
        }
        else
        {
            if (!player.PlayerControl.IsSquat)
            {
                player.SwitchNode(Setting.Idle);
            }
            else if(player.PlayerControl.IsJump)
            {
                player.SwitchNode(Setting.BackFlip);
            }
            else if(player.LateralVelocity.sqrMagnitude <= 0 && player.PlayerControl.MoveAbsoluteDirection.sqrMagnitude > 0)
            {
                player.SwitchNode(Setting.Craw);
            }
        }
    }
    public override void OnExit()
    {
        player.CapsuleCollider.center = player.PlayerDetail.CapsuleColliderNormalCenter;
        player.CapsuleCollider.height = player.PlayerDetail.CapsuleColliderNormalHeight;
    }
}
