using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WallJumpEvent : MonoBehaviour
{
    public event Action<WallJumpEvent, WallJumpEventArgs> OnWallJump;

    public void CallWallJumpEvent(Vector2 force)
    {
        OnWallJump?.Invoke(this, new WallJumpEventArgs() { force= force });
    }
}

public class WallJumpEventArgs : EventArgs
{
    public Vector2 force;
}