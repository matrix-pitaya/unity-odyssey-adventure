using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtState : PlayerStateNode
{
    public PlayerHurtState(Player player) : base(player) { }
    public override void OnEnter()
    {
        if(player.IsHold)
        {
            player.HoldCheck.Throw();
        }
        player.PlayerParticle.PlayParticleSystem(PlayerParticleType.Stars);
        player.PlayerAudio.PlayAudio(PlayerAudioClipType.Hurt);
        player.SkinTransform.localRotation = Quaternion.Euler(0, 0, 0);
    }
    public override void OnUpdata()
    {
        if (!player.IsHurt)
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

    }
}
