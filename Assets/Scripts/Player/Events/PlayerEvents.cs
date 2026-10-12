using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region REQUIRE_COMPONENT
[RequireComponent(typeof(PlayerIdleAction))]
[RequireComponent(typeof(IdleEvent))]
[RequireComponent(typeof(PlayerMovementAction))]
[RequireComponent(typeof(MovementEvent))]
[RequireComponent(typeof(PlayerBreakAction))]
[RequireComponent(typeof(BreakEvent))]
[RequireComponent(typeof(PlayerAirAction))]
[RequireComponent(typeof(AirEvent))]
[RequireComponent(typeof(PlayerJumpMomentAction))]
[RequireComponent(typeof(JumpMomentEvent))]
[RequireComponent(typeof(PlayerHurtAction))]
[RequireComponent(typeof(HurtEvent))]
[RequireComponent(typeof(PlayerDeadAction))]
[RequireComponent(typeof(DeadEvent))]
[RequireComponent(typeof(PlayerSpinAction))]
[RequireComponent(typeof(SpinEvent))]
[RequireComponent(typeof(PlayerStompAction))]
[RequireComponent(typeof(StompEvent))]
[RequireComponent(typeof(PlayerHangAction))]
[RequireComponent(typeof(HangEvent))]
[RequireComponent(typeof(PlayerHangClimbAction))]
[RequireComponent(typeof(HangClimbEvent))]
[RequireComponent(typeof(PlayerAirStompAction))]
[RequireComponent(typeof(AirStompEvent))]
[RequireComponent(typeof(PlayerRailGrindAction))]
[RequireComponent(typeof(RailGrindEvent))]
[RequireComponent(typeof(PlayerSwimAction))]
[RequireComponent(typeof(SwimEvent))]
[RequireComponent(typeof(PlayerBackFlipAction))]
[RequireComponent(typeof(BackFlipEvent))]
[RequireComponent(typeof(PlayerSquatAction))]
[RequireComponent(typeof(SquatEvent))]
[RequireComponent(typeof(PlayerCrawAction))]
[RequireComponent(typeof(CrawEvent))]
[RequireComponent(typeof(PlayerAirDiveAction))]
[RequireComponent(typeof(AirDiveEvent))]
[RequireComponent(typeof(PlayerGliderAction))]
[RequireComponent(typeof(GliderEvent))]
[RequireComponent(typeof(PlayerDashAction))]
[RequireComponent(typeof(DashEvent))]
[RequireComponent(typeof(PlayerWallSliderAction))]
[RequireComponent(typeof(WallSliderEvent))]
[RequireComponent(typeof(PlayerWallJumpAction))]
[RequireComponent(typeof(WallJumpEvent))]
[RequireComponent(typeof(PlayerClimbPoleAction))]
[RequireComponent(typeof(ClimbPoleEvent))]
[DisallowMultipleComponent]
#endregion
public class PlayerEvents : MonoBehaviour
{
    IdleEvent idleEvent;
    MovementEvent movementEvent;
    AirEvent airEvent;
    JumpMomentEvent jumpMomentEvent;
    BreakEvent breakEvent;
    HurtEvent hurtEvent;
    DeadEvent deadEvent;
    SpinEvent spinEvent;
    StompEvent stompEvent;
    AirStompEvent airStompEvent;
    HangEvent hangEvent;
    PlayerSpinAction spinAction;
    PlayerStompAction stompAction;
    HangClimbEvent hangClimbEvent;
    RailGrindEvent railGrindEvent;
    SwimEvent swimEvent;
    BackFlipEvent backFlipEvent;
    PlayerBackFlipAction backFlipAction;
    PlayerHangClimbAction hangClimbAction;
    SquatEvent squatEvent;
    CrawEvent crawEvent;
    AirDiveEvent airDiveEvent;
    PlayerAirDiveAction airDiveAction;
    PlayerGliderAction gliderAction;
    GliderEvent gliderEvent;
    DashEvent dashEvent;
    PlayerDashAction dashAction;
    WallSliderEvent wallSliderEvent;
    WallJumpEvent wallJumpEvent;
    ClimbPoleEvent climbPoleEvent;
    PlayerClimbPoleAction climbPoleAction;

