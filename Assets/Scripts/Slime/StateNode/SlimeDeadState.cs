using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDeadState : SlimeStateNode
{
    public SlimeDeadState(Slime slime) : base(slime) { }
    public override void OnEnter()
    {
        slime.DeadEvent.CallDeadEvent();
    }
    public override void OnUpdata()
    {

    }
    public override void OnExit()
    {

    }
}
