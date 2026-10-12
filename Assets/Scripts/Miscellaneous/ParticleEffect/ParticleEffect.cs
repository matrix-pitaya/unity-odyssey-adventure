using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ParticleEffectType
{
    Smoke,
    Star,
    Heart,
    Flash
}

[RequireComponent(typeof(ParticleSystem))]
[DisallowMultipleComponent]
public class ParticleEffect : MonoBehaviour
{
    [Header("PARTICLE EFFECT TYPE")]
    [SerializeField] ParticleEffectType particleEffectType;

    ParticleSystem _particleSystem;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        StartCoroutine(DurationCoroutine());
    }

    void LoadComponent()
    {
        _particleSystem = gameObject.GetComponent<ParticleSystem>();
    }

    IEnumerator DurationCoroutine()
    {
        yield return new WaitForSeconds(_particleSystem.duration);
        switch(particleEffectType)
        {
            case ParticleEffectType.Smoke:
                ObjectPoolManager.Instance.ReleaseSmokeEffectGO(gameObject);
                break;

            case ParticleEffectType.Star:
                ObjectPoolManager.Instance.ReleaseStarEffectGo(gameObject);
                break;

            case ParticleEffectType.Heart:
                ObjectPoolManager.Instance.ReleaseHeartEffectGO(gameObject);
                break;

            case ParticleEffectType.Flash:
                ObjectPoolManager.Instance.ReleaseFlashEffectGO(gameObject);
                break;
        }
    }
}
