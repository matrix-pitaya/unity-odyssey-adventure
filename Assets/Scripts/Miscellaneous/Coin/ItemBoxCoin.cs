using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ItemBoxCoin : MonoBehaviour
{
    [Header("COIN PERSISTENT TIME")]
    [SerializeField] float coinPersistentTime;

    [Header("COIN UP FORCE")]
    [SerializeField] float coinUpForce;

    [Header("COIN ROTATE SPEED")]
    [SerializeField] float coinRotateSpeed;

    Rigidbody _rigidbody;
    ParticleSystem _particleSystem;
    AudioSource audioSource;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        StartCoroutine(CoinOnEnableCoroutine());
    }

    void LoadComponent()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _particleSystem = gameObject.GetComponentInChildren<ParticleSystem>();
        audioSource = gameObject.GetComponentInChildren<AudioSource>();
    }

    IEnumerator CoinOnEnableCoroutine()
    {
        audioSource.Play();
        _particleSystem.Play();
        _rigidbody.useGravity = true;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(Vector3.up * coinUpForce, ForceMode.Impulse);
        while (true)
        {
            if(_rigidbody.velocity.y < 0)
            {
                _rigidbody.useGravity = false;
                break;
            }
            yield return null;
        }
        yield return new WaitForSeconds(coinPersistentTime);
        ObjectPoolManager.Instance.ReleaseItemBoxCoinGO(gameObject);
    }
}
