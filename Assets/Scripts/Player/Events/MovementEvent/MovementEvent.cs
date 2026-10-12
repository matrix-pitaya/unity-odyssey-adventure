using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class MovementEvent : MonoBehaviour
{
    public event Action<MovementEvent, MovementEventArgs> OnMovement;

    public void CallMovementEvent(Vector3 direction, float acceleration, float maxSpeed, float rotateSpeed, float horizontal, float inlineMaxAngle, float inclineSmoothness)
    {
        OnMovement?.Invoke(this, new MovementEventArgs() { direction  = direction , acceleration = acceleration , maxSpeed = maxSpeed  ,
            rotateSpeed = rotateSpeed , horizontal= horizontal , inlineMaxAngle = inlineMaxAngle, inclineSmoothness= inclineSmoothness });
    }
}

public class MovementEventArgs : EventArgs
{
    public Vector3 direction;
    public float acceleration;
    public float maxSpeed;
    public float rotateSpeed;
    public float horizontal;
    public float inlineMaxAngle;
    public float inclineSmoothness;
}
