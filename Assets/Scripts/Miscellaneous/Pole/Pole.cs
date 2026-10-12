using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class Pole : MonoBehaviour
{
    float maxHeight;
    const float offset = 1.5f;

    public float MaxHeight
    {
        get
        {
            return maxHeight;
        }
    }

    void Awake()
    {
        InitMaxHeight();
    }
    void InitMaxHeight()
    {
        maxHeight = gameObject.GetComponent<Collider>().bounds.max.y - offset;
    }
}
