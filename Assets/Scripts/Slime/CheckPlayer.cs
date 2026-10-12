using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class CheckPlayer : MonoBehaviour
{
    Slime slime;
    Transform playerTransform;
    SphereCollider sphereCollider;

    public Transform PlayerTransform
    {
        get
        {
            return playerTransform;
        }
    }
    public SphereCollider SphereCollider
    {
        get
        {
            return sphereCollider;
        }
    }

    void Awake()
    {
        LoadComponent();
    }

    void LoadComponent()
    {
        slime = gameObject.GetComponentInParent<Slime>();
        sphereCollider = gameObject.GetComponent<SphereCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Setting.Player))
        {
            slime.IsCheckPlayer = true;
            if (playerTransform == null)
            {
                playerTransform = other.gameObject.transform;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Setting.Player))
        {
            slime.IsCheckPlayer = false;
        }
    }
}
