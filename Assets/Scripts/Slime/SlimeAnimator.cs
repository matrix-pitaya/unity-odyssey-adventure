using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Slime))]
[DisallowMultipleComponent]
public class SlimeAnimator : MonoBehaviour
{
    Slime slime;
    Animator animator;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        slime.MovementEvent.OnMovement += MovementEvent_OnMovement;
        slime.IdleEvent.OnIdle += IdleEvent_OnIdle;
        slime.DeadEvent.OnDead += DeadEvent_OnDead;
    }
    void OnDisable()
    {
        slime.MovementEvent.OnMovement -= MovementEvent_OnMovement;
        slime.IdleEvent.OnIdle -= IdleEvent_OnIdle;
        slime.DeadEvent.OnDead -= DeadEvent_OnDead;
    }

    void LoadComponent()
    {
        slime = gameObject.GetComponent<Slime>();
        animator = gameObject.GetComponentInChildren<Animator>();
    }
    void MovementEvent_OnMovement(MovementEvent movementEvent, MovementEventArgs movementEventArgs)
    {
        PlayMoveAnimation();
    }
    void IdleEvent_OnIdle(IdleEvent idleEvent, IdleEventArgs idleEventArgs)
    {
        PlayIdleAnimation();
    }
    void DeadEvent_OnDead(DeadEvent deadEvent)
    {
        PlayDeadAnimation();
    }
    void PlayMoveAnimation()
    {
        animator.SetInteger(Setting.State, 1);
    }
    void PlayIdleAnimation()
    {
        animator.SetInteger(Setting.State, 0);
    }
    void PlayDeadAnimation()
    {
        animator.SetInteger(Setting.State, 2);
    }
}
