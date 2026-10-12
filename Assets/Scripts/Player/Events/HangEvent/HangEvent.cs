using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class HangEvent : MonoBehaviour
{
    public event Action<HangEvent> OnHang;

    public void CallHangEvent()
    {
        OnHang?.Invoke(this);
    }
}
