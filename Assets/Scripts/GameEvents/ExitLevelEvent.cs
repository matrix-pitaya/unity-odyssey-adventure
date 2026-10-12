using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExitLevelEvent : MonoBehaviour
{
    public event Action<ExitLevelEvent> OnExitLevel;

    public void CallExitLevelEvent()
    {
        OnExitLevel?.Invoke(this);
    }
}
