using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateNode : StateNode
{
    protected Player player;
    public PlayerStateNode(Player player)
    {
        this.player = player;
    }
    public abstract override void OnEnter();
    public abstract override void OnUpdata();
    public abstract override void OnExit();
}
