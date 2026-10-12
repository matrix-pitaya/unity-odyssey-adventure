using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStompState : PlayerStateNode
{
    public PlayerStompState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.PlayerEvents.StompAction.StartStompCoroutine(player.PlayerDetail.StompDuration);
        player.StompHitBox.BoxCollider.enabled = true;
        player.IsInvincible = true;
        player.PlayerAudio.PlayAudio(PlayerAudioClipType.Stomp);
        player.PlayerParticle.PlayParticleSystem(PlayerParticleType.Dust);
        player.SkinTransform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    public override void OnUpdata()
    {
        player.PlayerEvents.StompEvent.CallStompEvent(player.PlayerControl.MoveRelativeDirection, player.PlayerDetail.AirAcceleration,
            player.PlayerDetail.StompMaxSpeed, player.PlayerDetail.StompMinSpeed, player.PlayerDetail.RotateSpeed);
        if(!player.IsStomp)
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
        player.StompHitBox.BoxCollider.enabled = false;
        player.IsInvincible = false;
        player.PlayerParticle.StopParticleSystem(PlayerParticleType.Dust);
    }
}
