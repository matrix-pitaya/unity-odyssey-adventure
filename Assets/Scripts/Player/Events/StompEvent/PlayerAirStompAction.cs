using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerAirStompAction : MonoBehaviour
{
    Player player;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.AirStompEvent.OnAirStomp += AirStompEvent_OnAirStomp;
    }
    void OnDisable()
    {
        player.PlayerEvents.AirStompEvent.OnAirStomp -= AirStompEvent_OnAirStomp;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void AirStompEvent_OnAirStomp(AirStompEvent airStompEvent)
    {
        AirStomp();
    }
    void AirStomp()
    {
        StartCoroutine(AirStompCoroutine(player.PlayerDetail.AirStompRotateDuration,player.PlayerDetail.StompGroundDuration,
            player.PlayerDetail.AirStompDownSpeed));
    }

    IEnumerator AirStompCoroutine(float airStompRotateDuration, float stompGroundDuration, float airStompDownSpeed)
    {
        player.LateralVelocity = Vector3.zero;
        player.VerticalVelocity = Vector3.zero;
        player.IsStomp = true;
        player.IsInvincible = true;
        player.EnableGravity = false;
        player.Rigidbody.isKinematic = true;
        yield return new WaitForSeconds(airStompRotateDuration);
        player.Rigidbody.isKinematic = false;
        player.StompHitBox.BoxCollider.enabled = true;
        while(!player.IsOnGround)
        {
            player.Rigidbody.velocity = Vector3.down * airStompDownSpeed;
            yield return null;
        }
        player.PlayerAudio.PlayAudio(PlayerAudioClipType.Stomp);
        player.PlayerParticle.PlayParticleSystem(PlayerParticleType.Land);
        player.StompHitBox.BoxCollider.enabled = false;
        player.Rigidbody.velocity = Vector3.zero;
        yield return new WaitForSeconds(stompGroundDuration);
        player.EnableGravity = true;
        player.SwitchNode(Setting.Jump);
        player.IsInvincible = false;
        player.IsStomp = false;
    }
}
