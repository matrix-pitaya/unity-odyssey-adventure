using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class BackFlipEvent : MonoBehaviour
{
    public event Action<BackFlipEvent, BackFlipEventArgs> OnBackFlip;

    public void CallBackFlipEvent(Vector2 force, float blackFlipInvertalTime)
    {
        OnBackFlip?.Invoke(this, new BackFlipEventArgs() { force = force, blackFlipInvertalTime = blackFlipInvertalTime });
    }
}

public class BackFlipEventArgs : EventArgs
{
    public Vector2 force;
    public float blackFlipInvertalTime;
}
