using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerJumpMomentAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.JumpMomentEvent.OnJumpMoment += JumpMomentEvent_OnJumpMoment;
    }
    void OnDisable()
    {
        player.PlayerEvents.JumpMomentEvent.OnJumpMoment -= JumpMomentEvent_OnJumpMoment;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void JumpMomentEvent_OnJumpMoment(JumpMomentEvent jumpMomentEvent, JumpMomentEventArgs jumpMomentEventArgs)
    {
        OnJump(jumpMomentEventArgs.jumpForce);
        RestModeInline();
    }
    void OnJump(float jumpForce)
    {
        player.VerticalVelocity = Vector3.up * jumpForce;
        player.Rigidbody.velocity = player.VerticalVelocity + player.LateralVelocity;
    }
    void RestModeInline()
    {
        player.SkinTransform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
