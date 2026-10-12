using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class BreakEvent : MonoBehaviour
{
    public event Action<BreakEvent, BreakEventArgs> OnBreak;

    public void CallBreakEvent(float deceleration, float horizontal, float inlineMaxAngle, float inclineSmoothness)
    {
        OnBreak?.Invoke(this, new BreakEventArgs() { deceleration = deceleration , horizontal = horizontal, 
            inlineMaxAngle = inlineMaxAngle, inclineSmoothness = inclineSmoothness });
    }
}

public class BreakEventArgs : EventArgs
{
    public float deceleration;
    public float horizontal;
    public float inlineMaxAngle;
    public float inclineSmoothness;
}
