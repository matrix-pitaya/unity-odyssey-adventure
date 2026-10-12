using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIdleState : SlimeStateNode
{
    public SlimeIdleState(Slime slime) : base(slime) { }
    public override void OnEnter()
    {
        slime.IdleAction.StartIdleCoroutine();
    }
    public override void OnUpdata()
    {
        slime.IdleEvent.CallIdleEvent(0, 0, 0);
        if (slime.IsDead)
        {
            slime.SwitchNode(Setting.Dead);
        }
        else
        {
            if (!slime.IsIdle || (slime.IsCheckPlayer && slime.AttackPlayer.CanAttack))
            {
                slime.SwitchNode(Setting.Move);
            }
        }
    }
    public override void OnExit()
    {

    }
}
