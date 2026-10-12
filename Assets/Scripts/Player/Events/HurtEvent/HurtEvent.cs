using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DisallowMultipleComponent]
public class HurtEvent : MonoBehaviour
{
    public event Action<HurtEvent, HurtEventArgs> OnHurt;

    public void CallHurtEvent(int damage,float invincibleTime, float hurtTime, Vector3 origanl, Vector2 hurtForce)
    {
        OnHurt?.Invoke(this, new HurtEventArgs(){damage = damage, invincibleTime = invincibleTime, hurtTime = hurtTime,
            origanl = origanl, hurtForce = hurtForce});
    }
}

public class HurtEventArgs : EventArgs
{
    public int damage;
    public float invincibleTime;
    public float hurtTime;
    public Vector3 origanl;
    public Vector2 hurtForce;
}
