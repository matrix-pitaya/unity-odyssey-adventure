using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScaleObject))]
public class Sign : MonoBehaviour
{
    ScaleObject scaleObject;

    void Awake()
    {
        LoadComponent();
        Collapse();
    }

    void LoadComponent()
    {
        scaleObject = gameObject.GetComponent<ScaleObject>();
    }
    void Pop()
    {
        scaleObject.ScaleToTarget();
    }
    void Collapse()
    {
        scaleObject.ScaleToRecover();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Setting.Player))
        {
            Pop();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Setting.Player))
        {
            Collapse();
        }
    }
}
