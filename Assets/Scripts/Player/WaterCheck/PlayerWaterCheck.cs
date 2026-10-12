using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerWaterCheck : MonoBehaviour
{
    Player player;
    bool canFloatInWater;

    public bool CanFloatInWater
    {
        get
        {
            return canFloatInWater;
        }
    }

    void Awake()
    {
        LoadComponent();
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(Setting.Water))
        {
            player.IsInWater = true;
            canFloatInWater = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(Setting.Water))
        {
            canFloatInWater = false;
        }
    }
}
