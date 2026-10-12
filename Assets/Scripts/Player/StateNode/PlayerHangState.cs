using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHangState : PlayerStateNode
{
    public PlayerHangState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.PlayerEvents.HangEvent.CallHangEvent();
    }
    public override void OnUpdata()
    {
        if(player.PlayerControl.IsJump)
        {
            player.SwitchNode(Setting.HangClimb);
        }
    }
    public override void OnExit()
    {
        player.EnableGravity = true;
    }
}
