using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class AirEvent : MonoBehaviour
{
    public event Action<AirEvent, AirEventArgs> OnAir;

    public void CallAirEvent(Vector3 direction, float acceleration, float maxSpeed, float rotateSpeed)
    {
        OnAir?.Invoke(this, new AirEventArgs(){ direction = direction,
            acceleration = acceleration, maxSpeed = maxSpeed,rotateSpeed = rotateSpeed });
    }
}

public class AirEventArgs : EventArgs
{
    public Vector3 direction;
    public float acceleration;
    public float maxSpeed;
    public float rotateSpeed;
}

