using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class RotateObject : MonoBehaviour
{
    [Header("SHOOT OBJECT ROTATE SPEED INFORMATION")]
    [SerializeField] float rotateSpeed;

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        gameObject.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
    }
}
