using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RestarLevelEvent : MonoBehaviour
{
    public event Action<RestarLevelEvent> OnRestarLevel;

    public void CallRestarLevelEvent()
    {
        OnRestarLevel?.Invoke(this);
    }
}
