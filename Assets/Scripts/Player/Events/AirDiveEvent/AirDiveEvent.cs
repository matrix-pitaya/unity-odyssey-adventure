using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class AirDiveEvent : MonoBehaviour
{
    public event Action<AirDiveEvent, AirDiveEventArgs> OnAirDive;

    public void CallAirDiveEvent(Vector3 direction,  float rotateSpeed)
    {
        OnAirDive?.Invoke(this, new AirDiveEventArgs() { direction = direction, rotateSpeed = rotateSpeed });
    }
}

public class AirDiveEventArgs : EventArgs
{
    public Vector3 direction;
    public float rotateSpeed;
}
