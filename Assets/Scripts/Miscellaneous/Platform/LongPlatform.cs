using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongPlatform : MonoBehaviour
{
    [Header("LONGPLATFORM INLINE DURATION")]
    [SerializeField] float duration;

    bool isIncline = false;
    const float dstAngle = 15.0f;
    IEnumerator inclineCoroutine;
    IEnumerator recoverCoroutine;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(Setting.Player))
        {
            if(!isIncline)
            {
                isIncline = true;
                if (inclineCoroutine != null)
                {
                    StopCoroutine(inclineCoroutine);
                }
                if (recoverCoroutine != null)
                {
                    StopCoroutine(recoverCoroutine);
                }
                inclineCoroutine = InclineCoroutine(gameObject.transform.InverseTransformPoint(collision.gameObject.transform.position).z > 0 ? dstAngle : -dstAngle);
                StartCoroutine(inclineCoroutine);
                Debug.Log(1);
            }
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(Setting.Player))
        {
            if(inclineCoroutine != null)
            {
                StopCoroutine(inclineCoroutine);
            }
            if(recoverCoroutine != null)
            {
                StopCoroutine(recoverCoroutine);
            }
            recoverCoroutine = InclineCoroutine(0.0f);
            StartCoroutine(recoverCoroutine);
            isIncline = false;
            Debug.Log(2);
        }
    }

    IEnumerator InclineCoroutine(float dstAngle)
    {
        float passTime = 0;
        Quaternion organialRotation = gameObject.transform.rotation;
        Quaternion dstRotation = Quaternion.Euler(dstAngle, 0.0f, 0.0f);
        while (true)
        {
            gameObject.transform.rotation = Quaternion.Lerp(organialRotation, dstRotation, passTime / duration);
            passTime += Time.deltaTime;
            if (passTime >= duration)
            {
                break;
            }
            yield return null;
        }
        gameObject.transform.rotation = dstRotation;
    }
}
