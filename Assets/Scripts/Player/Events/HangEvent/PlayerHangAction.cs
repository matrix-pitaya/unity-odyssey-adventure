using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerHangAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.HangEvent.OnHang += HangEvent_OnHang;
    }
    void OnDisable()
    {
        player.PlayerEvents.HangEvent.OnHang -= HangEvent_OnHang;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void HangEvent_OnHang(HangEvent climbEvent)
    {
        player.EnableGravity = false;
        player.Rigidbody.velocity = Vector3.zero;
        player.VerticalVelocity = Vector3.zero;
        player.LateralVelocity = Vector3.zero;
    }
}
