using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerStateNode
{
    public PlayerDeadState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.PlayerEvents.DeadEvent.CallDeadEvent();
        if (player.IsHold)
        {
            player.HoldCheck.Throw();
        }
    }
    public override void OnUpdata()
    {

    }
    public override void OnExit()
    {
        player.gameObject.GetComponent<CapsuleCollider>().material = GameResourceManager.Instance.SmoothPhysicMaterial;
    }
}
