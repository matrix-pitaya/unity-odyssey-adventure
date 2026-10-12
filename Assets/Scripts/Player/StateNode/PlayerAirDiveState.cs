using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirDiveState : PlayerStateNode
{
    public PlayerAirDiveState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.PlayerEvents.AirDiveAction.StartAirDiveCoroutine(player.PlayerDetail.AirDiveForce, player.PlayerDetail.AirDiveInvertalTime);
        player.PlayerAudio.PlayAudio(PlayerAudioClipType.AirDive);
        player.PlayerParticle.PlayParticleSystem(PlayerParticleType.Acceleration);
        player.CapsuleCollider.material = null;
    }
    public override void OnUpdata()
    {
        player.PlayerEvents.AirDiveEvent.CallAirDiveEvent(player.PlayerControl.MoveRelativeDirection, player.PlayerDetail.AirDiveRotateSpeed);
        if (player.IsDead)
        {
            player.PlayerEvents.AirDiveAction.StopAirDiveCoroutine();
            player.SwitchNode(Setting.Dead);
        }
    }
    public override void OnExit()
    {
        player.LateralVelocity = Vector3.zero;
        player.VerticalVelocity = Vector3.zero;
        player.Rigidbody.velocity = Vector3.zero;
        player.CapsuleCollider.material = GameResourceManager.Instance.SmoothPhysicMaterial;
    }
}
