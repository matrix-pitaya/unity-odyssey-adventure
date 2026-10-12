using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

#region REQUIRE_COMPONENT
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerControl))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Health))]
[DisallowMultipleComponent]
#endregion
public class Player : MonoBehaviour
{
    [Header("PLAYER DETAIL")]
    [SerializeField] PlayerDetailSO playerDetail;

    [Header("GROUND CHECK POINT")]
    [SerializeField] Transform groundCheck;

    [Header("CLIMB CHECK POINT")]
    [SerializeField] Transform hangCheckUpTransform;
    [SerializeField] Transform hangCheckDownTransform;

    [Header("MODE TRANSFORM")]
    [SerializeField] Transform skinTransform;
    [SerializeField] Transform holdCrateTransform;
    [SerializeField] Transform leftFootTransform;
    [SerializeField] Transform rightFootTransform;

    StateMachine stateMachine;
    PlayerControl playerControl;
    PlayerAudio playerAudio;
    PlayerSpinTrail playerSpinTrail;
    PlayerAnimator playerAnimator;
    Rigidbody _rigidbody;
    Health health;
    PlayerEvents playerEvents;
    PlayerSpinHitBox spinHitBox;
    PlayerStompHitBox stompHitBox;
    PlayerHoldCheck holdCheck;
    PlayerParticle playerParticle;
    PlayerWaterCheck playerWaterCheck;
    CapsuleCollider capsuleCollider;
    SplineContainer splineContainer;
    Transform climbPoleTransform;
    Vector3 lateralVelocity;
    Vector3 verticalVelocity;
    bool isDead;
    bool isInvincible;
    bool isHurt;
    bool isHold;
    bool isStomp;
    bool isInWater;
    bool isOnBounce;
    bool enableGravity = true;
    bool enableFloatForce;
    int groundLayerMask;
    int wallLayerMask;
    int crateLayerMask;
    int railLayerMask;
    int poleLayerMask;
    float gravity;
    float floatForce;

