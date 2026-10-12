using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RestartCheckPointEvent : MonoBehaviour
{
    public event Action<RestartCheckPointEvent> OnRestartCheckPoint;

    public void CallRestartCheckPointEvent()
    {
        OnRestartCheckPoint?.Invoke(this);
    }
}
