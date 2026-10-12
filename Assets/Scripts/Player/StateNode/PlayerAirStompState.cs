using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirStompState : PlayerStateNode
{
    public PlayerAirStompState(Player player) : base(player) { }
    public override void OnEnter()
    {
        player.PlayerEvents.AirStompEvent.CallAirStompEvent();
    }
    public override void OnUpdata()
    {

    }
    public override void OnExit()
    {

    }
}
