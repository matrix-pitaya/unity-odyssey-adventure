using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class SpinEvent : MonoBehaviour
{
    public event Action<SpinEvent, SpinEventArgs> OnSpin;

    public void CallSpinEvent(float moveMaxSpeed, float acceleration, float rotateSpeed, Vector3 moveDirection, float horizontal, float inlineMaxAngle, float inclineSmoothness)
    {
        OnSpin?.Invoke(this, new SpinEventArgs() { moveMaxSpeed = moveMaxSpeed, acceleration = acceleration, rotateSpeed = rotateSpeed, 
            moveDirection = moveDirection, horizontal = horizontal, inlineMaxAngle = inlineMaxAngle, inclineSmoothness = inclineSmoothness });
    }
}

public class SpinEventArgs : EventArgs
{
    public float moveMaxSpeed;
    public float acceleration;
    public float rotateSpeed;
    public Vector3 moveDirection;
    public float horizontal;
    public float inlineMaxAngle;
    public float inclineSmoothness;
}