using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class HangClimbEvent : MonoBehaviour
{
    public event Action<HangClimbEvent> OnHangClimb;

    public void CallHangClimbEvent()
    {
        OnHangClimb?.Invoke(this);
    }
}
