using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerRailGrindAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.RailGrindEvent.OnRailGrind += RailGrindEvent_OnRailGrind;
    }
    void OnDisable()
    {
        player.PlayerEvents.RailGrindEvent.OnRailGrind -= RailGrindEvent_OnRailGrind;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void RailGrindEvent_OnRailGrind(RailGrindEvent railGrindEvent, RailGrindEventArgs railGrindEventArgs)
    {
        RailGrid(railGrindEventArgs.position, railGrindEventArgs.tangent, railGrindEventArgs.normal);
    }
    void RailGrid(Vector3 position, Vector3 tangent, Vector3 normal)
    {
        player.gameObject.transform.position = position;
        player.gameObject.transform.rotation = Quaternion.LookRotation(tangent, normal);
    }
}
