using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class SquatEvent : MonoBehaviour
{
    public event Action<SquatEvent, SquatEventArgs> OnSquat;

    public void CallSquatEvent(float horizontal, float inlineMaxAngle, float inclineSmoothness, float deceleration)
    {
        OnSquat?.Invoke(this, new SquatEventArgs() { horizontal = horizontal, inlineMaxAngle = inlineMaxAngle, 
            inclineSmoothness = inclineSmoothness, deceleration = deceleration });
    }
}

public class SquatEventArgs : EventArgs
{
    public float horizontal;
    public float inlineMaxAngle;
    public float inclineSmoothness;
    public float deceleration;
}