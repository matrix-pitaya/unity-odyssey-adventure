using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class WallSliderEvent : MonoBehaviour
{
    public event Action<WallSliderEvent, WallSliderEventArgs> OnWallSlider;

    public void CallWallSliderEvent(float speed)
    {
        OnWallSlider?.Invoke(this, new WallSliderEventArgs() { speed = speed });
    }
}

public class WallSliderEventArgs : EventArgs
{
    public float speed;
}
