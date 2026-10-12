using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class RailGrindEvent : MonoBehaviour
{
    public event Action<RailGrindEvent, RailGrindEventArgs> OnRailGrind;

    public void CallRailGrindEvent(Vector3 position, Vector3 tangent, Vector3 normal)
    {
        OnRailGrind?.Invoke(this,new RailGrindEventArgs() { position = position ,
            tangent = tangent,  normal= normal});
    }
}

public class RailGrindEventArgs : EventArgs
{
    public Vector3 position;
    public Vector3 tangent;
    public Vector3 normal;
}
