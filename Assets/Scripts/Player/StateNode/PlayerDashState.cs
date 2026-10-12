using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerStateNode
{
    public PlayerDashState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.PlayerEvents.DashEvent.CallDashEvent(player.PlayerDetail.DashSpeed, player.PlayerDetail.DashDuration,player.PlayerDetail.DashCD);
        player.PlayerAudio.PlayAudio(PlayerAudioClipType.Dash);
        player.PlayerParticle.PlayParticleSystem(PlayerParticleType.Acceleration);
        if (player.IsHold)
        {
            player.HoldCheck.Throw();
        }
    }
    public override void OnUpdata()
    {
        if(!player.PlayerEvents.DashAction.IsDash)
        {
            player.SwitchNode(Setting.Fall);
        }
    }
    public override void OnExit()
    {
        player.EnableGravity = true;
        player.LateralVelocity = Vector3.zero;
        player.VerticalVelocity = Vector3.zero;
        player.Rigidbody.velocity = Vector3.zero;
    }
}
