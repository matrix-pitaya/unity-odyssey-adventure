using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyRegionTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(Setting.Player))
        {
            if(other.gameObject.GetComponent<Player>() != null)
            {
                Player player = other.gameObject.GetComponent<Player>();
                player.EnableGravity = false;
                player.EnableFloatForce = true;
                player.FloatForce = player.PlayerDetail.WindFloatForce;
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(Setting.Player))
        {
            if (other.gameObject.GetComponent<Player>() != null)
            {
                Player player = other.gameObject.GetComponent<Player>();
                if(player.EnableGravity)
                {
                    player.EnableGravity = false;
                }
                if (!player.EnableFloatForce)
                {
                    player.EnableFloatForce = true;
                }
                if(player.FloatForce != player.PlayerDetail.WindFloatForce)
                {
                    player.FloatForce = player.PlayerDetail.WindFloatForce;
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Setting.Player))
        {
            if (other.gameObject.GetComponent<Player>() != null)
            {
                Player player = other.gameObject.GetComponent<Player>();
                player.EnableGravity = true;
                player.EnableFloatForce = false;
                player.FloatForce = 0.0f;
            }
        }
    }
}
