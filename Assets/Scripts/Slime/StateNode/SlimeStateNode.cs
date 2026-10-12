using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SlimeStateNode : StateNode
{
    protected Slime slime;
    public SlimeStateNode(Slime slime)
    {
        this.slime = slime;
    }
    public abstract override void OnEnter();
    public abstract override void OnUpdata();
    public abstract override void OnExit();
}
