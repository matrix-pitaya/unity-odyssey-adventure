using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerBackFlipAction : MonoBehaviour
{
    Player player;
    IEnumerator blackFlipCoroutine;
    bool isBlackFlipInterval;

    public bool IsBlackFlipInterval
    {
        get
        {
            return isBlackFlipInterval;
        }
    }

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.BackFlipEvent.OnBackFlip += BackFlipEvent_OnBackFlip;
    }
    void OnDisable()
    {
        player.PlayerEvents.BackFlipEvent.OnBackFlip -= BackFlipEvent_OnBackFlip;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void BackFlipEvent_OnBackFlip(BackFlipEvent backFlipEvent, BackFlipEventArgs backFlipEventArgs)
    {
        BackFlip(backFlipEventArgs.force);
        if (blackFlipCoroutine != null)
        {
            StopCoroutine(blackFlipCoroutine);
        }
        blackFlipCoroutine = BlackFlipCoroutine(backFlipEventArgs.blackFlipInvertalTime);
        StartCoroutine(blackFlipCoroutine);
    }
    void BackFlip(Vector2 force)
    {
        player.LateralVelocity = -player.gameObject.transform.forward * force.x;
        player.VerticalVelocity = Vector3.up * force.y;
        player.Rigidbody.velocity = player.LateralVelocity + player.VerticalVelocity;
    }

    public void StopBlackFlipCoroutine()
    {
        if(blackFlipCoroutine != null)
        {
            StopCoroutine(blackFlipCoroutine);
        }
    }

    IEnumerator BlackFlipCoroutine(float duration)
    {
        isBlackFlipInterval = true;
        yield return new WaitForSeconds(duration);
        isBlackFlipInterval = false;
    }
}
