using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlatform : MonoBehaviour
{
    [Header("PLATFORM TRANSFORM")]
    [SerializeField] Transform platformTransform;

    [Header("GRIDPLATFORM IS LOCKED")]
    [SerializeField] bool isLock;

    IEnumerator moveCoroutine;
    const float rotateDuration = 0.5f;

    void OnEnable()
    {
        GameManager.Instance.Player.PlayerEvents.JumpMomentEvent.OnJumpMoment += JumpMomentEvent_OnJumpMoment;
    }
    void OnDisable()
    {
        GameManager.Instance.Player.PlayerEvents.JumpMomentEvent.OnJumpMoment -= JumpMomentEvent_OnJumpMoment;
    }

    void JumpMomentEvent_OnJumpMoment(JumpMomentEvent jumpMomentEvent, JumpMomentEventArgs jumpMomentEventArgs)
    {
        MoveGridPlatform();
    }
    void MoveGridPlatform()
    {
        if(moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = MoveCoroutine();
        StartCoroutine(moveCoroutine);
    }

    IEnumerator MoveCoroutine()
    {
        Quaternion src = platformTransform.localRotation;
        Quaternion dst = Quaternion.Euler(0, 0, isLock ? 0.0f : 180.0f);
        isLock = !isLock;
        float passTime = 0.0f;
        while (true)
        {
            platformTransform.localRotation = Quaternion.Lerp(src, dst, passTime / rotateDuration);
            passTime += Time.deltaTime;
            if (passTime >= rotateDuration)
            {
                break;
            }
            yield return null;
        }
        platformTransform.localRotation = dst;
    }
}
