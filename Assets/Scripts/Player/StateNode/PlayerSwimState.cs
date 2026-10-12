using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwimState : PlayerStateNode
{
    public PlayerSwimState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.LateralVelocity *= player.PlayerDetail.WaterBufferForce;
        player.VerticalVelocity *= player.PlayerDetail.WaterBufferForce;
        player.Rigidbody.velocity = player.LateralVelocity + player.VerticalVelocity;
        player.FloatForce = player.PlayerDetail.WaterFloatForce;
        player.EnableGravity = false;
        player.SkinTransform.localRotation = Quaternion.Euler(0, 0, 0);
        if (player.IsHold)
        {
            player.HoldCheck.Throw();
        }
    }
    public override void OnUpdata()
    {
        player.EnableFloatForce = player.PlayerWaterCheck.CanFloatInWater;
        player.PlayerEvents.SwimEvent.CallSwimEvent(player.PlayerControl.MoveRelativeDirection, player.PlayerDetail.SwimeMaxSpeed,
            player.PlayerDetail.SwimAcceleration, player.PlayerDetail.SwimDeceleration, player.PlayerDetail.SwimRotateSpeed);
        if (!player.EnableFloatForce && player.PlayerControl.IsJump)
        {
            player.SwitchNode(Setting.Jump);
        }
    }
    public override void OnExit()
    {
        player.FloatForce = 0.0f;
        player.EnableFloatForce = false;
        player.EnableGravity = true;
    }
}
