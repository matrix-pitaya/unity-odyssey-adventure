using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region REQUIRE_COMPONENT
[RequireComponent(typeof(Player))]
[DisallowMultipleComponent]
#endregion
public class PlayerAnimator : MonoBehaviour
{
    Player player;
    Animator animator;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.IdleEvent.OnIdle += IdleEvent_OnIdle;
        player.PlayerEvents.MovementEvent.OnMovement += MovementEvent_OnMovement;
        player.PlayerEvents.AirEvent.OnAir += AirEvent_OnAir;
        player.PlayerEvents.BreakEvent.OnBreak += BreakEvent_OnBreak;
        player.PlayerEvents.HurtEvent.OnHurt += HurtEvent_OnHurt;
        player.PlayerEvents.DeadEvent.OnDead += DeadEvent_OnDead;
        player.PlayerEvents.SpinEvent.OnSpin += SpinEvent_OnSpin;
        player.PlayerEvents.StompEvent.OnStomp += StompEvent_OnStomp;
        player.PlayerEvents.HangEvent.OnHang += HangEvent_OnHang;
        player.PlayerEvents.HangClimbEvent.OnHangClimb += HangClimbEvent_OnHangClimb;
        player.PlayerEvents.AirStompEvent.OnAirStomp += AirStompEvent_OnAirStomp;
        player.PlayerEvents.RailGrindEvent.OnRailGrind += RailGrindEvent_OnRailGrind;
        player.PlayerEvents.SwimEvent.OnSwim += SwimEvent_OnSwim;
        player.PlayerEvents.BackFlipEvent.OnBackFlip += BackFlipEvent_OnBackFlip;
        player.PlayerEvents.SquatEvent.OnSquat += SquatEvent_OnSquat;
        player.PlayerEvents.CrawEvent.OnCraw += CrawEvent_OnCraw;
        player.PlayerEvents.AirDiveEvent.OnAirDive += AirDiveEvent_OnAirDive;
        player.PlayerEvents.GliderEvent.OnGlider += GliderEvent_OnGlider;
        player.PlayerEvents.DashEvent.OnDash += DashEvent_OnDash;
        player.PlayerEvents.WallSliderEvent.OnWallSlider += WallSliderEvent_OnWallSlider;
        player.PlayerEvents.WallJumpEvent.OnWallJump += WallJumpEvent_OnWallJump;
        player.PlayerEvents.ClimbPoleEvent.OnClimbPole += ClimbPoleEvent_OnClimbPole;
    }
    void OnDisable()
    {
        player.PlayerEvents.MovementEvent.OnMovement -= MovementEvent_OnMovement;
        player.PlayerEvents.IdleEvent.OnIdle -= IdleEvent_OnIdle;
        player.PlayerEvents.AirEvent.OnAir -= AirEvent_OnAir;
        player.PlayerEvents.BreakEvent.OnBreak -= BreakEvent_OnBreak;
        player.PlayerEvents.HurtEvent.OnHurt -= HurtEvent_OnHurt;
        player.PlayerEvents.DeadEvent.OnDead -= DeadEvent_OnDead;
        player.PlayerEvents.SpinEvent.OnSpin -= SpinEvent_OnSpin;
        player.PlayerEvents.StompEvent.OnStomp -= StompEvent_OnStomp;
        player.PlayerEvents.HangEvent.OnHang -= HangEvent_OnHang;
        player.PlayerEvents.HangClimbEvent.OnHangClimb -= HangClimbEvent_OnHangClimb;
        player.PlayerEvents.AirStompEvent.OnAirStomp -= AirStompEvent_OnAirStomp;
        player.PlayerEvents.RailGrindEvent.OnRailGrind -= RailGrindEvent_OnRailGrind;
        player.PlayerEvents.SwimEvent.OnSwim -= SwimEvent_OnSwim;
        player.PlayerEvents.BackFlipEvent.OnBackFlip -= BackFlipEvent_OnBackFlip;
        player.PlayerEvents.SquatEvent.OnSquat -= SquatEvent_OnSquat;
        player.PlayerEvents.CrawEvent.OnCraw -= CrawEvent_OnCraw;
        player.PlayerEvents.AirDiveEvent.OnAirDive -= AirDiveEvent_OnAirDive;
        player.PlayerEvents.GliderEvent.OnGlider -= GliderEvent_OnGlider;
        player.PlayerEvents.DashEvent.OnDash -= DashEvent_OnDash;
        player.PlayerEvents.WallSliderEvent.OnWallSlider -= WallSliderEvent_OnWallSlider;
        player.PlayerEvents.WallJumpEvent.OnWallJump -= WallJumpEvent_OnWallJump;
        player.PlayerEvents.ClimbPoleEvent.OnClimbPole -= ClimbPoleEvent_OnClimbPole;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponent<Player>();
        animator = gameObject.GetComponentInChildren<Animator>();
    }
    void IdleEvent_OnIdle(IdleEvent idleEvent, IdleEventArgs idleEventArgs)
    {
        PlayIdleAnimation();
    }
    void MovementEvent_OnMovement(MovementEvent movementEvent, MovementEventArgs movementEventArgs)
    {
        PlayMoveAnimation();
    }
    void AirEvent_OnAir(AirEvent jumpEvent,AirEventArgs jumpEventArgs)
    {
        PlayAirAnimation();
    }
    void BreakEvent_OnBreak(BreakEvent breakEvent,BreakEventArgs breakEventArgs)
    {
        PlayBreakAnimation();
    }
    void HurtEvent_OnHurt(HurtEvent hurtEvent,HurtEventArgs hurtEventArgs)
    {
        PlayHurtAnimation();
    }
    void DeadEvent_OnDead(DeadEvent deadEvent)
    {
        PlayDeadAnimation();
    }
    void SpinEvent_OnSpin(SpinEvent spinEvent,SpinEventArgs spinEventArgs)
    {
        PlaySpinAnimation();
    }
    void StompEvent_OnStomp(StompEvent stompEvent, StompEventArgs stompEventArgs)
    {
        PlayStompAnimation();
    }
    void HangEvent_OnHang(HangEvent climbEvent)
    {
        PlayHangAnimation();
    }
    void HangClimbEvent_OnHangClimb(HangClimbEvent hangClimbEvent)
    {
        PlayHangClimbAnimation();
    }
    void AirStompEvent_OnAirStomp(AirStompEvent airStompEvent)
    {
        PlayStompAnimation();
    }
    void RailGrindEvent_OnRailGrind(RailGrindEvent railGrindEvent ,RailGrindEventArgs railGrindEventArgs)
    {
        PlayRailGridAnimation();
    }
    void SwimEvent_OnSwim(SwimEvent swimEvent, SwimEventArgs swimEventArgs)
    {
        PlaySwimAnimation();
    }
    void BackFlipEvent_OnBackFlip(BackFlipEvent backFlipEvent, BackFlipEventArgs backFlipEventArgs)
    {
        PlayBackFlipAnimation();
    }
    void SquatEvent_OnSquat(SquatEvent squatEvent, SquatEventArgs squatEventArgs)
    {
        PlaySquatAnimation();
    }
    void CrawEvent_OnCraw(CrawEvent crawEvent, CrawEventArgs crawEventArgs)
    {
        PlayCrawAnimation();
    }
    void AirDiveEvent_OnAirDive(AirDiveEvent airDiveEvent, AirDiveEventArgs airDiveEventArgs)
    {
        PlayAirDiveAnimation();
    }
    void GliderEvent_OnGlider(GliderEvent gliderEvent, GliderEventArgs gliderEventArgs)
    {
        PlayGliderAnimation();
    }
    void DashEvent_OnDash(DashEvent dashEvent, DashEventArgs dashEventArgs)
    {
        PlayDashAnimation();
    }
    void WallSliderEvent_OnWallSlider(WallSliderEvent wallSliderEvent, WallSliderEventArgs wallSliderEventArgs)
    {
        PlayWallSliderAnimation();
    }
    void WallJumpEvent_OnWallJump(WallJumpEvent wallJumpEvent, WallJumpEventArgs wallJumpEventArgs)
    {
        PlayWallJumpAnimation();
    }
    void ClimbPoleEvent_OnClimbPole(ClimbPoleEvent climbPoleEvent, ClimbPoleEventArgs climbPoleEventArgs)
    {
        PlayClimbPoleAnimation();
    }
    void PlayIdleAnimation()
    {
        animator.SetInteger(Setting.State, 0);
        animator.SetFloat(Setting.LateralSpeed, 0);
        animator.SetFloat(Setting.VerticalSpeed, 0);
        animator.SetBool(Setting.IsHolding, player.IsHold);
    }
    void PlayMoveAnimation()
    {
        animator.SetInteger(Setting.State, 1);
        animator.SetFloat(Setting.LateralSpeed, player.LateralVelocity.magnitude);
        animator.SetBool(Setting.IsHolding, player.IsHold);
    }
    void PlayAirAnimation()
    {
        animator.SetInteger(Setting.State, 3);
        animator.SetFloat(Setting.VerticalSpeed, player.Rigidbody.velocity.y);
        animator.SetBool(Setting.IsHolding, player.IsHold);
    }
    void PlayWallJumpAnimation()
    {
        animator.SetInteger(Setting.State, 3);
        animator.SetFloat(Setting.VerticalSpeed, 1);
        animator.SetBool(Setting.IsHolding, player.IsHold);
    }
    void PlayBreakAnimation()
    {
        animator.SetInteger(Setting.State, 2);
        animator.SetBool(Setting.IsHolding, player.IsHold);
    }
    void PlayHurtAnimation()
    {
        animator.SetInteger(Setting.State, 4);
        animator.SetBool(Setting.IsHolding, false);
    }
    void PlayDeadAnimation()
    {
        animator.SetInteger(Setting.State, 5);
        animator.SetBool(Setting.IsHolding, false);
    }
    void PlaySpinAnimation()
    {
        animator.SetInteger(Setting.State, 11);
        animator.SetBool(Setting.IsHolding, false);
    }
    void PlayStompAnimation()
    {
        animator.SetInteger(Setting.State, 13);
        animator.SetBool(Setting.IsHolding, false);
    }
    void PlayHangAnimation()
    {
        animator.SetInteger(Setting.State, 14);
        animator.SetFloat(Setting.LateralSpeed, 0);
        animator.SetFloat(Setting.VerticalSpeed, 0);
        animator.SetBool(Setting.IsHolding, false);
    }
    void PlayHangClimbAnimation()
    {
        animator.SetInteger(Setting.State, 15);
        animator.SetBool(Setting.IsHolding, false);
    }
    void PlayRailGridAnimation()
    {
        animator.SetInteger(Setting.State, 19);
        animator.SetBool(Setting.IsHolding, false);
    }
    void PlaySwimAnimation()
    {
        animator.SetInteger(Setting.State, 8);
        animator.SetFloat(Setting.LateralSpeed, player.LateralVelocity.magnitude);
        animator.SetBool(Setting.IsHolding, false);
    }
    void PlayBackFlipAnimation()
    {
        animator.SetInteger(Setting.State, 16);
        animator.SetBool(Setting.IsHolding, false);
    }
    void PlaySquatAnimation()
    {
        animator.SetInteger(Setting.State, 9);
        animator.SetBool(Setting.IsHolding, false);
    }
    void PlayCrawAnimation()
    {
        animator.SetInteger(Setting.State, 10);
        animator.SetFloat(Setting.LateralSpeed, player.LateralVelocity.magnitude);
        animator.SetBool(Setting.IsHolding, false);
    }
    void PlayAirDiveAnimation()
    {
        animator.SetInteger(Setting.State, 12);
        animator.SetBool(Setting.IsHolding, false);
    }
    void PlayGliderAnimation()
    {
        animator.SetInteger(Setting.State, 17);
        animator.SetBool(Setting.IsHolding, false); 
    }
    void PlayDashAnimation()
    {
        animator.SetInteger(Setting.State, 18);
        animator.SetBool(Setting.IsHolding, false);
    }
    void PlayWallSliderAnimation()
    {
        animator.SetInteger(Setting.State, 6);
        animator.SetBool(Setting.IsHolding, false);
    }
    void PlayClimbPoleAnimation()
    {
        animator.SetInteger(Setting.State, 7);
        animator.SetFloat(Setting.VerticalSpeed, player.VerticalVelocity.y);
        animator.SetBool(Setting.IsHolding, false);
    }

    public void PlayIdleAnimationImmediate()
    {
        animator.SetInteger(Setting.State, 50);
    }
}
