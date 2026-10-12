using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class ResumeEvent : MonoBehaviour
{
    public event Action<ResumeEvent> OnResume;

    public void CallResumeEvent()
    {
        OnResume?.Invoke(this);
    }
}
