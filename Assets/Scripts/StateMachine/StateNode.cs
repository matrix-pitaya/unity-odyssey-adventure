using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateNode
{
    public abstract void OnEnter();
    public abstract void OnUpdata();
    public abstract void OnExit();
}
