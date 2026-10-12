using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class CrawEvent : MonoBehaviour
{
    public event Action<CrawEvent, CrawEventArgs> OnCraw;

    public void CallCrawEvent(Vector3 direction, float acceleration, float maxSpeed, float rotateSpeed, float deceleration)
    {
        OnCraw?.Invoke(this, new CrawEventArgs() { direction = direction, acceleration = acceleration, 
            maxSpeed = maxSpeed, rotateSpeed = rotateSpeed, deceleration = deceleration });
    }
}

public class CrawEventArgs : EventArgs
{
    public Vector3 direction;
    public float acceleration;
    public float maxSpeed;
    public float rotateSpeed;
    public float deceleration;
}
