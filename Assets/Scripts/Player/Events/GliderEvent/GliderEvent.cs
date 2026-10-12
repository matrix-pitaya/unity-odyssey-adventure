using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class GliderEvent : MonoBehaviour
{
    public event Action<GliderEvent, GliderEventArgs> OnGlider;

    public void CallGliderEvent(Vector3 direction, float acceleration, float maxSpeed, float rotateSpeed, float horizontal, float inlineMaxAngle, float inclineSmoothness)
    {
        OnGlider?.Invoke(this, new GliderEventArgs() { direction = direction , acceleration = acceleration , maxSpeed = maxSpeed ,
            rotateSpeed = rotateSpeed, horizontal= horizontal, inlineMaxAngle= inlineMaxAngle,inclineSmoothness = inclineSmoothness });
    }
}

public class GliderEventArgs : EventArgs
{
    public Vector3 direction;
    public float acceleration;
    public float maxSpeed;
    public float rotateSpeed;
    public float horizontal;
    public float inlineMaxAngle;
    public float inclineSmoothness;
}
