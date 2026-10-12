using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region REQUIRE_COMPONENT
[RequireComponent(typeof(SlimeAnimator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(IdleEvent))]
[RequireComponent(typeof(MovementEvent))]
[RequireComponent(typeof(DeadEvent))]
[RequireComponent(typeof(SlimeIdleAction))]
[RequireComponent(typeof(SlimeMovementAction))]
[RequireComponent(typeof(SlimeDeadAction))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(PathControl))]
[DisallowMultipleComponent]
#endregion
public class Slime : MonoBehaviour
{
    [Header("SLIME DETAILS")]
    [SerializeField] SlimeDetailsSO slimeDetails;

    StateMachine stateMachine;
    Health health;
    IdleEvent idleEvent;
    MovementEvent movementEvent;
    DeadEvent deadEvent;
    SlimeIdleAction idleAction;
    Rigidbody _rigidbody;
    SphereCollider sphereCollider;
    CheckPlayer checkPlayer;
    AttackPlayer attackPlayer;
    AudioSource audioSource;
    PathControl pathPatrolObject;
    Vector3 lateralVelocity;
    bool isIdle;
    bool isMove;
    bool isDead;
    bool isCheckPlayer;

    public Health Health
    {
        get
        {
            return health;
        }
    }
    public SlimeDetailsSO SlimeDetails
    {
        get
        {
            return slimeDetails;
        }
    }
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
    public DeadEvent DeadEvent
    {
        get
        {
            return deadEvent;
        }
    }
    public SlimeIdleAction IdleAction
    {
        get
        {
            return idleAction;
        }
    }
    public Rigidbody Rigidbody
    {
        get
        {
            return _rigidbody;
        }
    }
    public SphereCollider SphereCollider
    {
        get
        {
            return sphereCollider;
        }
    }
    public CheckPlayer CheckPlayer
    {
        get
        {
            return checkPlayer;
        }
    }
    public AttackPlayer AttackPlayer
    {
        get
        {
            return attackPlayer;
        }
    }
    public AudioSource AudioSource
    {
        get
        {
            return audioSource;
        }
    }
    public PathControl PathPatrolObject
    {
        get
        {
            return pathPatrolObject;
        }
    }
    public Vector3 TargetDirection
    {
        get
        {
            Vector3 targetDirection = ((isCheckPlayer && attackPlayer.CanAttack) ? checkPlayer.PlayerTransform.position : pathPatrolObject.TargetPosition) - gameObject.transform.position;
            if(targetDirection.y != 0)
            {
                targetDirection.y = 0;
            }
            return targetDirection.normalized;
        }
    }
    public Vector3 TargetPosition
    {
        get
        {
            Vector3 targetPosition = (isCheckPlayer && attackPlayer.CanAttack) ? checkPlayer.PlayerTransform.position : pathPatrolObject.TargetPosition;
            if(targetPosition.y != gameObject.transform.position.y)
            {
                targetPosition.y = gameObject.transform.position.y;
            }
            return targetPosition;
        }
    }
    public Vector3 LateralVelocity
    {
        get
        {
            if(lateralVelocity.y != 0)
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
    public bool IsIdle
    {
        get
        {
            return isIdle;
        }
        set
        {
            isIdle = value;
        }
    }
    public bool IsMove
    {
        get
        {
            return isMove;
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
            isDead = true;
        }
    }
    public bool IsCheckPlayer
    {
        get
        {
            return isCheckPlayer;
        }
        set
        {
            isCheckPlayer = value;
        }
    }

    void Awake()
    {
        LoadComponent();
        InitStateMachine();
        InitHealth();
    }
    void Start()
    {
        stateMachine.SetEntry(Setting.Idle);
    }
    void Update()
    {
        stateMachine.OnUpdata();
    }

    void LoadComponent()
    {
        health = gameObject.GetComponent<Health>();
        idleEvent = gameObject.GetComponent<IdleEvent>();
        movementEvent = gameObject.GetComponent<MovementEvent>();
        deadEvent = gameObject.GetComponent<DeadEvent>();
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        idleAction = gameObject.GetComponent<SlimeIdleAction>();
        sphereCollider = gameObject.GetComponent<SphereCollider>();
        checkPlayer = gameObject.GetComponentInChildren<CheckPlayer>();
        attackPlayer = gameObject.GetComponentInChildren<AttackPlayer>();
        audioSource = gameObject.GetComponentInChildren<AudioSource>();
        pathPatrolObject = gameObject.GetComponent<PathControl>();
    }
    void InitStateMachine()
    {
        stateMachine = new StateMachine();
        stateMachine.RegisterState(Setting.Idle, new SlimeIdleState(this));
        stateMachine.RegisterState(Setting.Move, new SlimeMoveState(this));
        stateMachine.RegisterState(Setting.Dead, new SlimeDeadState(this));
    }
    void InitHealth()
    {
        health.InitialHealth(1);
    }

    public void SwitchNode(string id)
    {
        stateMachine.SwitchTo(id);
    }
}
