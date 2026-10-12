using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMoveState : SlimeStateNode
{
    public SlimeMoveState(Slime slime) : base(slime) { }
    public override void OnEnter()
    {

    }
    public override void OnUpdata()
    {
        slime.MovementEvent.CallMovementEvent(slime.TargetDirection, slime.SlimeDetails.Acceleration,
                slime.SlimeDetails.MaxSpeed, slime.SlimeDetails.RotateSpeed, 0, 0, 0);
        if (slime.PathPatrolObject.IsArriveCurrentPathPoint)
        {
            slime.PathPatrolObject.ToNextPathPoint();
            slime.SwitchNode(Setting.Idle);
        }
        else if(slime.IsDead)
        {
            slime.SwitchNode(Setting.Dead);
        }
    }
    public override void OnExit()
    {

    }
}
