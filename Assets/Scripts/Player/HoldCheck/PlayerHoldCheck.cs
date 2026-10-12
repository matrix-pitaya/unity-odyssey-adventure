using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldCheck : MonoBehaviour
{
    GameObject holdObject;
    BoxCollider boxCollider;
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void Update()
    {
        OnHoldCheck();
    }

    void LoadComponent()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
        player = gameObject.GetComponentInParent<Player>();
    }
    void OnHoldCheck()
    {
        if (player.PlayerControl.IsHoldOrThrow)
        {
            if (player.IsHold)
            {
                Throw();
            }
            else
            {
                Hold();
            }
        }
    }

    public void Throw()
    {
        if(holdObject != null)
        {
            if (holdObject.GetComponent<Crate>() != null)
            {
                holdObject.GetComponent<Crate>().Throw(player.gameObject.transform);
                player.IsHold = false;
                boxCollider.enabled = true;
                player.PlayerAudio.PlayAudio(PlayerAudioClipType.Throw);
            }
        }
    }
    public void Hold()
    {
        if (holdObject != null)
        {
            if (holdObject.GetComponent<Crate>() != null)
            {
                holdObject.GetComponent<Crate>().PickUp(player.HoldCrateTransform);
                player.IsHold = true;
                boxCollider.enabled = false;
                player.PlayerAudio.PlayAudio(PlayerAudioClipType.PickUp);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Setting.TagCrate))
        {
            holdObject = other.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(holdObject != null && other.gameObject == holdObject)
        {
            holdObject = null;
        }
    }
}
