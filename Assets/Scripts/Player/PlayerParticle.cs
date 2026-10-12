using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerParticleType
{
    Dust,
    Land,
    Stars,
    Rail,
    WindTrail,
    Acceleration
}

[DisallowMultipleComponent]
public class PlayerParticle : MonoBehaviour
{
    [Header("PLAYER MOVE DUST EFFECT")]
    [SerializeField] ParticleSystem dust;

    [Header("PLAYER LAND DUST EFFECT")]
    [SerializeField] ParticleSystem land;

    [Header("PLAYER SATRTS EFFECT")]
    [SerializeField] ParticleSystem stars;

    [Header("PLAYER RAIL EFECT")]
    [SerializeField] ParticleSystem wind;

    [Header("PLAYER FRICTION EFFECT")]
    [SerializeField] ParticleSystem friction;

    [Header("PLAYER ACCELERATION EFFECT")]
    [SerializeField] ParticleSystem acceleration;

    public void PlayParticleSystem(PlayerParticleType playerParticleType)
    {
        switch (playerParticleType)
        {
            case PlayerParticleType.Dust:
                dust.Play();
                break;

            case PlayerParticleType.Land:
                land.Play();
                break;

            case PlayerParticleType.Stars:
                stars.Play();
                break;

            case PlayerParticleType.Rail:
                wind.Play();
                friction.Play();
                break;

            case PlayerParticleType.WindTrail:
                wind.Play();
                break;

            case PlayerParticleType.Acceleration:
                acceleration.Play();
                break;
        }
    }
    public void StopParticleSystem(PlayerParticleType playerParticleType)
    {
        switch (playerParticleType)
        {
            case PlayerParticleType.Dust:
                dust.Stop();
                break;

            case PlayerParticleType.Land:
                land.Stop();
                break;

            case PlayerParticleType.Stars:
                stars.Stop();
                break;

            case PlayerParticleType.Rail:
                wind.Stop();
                friction.Stop();
                break;

            case PlayerParticleType.WindTrail:
                wind.Stop();
                break;

            case PlayerParticleType.Acceleration:
                acceleration.Stop();
                break;
        }
    }
}
