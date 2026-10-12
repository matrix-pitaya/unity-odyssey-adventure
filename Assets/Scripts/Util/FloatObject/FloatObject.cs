using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatObject : MonoBehaviour
{
    [Header("FLOAT INFORMATION")]
    [SerializeField] float speed;
    [SerializeField] float radius;

    void LateUpdate()
    {
        Folat();
    }

    void Folat()
    {
        float offsetSpeed = Mathf.Sin(Time.time * speed) * radius;
        gameObject.transform.position += Vector3.up * offsetSpeed * Time.deltaTime;
    }
}
