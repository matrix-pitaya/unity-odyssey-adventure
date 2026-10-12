using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class JumpMomentEvent : MonoBehaviour
{
    public event Action<JumpMomentEvent, JumpMomentEventArgs> OnJumpMoment;

    public void CallJumpMomentEvent(float jumpForce)
    {
        OnJumpMoment?.Invoke(this,new JumpMomentEventArgs() { jumpForce = jumpForce });
    }
}

public class JumpMomentEventArgs : EventArgs
{
    public float jumpForce;
}
