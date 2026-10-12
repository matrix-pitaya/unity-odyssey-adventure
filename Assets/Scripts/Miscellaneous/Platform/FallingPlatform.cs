using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[DisallowMultipleComponent]
public class FallingPlatform : MonoBehaviour
{
    [Header("FAILLING PLATFORM SKIL TRANSFORM")]
    [SerializeField] Transform skilTransform;

    BoxCollider boxCollider;
    const float stabilityDuration = 1.25f;
    const float shakeDuration = 2.0f;
    const float shakeSpeed = 85f;
    const float shakeRadius = 0.1f;
    const float dropDuration = 0.3f;
    const float positionOffset = 30.0f;
    const float resumeDuration = 5.0f;
    bool isFall;

    void Awake()
    {
        LoadComponent();
    }
    void LoadComponent()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(!isFall && collision.gameObject.CompareTag(Setting.Player))
        {
            isFall = true;
            StartCoroutine(FallCoroutine());
        }
    }

    IEnumerator FallCoroutine()
    {
        yield return new WaitForSeconds(stabilityDuration);
        float passTime = 0.0f;
        while (true)
        {
            skilTransform.gameObject.transform.localPosition = (Mathf.Sin(Time.time * shakeSpeed) * shakeRadius) * Vector3.up;
            passTime += Time.deltaTime;
            if(passTime >= shakeDuration)
            {
                break;
            }
            yield return null;
        }
        skilTransform.gameObject.transform.localPosition = Vector3.zero;
        passTime = 0.0f;
        Vector3 organialPosition = gameObject.transform.position;
        Vector3 targetPosition = organialPosition + Vector3.down * positionOffset;
        boxCollider.enabled = false;
        while (true)
        {
            gameObject.transform.position = Vector3.Lerp(organialPosition, targetPosition, passTime / dropDuration);
            passTime += Time.deltaTime;
            if (passTime >= dropDuration)
            {
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(resumeDuration);
        gameObject.transform.position = organialPosition;
        boxCollider.enabled = true;
        isFall = false;
    }
}
