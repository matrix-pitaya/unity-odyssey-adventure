using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerDashAction : MonoBehaviour
{
    Player player;
    IEnumerator dashCoroutine;
    bool isDash;
    bool canDash = true;

    public bool IsDash
    {
        get
        {
            return isDash;
        }
    }
    public bool CanDash
    {
        get
        {
            return canDash;
        }
    }

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.DashEvent.OnDash += DashEvent_OnDash;
    }
    void OnDisable()
    {
        player.PlayerEvents.DashEvent.OnDash -= DashEvent_OnDash;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void DashEvent_OnDash(DashEvent dashEvent, DashEventArgs dashEventArgs)
    {
        StartDashCoroutine(dashEventArgs.speed, dashEventArgs.duration, dashEventArgs.dashCD);
    }
    void StartDashCoroutine(float speed, float duration, float dashCD)
    {
        if (dashCoroutine != null)
        {
            StopCoroutine(dashCoroutine);
        }
        dashCoroutine = DashCoroutine(speed, duration, dashCD);
        StartCoroutine(dashCoroutine);
    }

    IEnumerator DashCoroutine(float speed, float duration, float dashCD)
    {
        isDash = true;
        canDash = false;
        player.IsInvincible = true;
        player.SkinTransform.localRotation = Quaternion.identity;
        player.LateralVelocity = player.gameObject.transform.forward * speed;
        player.Rigidbody.velocity = player.LateralVelocity;
        player.EnableGravity = false;
        yield return new WaitForSeconds(duration);
        player.IsInvincible = false;
        isDash = false;
        yield return new WaitForSeconds(dashCD);
        canDash = true;
    }
}
