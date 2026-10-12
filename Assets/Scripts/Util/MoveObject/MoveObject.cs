using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveObject : MonoBehaviour
{
    [Header("MOVE OBJECT INFORMATION")]
    [SerializeField] GameObject moveObject;
    [SerializeField] float targetDuration;
    [SerializeField] float recoverDuration;
    [SerializeField] Vector3 organialPosition;
    [SerializeField] Vector3 targetPosition;

    [Header("MOVE TARGET OVER CALL BACK EVENT")]
    [SerializeField] UnityEvent targetCallBackEvent;

    [Header("RECOVER OVER CALL BACK EVENT")]
    [SerializeField] UnityEvent recoverCallBackEvent;

    IEnumerator moveCoroutine;

    public UnityEvent TargetCallBackEvent
    {
        get
        {
            return targetCallBackEvent;
        }
    }
    public UnityEvent RecoverCallBackEvent
    {
        get
        {
            return recoverCallBackEvent;
        }
    }

    public void MoveToTarget()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = MoveCoroutine(moveObject.transform.localPosition, targetPosition, targetDuration);
        StartCoroutine(moveCoroutine);
    }
    public void MoveToRecover()
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = MoveCoroutine(moveObject.transform.localPosition, organialPosition, recoverDuration);
        StartCoroutine(moveCoroutine);
    }

    IEnumerator MoveCoroutine(Vector3 from, Vector3 to, float duration)
    {
        float passTime = 0.0f;
        while (true)
        {
            moveObject.transform.localPosition = Vector3.Lerp(from, to, passTime / duration);
            passTime += Time.deltaTime;
            if (passTime >= duration)
            {
                break;
            }
            yield return null;
        }
        moveObject.transform.localPosition = to;
        if (Vector3.Distance(to, targetPosition) < Setting.MiniDistance)
        {
            targetCallBackEvent?.Invoke();
        }
        else
        {
            recoverCallBackEvent?.Invoke();
        }
    }
}
