using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    StateNode stateNode;
    Dictionary<string, StateNode> stateNodePool;

    public StateMachine()
    {
        stateNodePool = new Dictionary<string, StateNode>();
    }
    public void SetEntry(string id)
    {
        stateNode = stateNodePool[id];
        stateNode.OnEnter();
    }
    public void OnUpdata()
    {
        stateNode.OnUpdata();
    }
    public void SwitchTo(string id)
    {
        stateNode.OnExit();
        stateNode = stateNodePool[id];
        stateNode.OnEnter();
    }
    public void RegisterState(string id, StateNode stateNode)
    {
        stateNodePool.Add(id, stateNode);
    }
    public void DestoryState(string id)
    {
        stateNodePool.Remove(id);
    }
}
