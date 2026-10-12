using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Slime))]
[DisallowMultipleComponent]
public class SlimeDeadAction : MonoBehaviour
{
    Slime slime;
    const float deadContinueTime = 5.0f;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        slime.DeadEvent.OnDead += DeadEvent_OnDead;
    }
    void OnDisable()
    {
        slime.DeadEvent.OnDead -= DeadEvent_OnDead;
    }

    void LoadComponent()
    {
        slime = gameObject.GetComponent<Slime>();
    }
    void DeadEvent_OnDead(DeadEvent deadEvent)
    {
        SlimeDead();
    }
    void SlimeDead()
    {
        StartCoroutine(SlimeDeadCoroutine());
        slime.SphereCollider.enabled = false;
        slime.Rigidbody.isKinematic = true;
        slime.CheckPlayer.SphereCollider.enabled = false;
        slime.IsCheckPlayer = false;
        slime.AttackPlayer.BoxCollider.enabled = false;
        AudioManager.Instance.PlayAudio(slime.AudioSource.clip);
    }
    void CreateSmokeEffect()
    {
        GameObject smokeGO = ObjectPoolManager.Instance.GetSmokeEffectGO();
        smokeGO.transform.position = gameObject.transform.position;
    }

    IEnumerator SlimeDeadCoroutine()
    {
        yield return new WaitForSeconds(deadContinueTime);
        CreateSmokeEffect();
        Destroy(slime.gameObject);
    }
}
