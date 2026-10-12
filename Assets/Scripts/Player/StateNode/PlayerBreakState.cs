using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBreakState : PlayerStateNode
{
    public PlayerBreakState(Player player) : base(player) { }
    public override void OnEnter()
    {

    }
    public override void OnUpdata()
    {
        player.PlayerEvents.BreakEvent.CallBreakEvent(player.PlayerDetail.Deceleration, player.PlayerControl.Horizontal,
            player.PlayerDetail.ModeInclineMaxAngle, player.PlayerDetail.ModeInclineSmoothness);
        if (player.IsOnGround && player.LateralVelocity.sqrMagnitude <= 0)
        {
            player.SwitchNode(Setting.Idle);
        }
        else if(!player.IsOnGround)
        {
            player.SwitchNode(Setting.Fall);
        }
    }
    public override void OnExit()
    {

    }
}
