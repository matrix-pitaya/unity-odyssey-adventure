using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class SwimEvent : MonoBehaviour
{
    public event Action<SwimEvent, SwimEventArgs> OnSwim;

    public void CallSwimEvent(Vector3 direction, float maxSpeed, float acceleration, float deceleration, float rotateSpeed)
    {
        OnSwim?.Invoke(this, new SwimEventArgs() { direction = direction ,maxSpeed = maxSpeed , 
            acceleration = acceleration, deceleration= deceleration, rotateSpeed = rotateSpeed });
    }
}

public class SwimEventArgs : EventArgs
{
    public Vector3 direction;
    public float maxSpeed;
    public float acceleration;
    public float deceleration;
    public float rotateSpeed;
}
