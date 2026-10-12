using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScaleObject : MonoBehaviour
{
    [Header("SCALE OBJECT INFORMATION")]
    [SerializeField] GameObject scaleObject;
    [SerializeField] float targetDuration;
    [SerializeField] float recoverDuration;
    [SerializeField] Vector3 organialScale;
    [SerializeField] Vector3 targetScale;

    [Header("SCALE TARGET OVER CALL BACK")]
    [SerializeField] UnityEvent targetCallBackEvent;

    [Header("SCALE RECOVER OVER CALL BACK")]
    [SerializeField] UnityEvent recoverCallBackEvent;

    IEnumerator scaleCoroutine;

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

    public void ScaleToTarget()
    {
        if(scaleCoroutine != null)
        {
            StopCoroutine(scaleCoroutine);
        }
        scaleCoroutine = ScaleCoroutine(scaleObject.transform.localScale, targetScale, targetDuration);
        StartCoroutine(scaleCoroutine);
    }
    public void ScaleToRecover()
    {
        if(scaleCoroutine != null)
        {
            StopCoroutine(scaleCoroutine);
        }
        scaleCoroutine = ScaleCoroutine(scaleObject.transform.localScale, organialScale, recoverDuration);
        StartCoroutine(scaleCoroutine);
    }

    IEnumerator ScaleCoroutine(Vector3 form,Vector3 to,float duration)
    {
        float passTime = 0;
        while(true)
        {
            scaleObject.transform.localScale = Vector3.Lerp(form, to, passTime / duration);
            passTime += Time.deltaTime;
            if (passTime >= duration)
            {
                break;
            }
            yield return null;
        }
        scaleObject.transform.localScale = to;
        if(Vector3.Distance(to, targetScale) < Setting.MiniDistance)
        {
            targetCallBackEvent?.Invoke();
        }
        else
        {
            recoverCallBackEvent?.Invoke();
        }
    }
}
