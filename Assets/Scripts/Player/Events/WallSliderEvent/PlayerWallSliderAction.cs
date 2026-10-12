using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerWallSliderAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.WallSliderEvent.OnWallSlider += WallSliderEvent_OnWallSlider;
    }
    void OnDisable()
    {
        player.PlayerEvents.WallSliderEvent.OnWallSlider -= WallSliderEvent_OnWallSlider;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void WallSliderEvent_OnWallSlider(WallSliderEvent wallSliderEvent, WallSliderEventArgs wallSliderEventArgs)
    {
        WallSlider(wallSliderEventArgs.speed);
    }
    void WallSlider(float speed)
    {
        player.EnableGravity = false;
        player.Rigidbody.velocity = Vector3.down * speed;
        player.gameObject.transform.forward = -player.gameObject.transform.forward;
    }
}
