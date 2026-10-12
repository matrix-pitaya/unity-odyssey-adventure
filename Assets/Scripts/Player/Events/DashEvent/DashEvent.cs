using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class DashEvent : MonoBehaviour
{
    public event Action<DashEvent, DashEventArgs> OnDash;

    public void CallDashEvent(float speed, float duration, float dashCD)
    {
        OnDash?.Invoke(this, new DashEventArgs() { speed = speed, duration = duration , dashCD = dashCD });
    }
}

public class DashEventArgs : EventArgs
{
    public float speed;
    public float duration;
    public float dashCD;
}
