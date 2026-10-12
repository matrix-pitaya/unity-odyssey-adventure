using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrawStateNode : PlayerStateNode
{
    public PlayerCrawStateNode(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.CapsuleCollider.center = player.PlayerDetail.CapsuleColliderSquatCenter;
        player.CapsuleCollider.height = player.PlayerDetail.CapsuleColliderSquatHeight;
    }
    public override void OnUpdata()
    {
        player.PlayerEvents.CrawEvent.CallCrawEvent(player.PlayerControl.MoveRelativeDirection, player.PlayerDetail.CrawAcceleration,
            player.PlayerDetail.CrawMaxSpeed, player.PlayerDetail.CrawRotateSpeed, player.PlayerDetail.CrawDeceleration);
        if(!player.PlayerControl.IsSquat)
        {
            player.SwitchNode(Setting.Squat);
        }
        else if(player.IsDead)
        {
            player.SwitchNode(Setting.Dead);
        }
    }
    public override void OnExit()
    {
        player.CapsuleCollider.center = player.PlayerDetail.CapsuleColliderNormalCenter;
        player.CapsuleCollider.height = player.PlayerDetail.CapsuleColliderNormalHeight;
    }
}
