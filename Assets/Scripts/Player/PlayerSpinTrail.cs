using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
[DisallowMultipleComponent]
public class PlayerSpinTrail : MonoBehaviour
{
    [Header("PLAYER HANDE TRANSFORM")]
    [SerializeField] Transform handTranfrom;

    TrailRenderer trailRenderer;

    void Awake()
    {
        LoadComponent();
        InitTrailRender();
    }

    void LoadComponent()
    {
        trailRenderer = gameObject.GetComponent<TrailRenderer>();
    }
    void InitTrailRender()
    {
        gameObject.transform.parent = handTranfrom;
        gameObject.transform.localPosition = Vector3.zero;
    }

    public void EnableSpinTrail(bool value)
    {
        trailRenderer.enabled = value;
    }
}
