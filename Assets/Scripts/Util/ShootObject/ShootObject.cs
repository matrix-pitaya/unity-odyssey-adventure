using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[DisallowMultipleComponent]
public class ShootObject : MonoBehaviour
{
    [Header("SHOOT OBJECT SPEED INFORMATION")]
    [SerializeField] float maxVerticalForce;
    [SerializeField] float minVerticalForce;
    [SerializeField] float maxHorizontalSpeed;
    [SerializeField] float minHorizontalSpeed;

    [Header("SHOOT OBJECT GRAVITY INFORMATION")]
    [SerializeField] float gravity;

    Rigidbody _rigidbody;

    void Awake()
    {
        LoadComponent();
    }
    void Update()
    {
        Gravity();
    }

    void LoadComponent()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    void Gravity()
    {
        _rigidbody.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }

    public void Shoot()
    {
        this.enabled = true;
        _rigidbody.velocity = new Vector3(Random.Range(minHorizontalSpeed, maxHorizontalSpeed),
            Random.Range(minVerticalForce, maxVerticalForce), Random.Range(minHorizontalSpeed, maxHorizontalSpeed));
    }
}
