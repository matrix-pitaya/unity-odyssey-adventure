using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAudioClipType
{
    Spin,
    Jump,
    Hurt,
    Attack,
    Lift,
    Maneuver,
    Stomp,
    Throw,
    PickUp,
    AirDive,
    Dash,
    StatrRailFrabbing,
    RailGrind,
    Move,
    Glider
}

public class PlayerAudio : MonoBehaviour
{
    [Header("SPIN INFORMATION")]
    [SerializeField] AudioClip[] spin;

    [Header("JUMP AUDIO INFORMATION")]
    [SerializeField] AudioClip[] jump;

    [Header("HURT AUDIO INFORMATION")]
    [SerializeField] AudioClip[] hurt;

    [Header("ATTACK AUDIO INFORMATION")]
    [SerializeField] AudioClip[] attack;

    [Header("LIFT AUDIO INFORMATION")]
    [SerializeField] AudioClip[] lift;

    [Header("MANEUVER AUDIO INFORMATION")]
    [SerializeField] AudioClip[] maneuver;

    [Header("MANEUVER AUDIO INFORMATION")]
    [SerializeField] AudioClip[] move;

    [Header("STOM AUDIO INFORMATION")]
    [SerializeField] AudioClip stomp;

    [Header("THROW AUDIO INFORMATION")]
    [SerializeField] AudioClip _throw;

    [Header("PICK UP AUDIO INFORMATION")]
    [SerializeField] AudioClip pickUp;

    [Header("AIRDIVE AUDIO INFORMATION")]
    [SerializeField] AudioClip airDive;

    [Header("DASH AUDIO INFORMATION")]
    [SerializeField] AudioClip dash;

    [Header("START RAIL FRABBING AUDIO INFORMATION")]
    [SerializeField] AudioClip statrRailFrabbing;

    [Header("RAIL GRIND AUDIO INFORMATION")]
    [SerializeField] AudioClip railGrind;

    [Header("OPEN GLIDER AUDIO INFORMATION")]
    [SerializeField] AudioClip glider;

    AudioSource audioSource;
    Player player;
    bool isOnGress;
    bool isOnWood;
    bool isOnMetal;

    public bool IsOnGress
    {
        get
        {
            return isOnGress;
        }
        set
        {
            isOnGress = value;
        }
    }
    public bool IsOnWood
    {
        get
        {
            return isOnWood;
        }
        set
        {
            isOnWood = value;
        }
    }
    public bool IsOnMetal
    {
        get
        {
            return isOnMetal;
        }
        set
        {
            isOnMetal = value;
        }
    }

    void Awake()
    {
        LoadComponent();
    }

    void LoadComponent()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        player = gameObject.GetComponentInParent<Player>();
    }
    void HandleMoveAudio()
    {
        if(!audioSource.isPlaying)
        {
            if(isOnGress)
            {
                audioSource.clip = player.LateralVelocity.magnitude >= 8.0f ? move[Random.Range(3, 5)] : move[Random.Range(4, 6)];
            }
            else if(isOnWood)
            {
                audioSource.clip = player.LateralVelocity.magnitude >= 8.0f ? move[Random.Range(9, 11)] : move[Random.Range(10, 12)];
            }
            else if (isOnMetal)
            {
                audioSource.clip = player.LateralVelocity.magnitude >= 8.0f ? move[Random.Range(6, 8)] : move[Random.Range(7, 9)];
            }
            else
            {
                audioSource.clip = player.LateralVelocity.magnitude >= 8.0f ? move[Random.Range(0, 2)] : move[Random.Range(1, 3)];
            }
            audioSource.Play();
        }
    }

    public void PlayAudio(PlayerAudioClipType audioClipType)
    {
        switch(audioClipType)
        {
            case PlayerAudioClipType.Spin:
                audioSource.clip = spin[Random.Range(0, spin.Length)];
                break;

            case PlayerAudioClipType.Jump:
                audioSource.clip = jump[Random.Range(0, jump.Length)];
                break;

            case PlayerAudioClipType.Hurt:
                audioSource.clip = hurt[Random.Range(0, hurt.Length)];
                break;

            case PlayerAudioClipType.Attack:
                audioSource.clip = attack[Random.Range(0, attack.Length)];
                break;

            case PlayerAudioClipType.Lift:
                audioSource.clip = lift[Random.Range(0, lift.Length)];
                break;

            case PlayerAudioClipType.Maneuver:
                audioSource.clip = maneuver[Random.Range(0, maneuver.Length)];
                break;

            case PlayerAudioClipType.Move:
                HandleMoveAudio();
                return;

            case PlayerAudioClipType.Stomp:
                audioSource.clip = stomp;
                break;

            case PlayerAudioClipType.Throw:
                audioSource.clip = _throw;
                break;

            case PlayerAudioClipType.PickUp:
                audioSource.clip = pickUp;
                break;

            case PlayerAudioClipType.AirDive:
                audioSource.clip = airDive;
                break;

            case PlayerAudioClipType.Dash:
                audioSource.clip = dash;
                break;

            case PlayerAudioClipType.StatrRailFrabbing:
                audioSource.clip = statrRailFrabbing;
                break;

            case PlayerAudioClipType.RailGrind:
                audioSource.clip = railGrind;
                break;

            case PlayerAudioClipType.Glider:
                audioSource.clip = glider;
                break;
        }
        audioSource.Play();
    }
    public void StopAudio()
    {
        audioSource.clip = null;
        audioSource.Stop();
    }
}
