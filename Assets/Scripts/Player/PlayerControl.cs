using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent]
public class PlayerControl : MonoBehaviour
{
    [Header("INPUT ACTION ASSET MAP")]
    [SerializeField] InputActionAsset inputActionAsset;
    InputAction inputMovement;
    InputAction inputRun;

    public bool IsRunning
    {
        get
        {
            return inputRun.IsPressed();
        }
    }
    public bool IsJump
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);
        }
    }
    public bool IsSpin
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Mouse0);
        }
    }
    public bool IsGlider
    {
        get
        {
            return Input.GetKey(KeyCode.Mouse1);
        }
    }
    public bool IsHoldOrThrow
    {
        get
        {
            return Input.GetKeyDown(KeyCode.G);
        }
    }
    public bool IsStomp
    {
        get
        {
            return Input.GetKeyDown(KeyCode.E);
        }
    }
    public bool IsSquat
    {
        get
        {
            return Input.GetKey(KeyCode.Q);
        }
    }
    public bool IsDash
    {
        get
        {
            return Input.GetKeyDown(KeyCode.F);
        }
    }
    public float Horizontal
    {
        get
        {
            return Input.GetAxis(Setting.Horizontal);
        }
    }
    public float VerticalRaw
    {
        get
        {
            return Input.GetAxisRaw(Setting.Vertical);
        }
    }
    public Vector3 MoveAbsoluteDirection
    {
        get
        {
            GetInputMoveDirection(inputMovement.ReadValue<Vector2>(), out Vector3 moveDirect);
            return moveDirect;
        }
    }
    public Vector3 MoveRelativeDirection
    {
        get
        {
            return GetRelativeCameraMoveDirection();
        }
    }

    void Awake()
    {
        InitInputActions();
    }
    void OnEnable()
    {
        inputActionAsset?.Enable();
    }
    void OnDisable()
    {
        inputActionAsset?.Disable();
    }
    void Update()
    {
        KeyCodeCheck();
    }

    void InitInputActions()
    {
        inputMovement = inputActionAsset.FindAction(Setting.Movement);
        inputRun = inputActionAsset.FindAction(Setting.Run);
    }
    void KeyCodeCheck()
    {
        if (!GameManager.Instance.IsGameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Instance.IsGamePause)
            {
                GameManager.Instance.OnResume();
                AudioManager.Instance.PlayUIConfirmAudioClip();
            }
            else
            {
                GameManager.Instance.OnPause();
                AudioManager.Instance.PlayUIConfirmAudioClip();
            }
        }
    }

    void GetInputMoveDirection(Vector2 axis, out Vector3 moveDirect)
    {
        moveDirect.x = axis.x;
        moveDirect.y = 0.0f;
        moveDirect.z = axis.y;
    }
    Vector3 GetRelativeCameraMoveDirection()
    {
        GetInputMoveDirection(inputMovement.ReadValue<Vector2>(),out Vector3 moveDirection);
        if(moveDirection.sqrMagnitude > 0)
        {
            moveDirection = (Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up) * moveDirection).normalized;
        }
        return moveDirection;
    }
}
