using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class PauseEvent : MonoBehaviour
{
    public event Action<PauseEvent> OnPause;

    public void CallPauseEvent()
    {
        OnPause?.Invoke(this);
    }
}
