using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class DeadEvent : MonoBehaviour
{
    public event Action<DeadEvent> OnDead;

    public void CallDeadEvent()
    {
        OnDead?.Invoke(this);
    }
}
