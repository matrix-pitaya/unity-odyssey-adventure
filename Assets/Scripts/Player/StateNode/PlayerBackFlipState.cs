using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackFlipState : PlayerStateNode
{
    public PlayerBackFlipState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.PlayerEvents.BackFlipEvent.CallBackFlipEvent(player.PlayerDetail.BackFlipForce, player.PlayerDetail.BackFlipInvertalTime);
        player.PlayerAudio.PlayAudio(PlayerAudioClipType.Maneuver);
    }
    public override void OnUpdata()
    {
        if(!player.PlayerEvents.BackFlipAction.IsBlackFlipInterval && player.IsOnGround)
        {
            player.SwitchNode(Setting.Idle);
        }
        else if(player.IsDead)
        {
            player.PlayerEvents.BackFlipAction.StopBlackFlipCoroutine();
            player.SwitchNode(Setting.Dead);
        }
    }
    public override void OnExit()
    {

    }
}
