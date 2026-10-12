using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class StompEvent : MonoBehaviour
{
    public event Action<StompEvent, StompEventArgs> OnStomp;

    public void CallStompEvent(Vector3 direction, float acceleration, float maxSpeed,float minSpeed, float rotateSpeed)
    {
        OnStomp?.Invoke(this, new StompEventArgs() { direction= direction, acceleration= acceleration,
            minSpeed = minSpeed ,maxSpeed = maxSpeed, rotateSpeed= rotateSpeed});
    }
}

public class StompEventArgs : EventArgs
{
    public Vector3 direction;
    public float acceleration;
    public float maxSpeed;
    public float minSpeed;
    public float rotateSpeed;
}
