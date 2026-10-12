using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class IdleEvent : MonoBehaviour
{
    public event Action<IdleEvent, IdleEventArgs> OnIdle;

    public void CallIdleEvent(float horizontal, float inlineMaxAngle, float inclineSmoothness)
    {
        OnIdle?.Invoke(this,new IdleEventArgs() { horizontal= horizontal, inlineMaxAngle= inlineMaxAngle,
            inclineSmoothness= inclineSmoothness });
    }
}

public class IdleEventArgs : EventArgs
{
    public float horizontal;
    public float inlineMaxAngle;
    public float inclineSmoothness;
}

