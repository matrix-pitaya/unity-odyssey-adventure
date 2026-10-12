using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHangClimeState : PlayerStateNode
{
    public PlayerHangClimeState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.PlayerEvents.HangClimbEvent.CallHangClimbEvent();
    }
    public override void OnUpdata()
    {
        if(!player.PlayerEvents.HangClimbAction.IsHangClimb)
        {
            player.SwitchNode(Setting.Idle);
        }
        else if(player.IsDead)
        {
            player.SwitchNode(Setting.Dead);
        }
    }
    public override void OnExit()
    {
        player.EnableGravity = true;
    }
}
