using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class AirStompEvent : MonoBehaviour
{
    public event Action<AirStompEvent> OnAirStomp;

    public void CallAirStompEvent()
    {
        OnAirStomp?.Invoke(this);
    }
}