    public IdleEvent IdleEvent
    {
        get
        {
            return idleEvent;
        }
    }
    public MovementEvent MovementEvent
    {
        get
        {
            return movementEvent;
        }
    }
    public AirEvent AirEvent
    {
        get
        {
            return airEvent;
        }
    }
    public JumpMomentEvent JumpMomentEvent
    {
        get
        {
            return jumpMomentEvent;
        }
    }
    public BreakEvent BreakEvent
    {
        get
        {
            return breakEvent;
        }
    }
    public HurtEvent HurtEvent
    {
        get
        {
            return hurtEvent;
        }
    }
    public DeadEvent DeadEvent
    {
        get
        {
            return deadEvent;
        }
    }
    public SpinEvent SpinEvent
    {
        get
        {
            return spinEvent;
        }
    }
    public PlayerSpinAction SpinAction
    {
        get
        {
            return spinAction;
        }
    }
    public StompEvent StompEvent
    {
        get
        {
            return stompEvent;
        }
    }
    public AirStompEvent AirStompEvent
    {
        get
        {
            return airStompEvent;
        }
    }
    public PlayerStompAction StompAction
    {
        get
        {
            return stompAction;
        }
    }
    public HangEvent HangEvent
    {
        get
        {
            return hangEvent;
        }
    }
    public HangClimbEvent HangClimbEvent
    {
        get
        {
            return hangClimbEvent;
        }
    }
    public RailGrindEvent RailGrindEvent
    {
        get
        {
            return railGrindEvent;
        }
    }
    public SwimEvent SwimEvent
    {
        get
        {
            return swimEvent;
        }
    }
    public BackFlipEvent BackFlipEvent
    {
        get
        {
            return backFlipEvent;
        }
    }
    public PlayerBackFlipAction BackFlipAction
    {
        get
        {
            return backFlipAction;
        }
    }
    public PlayerHangClimbAction HangClimbAction
    {
        get
        {
            return hangClimbAction;
        }
    }
    public SquatEvent SquatEvent
    {
        get
        {
            return squatEvent;
        }
    }
    public CrawEvent CrawEvent
    {
        get
        {
            return crawEvent;
        }
    }
    public AirDiveEvent AirDiveEvent
    {
        get
        {
            return airDiveEvent;
        }
    }
    public PlayerAirDiveAction AirDiveAction
    {
        get
        {
            return airDiveAction;
        }
    }
    public GliderEvent GliderEvent
    {
        get
        {
            return gliderEvent;
        }
    }
    public PlayerGliderAction GliderAction
    {
        get
        {
            return gliderAction;
        }
    }
    public DashEvent DashEvent
    {
        get
        {
            return dashEvent;
        }
    }
    public PlayerDashAction DashAction
    {
        get
        {
            return dashAction;
        }
    }
    public WallSliderEvent WallSliderEvent
    {
        get
        {
            return wallSliderEvent;
        }
    }
    public WallJumpEvent WallJumpEvent
    {
        get
        {
            return wallJumpEvent;
        }
    }
    public ClimbPoleEvent ClimbPoleEvent
    {
        get
        {
            return climbPoleEvent;
        }
    }
    public PlayerClimbPoleAction ClimbPoleAction
    {
        get
        {
            return climbPoleAction;
        }
    }

    void Awake()
    {
        LoadComponent();
    }
    void LoadComponent()
    {
        idleEvent = gameObject.GetComponent<IdleEvent>();
        movementEvent = gameObject.GetComponent<MovementEvent>();
        airEvent = gameObject.GetComponent<AirEvent>();
        jumpMomentEvent = gameObject.GetComponent<JumpMomentEvent>();
        breakEvent = gameObject.GetComponent<BreakEvent>();
        hurtEvent = gameObject.GetComponent<HurtEvent>();
        deadEvent = gameObject.GetComponent<DeadEvent>();
        spinEvent = gameObject.GetComponent<SpinEvent>();
        spinAction = gameObject.GetComponent<PlayerSpinAction>();
        stompEvent = gameObject.GetComponent<StompEvent>();
        stompAction = gameObject.GetComponent<PlayerStompAction>();
        hangEvent = gameObject.GetComponent<HangEvent>();
        hangClimbEvent = gameObject.GetComponent<HangClimbEvent>();
        airStompEvent = gameObject.GetComponent<AirStompEvent>();
        railGrindEvent = gameObject.GetComponent<RailGrindEvent>();
        swimEvent = gameObject.GetComponent<SwimEvent>();
        backFlipEvent = gameObject.GetComponent<BackFlipEvent>();
        backFlipAction = gameObject.GetComponent<PlayerBackFlipAction>();
        hangClimbAction = gameObject.GetComponent<PlayerHangClimbAction>();
        squatEvent = gameObject.GetComponent<SquatEvent>();
        crawEvent = gameObject.GetComponent<CrawEvent>();
        airDiveEvent = gameObject.GetComponent<AirDiveEvent>();
        airDiveAction = gameObject.GetComponent<PlayerAirDiveAction>();
        gliderAction = gameObject.GetComponent<PlayerGliderAction>();
        gliderEvent = gameObject.GetComponent<GliderEvent>();
        dashEvent = gameObject.GetComponent<DashEvent>();
        dashAction = gameObject.GetComponent<PlayerDashAction>();
        wallSliderEvent = gameObject.GetComponent<WallSliderEvent>();
        wallJumpEvent = gameObject.GetComponent<WallJumpEvent>();
        climbPoleEvent = gameObject.GetComponent<ClimbPoleEvent>();
        climbPoleAction = gameObject.GetComponent<PlayerClimbPoleAction>();
    }
}
