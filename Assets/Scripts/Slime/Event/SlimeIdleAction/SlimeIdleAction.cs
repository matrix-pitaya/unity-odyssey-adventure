using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Slime))]
[DisallowMultipleComponent]
public class SlimeIdleAction : MonoBehaviour
{
    Slime slime;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        slime.IdleEvent.OnIdle += IdleEvent_OnIdle;
    }
    void OnDisable()
    {
        slime.IdleEvent.OnIdle -= IdleEvent_OnIdle;
    }

    void LoadComponent()
    {
        slime = gameObject.GetComponent<Slime>();
    }
    void IdleEvent_OnIdle(IdleEvent idleEvent, IdleEventArgs idleEventArgs)
    {
        IdleRigidbody();
    }
    void IdleRigidbody()
    {
        slime.LateralVelocity = Vector3.zero;
        slime.Rigidbody.velocity = Vector3.zero;
    }

    public void StartIdleCoroutine()
    {
        StartCoroutine(IdleCoroutine(Random.Range(slime.SlimeDetails.IdleMinTime, slime.SlimeDetails.IdleMaxTime)));
    }

    IEnumerator IdleCoroutine(float duration)
    {
        slime.IsIdle = true;
        yield return new WaitForSeconds(duration);
        slime.IsIdle = false;
    }
}
