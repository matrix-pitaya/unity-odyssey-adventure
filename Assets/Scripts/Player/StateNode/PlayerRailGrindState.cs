using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class PlayerRailGrindState : PlayerStateNode
{
    public PlayerRailGrindState(Player player) : base(player) { }
    public override void OnEnter()
    {
        Vector3 localPosition = player.SplineContainer.transform.InverseTransformPoint(player.gameObject.transform.position);
        SplineUtility.GetNearestPoint(player.SplineContainer.Spline, localPosition, out float3 nearset, out t);
        player.SplineContainer.Evaluate(t, out float3 position, out float3 tangent, out float3 normal);
        isBack = Vector3.Dot(player.transform.forward, tangent) < 0;
        railLength = player.SplineContainer.CalculateLength();
        player.EnableGravity = false;
        player.Rigidbody.isKinematic = true;
        player.PlayerParticle.PlayParticleSystem(PlayerParticleType.Rail);
        player.SkinTransform.localRotation = Quaternion.Euler(0, 0, 0);
        player.PlayerAudio.PlayAudio(PlayerAudioClipType.StatrRailFrabbing);
        if (player.IsHold)
        {
            player.HoldCheck.Throw();
        }
    }
    public override void OnUpdata()
    {
        t += isBack ? -Time.deltaTime * player.PlayerDetail.RailGridScaleMultiple / railLength : Time.deltaTime * player.PlayerDetail.RailGridScaleMultiple / railLength;
        t = Mathf.Clamp01(t);
        player.SplineContainer.Evaluate(t, out float3 position, out float3 tangent, out float3 normal);
        position.y += player.PlayerDetail.RailGridOffset;
        player.PlayerEvents.RailGrindEvent.CallRailGrindEvent(position, isBack ? -tangent : tangent, normal);
        if((isBack && t <= 0 ) || (!isBack && t >= 1) || player.PlayerControl.IsJump)
        {
            player.SwitchNode(Setting.Jump);
        }
        player.PlayerAudio.PlayAudio(PlayerAudioClipType.RailGrind);
    }
    public override void OnExit()
    {
        player.EnableGravity = true;
        player.Rigidbody.isKinematic = false;
        player.LateralVelocity = player.gameObject.transform.forward * player.PlayerDetail.RailGridExitInertiaSpeed;
        Quaternion quaternion = player.gameObject.transform.rotation;
        quaternion.x = 0;
        quaternion.z = 0;
        player.gameObject.transform.rotation = quaternion;
        player.PlayerParticle.StopParticleSystem(PlayerParticleType.Rail);
        player.PlayerAudio.StopAudio();
    }

    float t;
    float railLength;
    bool isBack;
}
