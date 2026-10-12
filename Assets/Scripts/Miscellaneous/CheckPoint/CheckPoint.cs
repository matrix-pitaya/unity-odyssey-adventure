using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class CheckPoint : MonoBehaviour
{
    [Header("CHECK POINT SPAWN TRANSFORM")]
    [SerializeField] Transform spawnPointTransform;

    [Header("CHECK POINT FLAG TRANSFORM")]
    [SerializeField] GameObject flag;

    SphereCollider sphereCollider;
    AudioSource audioSource;

    void Awake()
    {
        LoadComponent();
    }

    void LoadComponent()
    {
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        audioSource = gameObject.GetComponentInChildren<AudioSource>();
    }
    void ActiveCheckPoint()
    {
        sphereCollider.enabled = false;
        flag.SetActive(true);
        GameManager.Instance.SpawnPoint = spawnPointTransform;
        audioSource.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(Setting.Player))
        {
            ActiveCheckPoint();
        }
    }
}
