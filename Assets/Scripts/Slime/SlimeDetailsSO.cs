using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SlimeDetails", menuName = "ScriptableObject/Slime/Slime Detail")]
public class SlimeDetailsSO : ScriptableObject
{
    [Header("SLIME IDLE TIME")]
    [SerializeField] float idleMaxTime;
    [SerializeField] float idleMinTime;

    [Header("SLIME ACCELERATION")]
    [SerializeField] float acceleration;

    [Header("SLIME MAX SPEED")]
    [SerializeField] float maxSpeed;

    [Header("SLIME ROATTE SPEED")]
    [SerializeField] float rotateSpeed;

    [Header("SLIME ATTACK COOL DOWN")]
    [SerializeField] float attackCD;

    public float IdleMaxTime
    {
        get
        {
            return idleMaxTime;
        }
    }
    public float IdleMinTime
    {
        get
        {
            return idleMinTime;
        }
    }
    public float Acceleration
    {
        get
        {
            return acceleration;
        }
    }
    public float MaxSpeed
    {
        get
        {
            return maxSpeed;
        }
    }
    public float RotateSpeed
    {
        get
        {
            return rotateSpeed;
        }
    }
    public float AttackCD
    {
        get
        {
            return attackCD;
        }
    }
}
