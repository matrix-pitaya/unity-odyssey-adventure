using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class ClimbPoleEvent : MonoBehaviour
{
    public event Action<ClimbPoleEvent, ClimbPoleEventArgs> OnClimbPole;

    public void CallClimbPoleEvent(Vector3 direction, float climbUpSpeed, float climDownSpeed, float climbRotateSpeed)
    {
        OnClimbPole?.Invoke(this, new ClimbPoleEventArgs() { direction = direction, climbUpSpeed = climbUpSpeed, 
            climDownSpeed = climDownSpeed, climbRotateSpeed = climbRotateSpeed });
    }
}

public class ClimbPoleEventArgs : EventArgs
{
    public Vector3 direction;
    public float climbUpSpeed;
    public float climDownSpeed;
    public float climbRotateSpeed;
}