    public PlayerControl PlayerControl
    {
        get
        {
            return playerControl;
        }
    }
    public PlayerDetailSO PlayerDetail
    {
        get
        {
            return playerDetail;
        }
    }
    public PlayerAudio PlayerAudio
    {
        get
        {
            return playerAudio;
        }
    }
    public PlayerSpinTrail SpinTrail
    {
        get
        {
            return playerSpinTrail;
        }
    }
    public PlayerAnimator PlayerAnimator
    {
        get
        {
            return playerAnimator;
        }
    }
    public Rigidbody Rigidbody
    {
        get
        {
            return _rigidbody;
        }
    }
    public Health Health
    {
        get
        {
            return health;
        }
    }
    public CapsuleCollider CapsuleCollider
    {
        get
        {
            return capsuleCollider;
        }
    }
    public Transform SkinTransform
    {
        get
        {
            return skinTransform;
        }
    }
    public Transform HoldCrateTransform
    {
        get
        {
            return holdCrateTransform;
        }
    }
    public Transform ClimbPoleTransform
    {
        get
        {
            return climbPoleTransform;
        }
    }
    public PlayerSpinHitBox SpinHitBox
    {
        get
        {
            return spinHitBox;
        }
    }
    public PlayerStompHitBox StompHitBox
    {
        get
        {
            return stompHitBox;
        }
    }
    public PlayerHoldCheck HoldCheck
    {
        get
        {
            return holdCheck;
        }
    }
    public PlayerParticle PlayerParticle
    {
        get
        {
            return playerParticle;
        }
    }
    public SplineContainer SplineContainer
    {
        get
        {
            return splineContainer;
        }
    }
    public PlayerEvents PlayerEvents
    {
        get
        {
            return playerEvents;
        }
    }
    public PlayerWaterCheck PlayerWaterCheck
    {
        get
        {
            return playerWaterCheck;
        }
    }
    public Vector3 LateralVelocity
    {
        get
        {
            if (lateralVelocity.y != 0)
            {
                lateralVelocity.y = 0;
            }
            return lateralVelocity;
        }
        set
        {
            lateralVelocity = value;
            if(lateralVelocity.y != 0)
            {
                lateralVelocity.y = 0;
            }
        }
    }
    public Vector3 VerticalVelocity
    {
        get
        {
            if(verticalVelocity.x != 0)
            {
                verticalVelocity.x = 0;
            }
            if (verticalVelocity.z != 0)
            {
                verticalVelocity.z = 0;
            }
            return verticalVelocity;
        }
        set
        {
            verticalVelocity = value;
            if (verticalVelocity.x != 0)
            {
                verticalVelocity.x = 0;
            }
            if (verticalVelocity.z != 0)
            {
                verticalVelocity.z = 0;
            }
        }
    }
    public Vector3 FootCenterPosition
    {
        get
        {
            return (leftFootTransform.position + rightFootTransform.position) / 2;
        }
    }
    public bool IsOnGround
    {
        get
        {
            return Physics.Raycast(groundCheck.position, Vector3.down, Setting.GroundCheckDistance, groundLayerMask | wallLayerMask | crateLayerMask);
        }
    }
    public bool EnableGravity
    {
        get 
        {
            return enableGravity;
        }
        set
        {
            enableGravity = value;
        }
    }
    public bool EnableFloatForce
    {
        get
        {
            return enableFloatForce;
        }
        set
        {
            enableFloatForce = value;
        }
    }
    public bool IsInvincible
    {
        get
        {
            return isInvincible;
        }
        set
        {
            isInvincible = value;
        }
    }
    public bool IsHurt
    {
        get
        {
            return isHurt;
        }
        set
        {
            isHurt = value;
        }
    }
    public bool IsDead
    {
        get
        {
            return isDead;
        }
        set
        {
            isDead = value;
        }
    }
    public bool IsHold
    {
        get
        {
            return isHold;
        }
        set
        {
            isHold = value;
        }
    }
    public bool IsStomp
    {
        get
        {
            return isStomp;
        }
        set
        {
            isStomp = value;
        }
    }
    public bool CanHang
    {
        get
        {
            return !Physics.Raycast(hangCheckUpTransform.position, gameObject.transform.forward, Setting.HangCheckDistance, wallLayerMask) &&
                Physics.Raycast(hangCheckDownTransform.position, gameObject.transform.forward, Setting.HangCheckDistance, wallLayerMask);
        }
    }
    public bool CanWallSlider
    {
        get
        {
            return Physics.Raycast(hangCheckUpTransform.position, gameObject.transform.forward, Setting.HangCheckDistance, wallLayerMask) &&
                Physics.Raycast(hangCheckDownTransform.position, gameObject.transform.forward, Setting.HangCheckDistance, wallLayerMask);
        }
    }
    public bool IsBackWall
    {
        get
        {
            return Physics.Raycast(hangCheckUpTransform.position, -gameObject.transform.forward, Setting.HangCheckDistance, wallLayerMask) &&
                Physics.Raycast(hangCheckDownTransform.position, -gameObject.transform.forward, Setting.HangCheckDistance, wallLayerMask);
        }
    }
    public bool IsRailGrid
    {
        get
        {
            Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, Setting.RailGridCheckRadius, railLayerMask);
            splineContainer = colliders.Length > 0 ? colliders[0].GetComponent<SplineContainer>() : null;
            return splineContainer != null;
        }
    }
    public bool IsClimbPole
    {
        get
        {
            Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position + Vector3.up * Setting.PoleCheckPositionOffset, 
                Setting.PoleCheckRadius, poleLayerMask);
            climbPoleTransform = colliders.Length > 0 ? colliders[0].gameObject.transform : null;
            return climbPoleTransform != null;
        }
    }
    public bool IsInWater
    {
        get
        {
            return isInWater;
        }
        set
        {
            isInWater = value;
        }
    }
    public bool IsOnBounce
    {
        get
        {
            return isOnBounce;
        }
        set
        {
            isOnBounce = value;
        }
    }
    public float FloatForce
    {
        get
        {
            return floatForce;
        }
        set
        {
            floatForce = value;
        }
    }

    void Awake()
    {
        LoadComponent();
        InitStateMachine();
        InitGravity();
        InitHealth();
        InitLayerMask();
    }
    void Start()
    {
        stateMachine.SetEntry(Setting.Idle);
    }
    void Update()
    {
        stateMachine.OnUpdata();
    }
    void FixedUpdate()
    {
        OnGravity();
        OnFloatForce();
    }

    void LoadComponent()
    {
        playerControl = gameObject.GetComponent<PlayerControl>();
        playerAnimator = gameObject.GetComponent<PlayerAnimator>();
        health = gameObject.GetComponent<Health>();
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        holdCheck = gameObject.GetComponentInChildren<PlayerHoldCheck>();
        stompHitBox = gameObject.GetComponentInChildren<PlayerStompHitBox>();
        spinHitBox = gameObject.GetComponentInChildren<PlayerSpinHitBox>();
        playerAudio = gameObject.GetComponentInChildren<PlayerAudio>();
        playerParticle = gameObject.GetComponentInChildren<PlayerParticle>();
        playerSpinTrail = gameObject.GetComponentInChildren<PlayerSpinTrail>();
        playerEvents = gameObject.GetComponentInChildren<PlayerEvents>();
        playerWaterCheck = gameObject.GetComponentInChildren<PlayerWaterCheck>();
    }
    void InitStateMachine()
    {
        stateMachine = new StateMachine();
        stateMachine.RegisterState(Setting.Idle, new PlayerIdleState(this));
        stateMachine.RegisterState(Setting.Move, new PlayerMoveState(this));
        stateMachine.RegisterState(Setting.Jump, new PlayerJumpState(this));
        stateMachine.RegisterState(Setting.Fall, new PlayerFallState(this));
        stateMachine.RegisterState(Setting.Break, new PlayerBreakState(this));
        stateMachine.RegisterState(Setting.Hurt, new PlayerHurtState(this));
        stateMachine.RegisterState(Setting.Dead, new PlayerDeadState(this));
        stateMachine.RegisterState(Setting.Spin, new PlayerSpinState(this));
        stateMachine.RegisterState(Setting.Stomp, new PlayerStompState(this));
        stateMachine.RegisterState(Setting.AirStomp, new PlayerAirStompState(this));
        stateMachine.RegisterState(Setting.Hang, new PlayerHangState(this));
        stateMachine.RegisterState(Setting.HangClimb, new PlayerHangClimeState(this));
        stateMachine.RegisterState(Setting.RailGrind, new PlayerRailGrindState(this));
        stateMachine.RegisterState(Setting.Swim, new PlayerSwimState(this));
        stateMachine.RegisterState(Setting.BackFlip, new PlayerBackFlipState(this));
        stateMachine.RegisterState(Setting.Squat, new PlayerSquatState(this));
        stateMachine.RegisterState(Setting.Craw, new PlayerCrawStateNode(this));
        stateMachine.RegisterState(Setting.AirDive, new PlayerAirDiveState(this));
        stateMachine.RegisterState(Setting.Glider, new PlayerGliderState(this));
        stateMachine.RegisterState(Setting.Dash, new PlayerDashState(this));
        stateMachine.RegisterState(Setting.WallSlider, new PlayerWallSliderState(this));
        stateMachine.RegisterState(Setting.WallJump, new PlayerWallJumpState(this));
        stateMachine.RegisterState(Setting.ClimbPole, new PlayerClimbPoleState(this));
    }
    void InitGravity()
    {
        gravity = playerDetail.NormalGravity;
    }
    void InitHealth()
    {
        health.InitialHealth(Setting.PlayerDefaulHurtNum);
    }
    void InitLayerMask()
    {
        groundLayerMask = LayerMask.GetMask(Setting.Ground);
        wallLayerMask = LayerMask.GetMask(Setting.Wall);
        crateLayerMask = LayerMask.GetMask(Setting.Crate);
        railLayerMask = LayerMask.GetMask(Setting.Rail);
        poleLayerMask = LayerMask.GetMask(Setting.Pole);
    }
    void OnGravity()
    {
        if(enableGravity)
        {
            _rigidbody.AddForce(Physics.gravity * gravity, ForceMode.Acceleration);
        }
    }
    void OnFloatForce()
    {
        if(enableFloatForce)
        {
            _rigidbody.AddForce(Vector3.up * floatForce, ForceMode.Acceleration);
        }
    }

    public void SwitchNode(string id)
    {
        stateMachine.SwitchTo(id);
    }
}
