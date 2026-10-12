using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerGliderAction : MonoBehaviour
{
    [Header("PLAYER GLIDER TRANSFORM")]
    [SerializeField] Transform gliderTransform;

    TrailRenderer[] trails;
    Player player;
    IEnumerator scaleGliderCoroutine;
    const float scaleDuration = 0.15f;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.GliderEvent.OnGlider += GliderEvent_OnGlider;
    }
    void OnDisable()
    {
        player.PlayerEvents.GliderEvent.OnGlider -= GliderEvent_OnGlider;
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
        trails = gliderTransform.gameObject.GetComponentsInChildren<TrailRenderer>();
    }
    void GliderEvent_OnGlider(GliderEvent gliderEvent, GliderEventArgs gliderEventArgs)
    {
        MoveRigidbody(gliderEventArgs.direction, gliderEventArgs.acceleration, gliderEventArgs.maxSpeed);
        Rotate(gliderEventArgs.direction, gliderEventArgs.rotateSpeed);
        InlineMode(gliderEventArgs.horizontal, gliderEventArgs.inlineMaxAngle, gliderEventArgs.inclineSmoothness);
    }
    void MoveRigidbody(Vector3 direction,float acceleration,float maxSpeed)
    {
        if(direction.sqrMagnitude > 0)
        {
            float speed = Vector3.Dot(direction, player.LateralVelocity);
            if (player.LateralVelocity.magnitude < maxSpeed || speed < 0)
            {
                speed += acceleration * Time.deltaTime;
                speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);
            }
            player.LateralVelocity = direction * speed;
            player.Rigidbody.velocity = player.LateralVelocity + player.VerticalVelocity;
        }
        else if(player.PlayerControl.MoveAbsoluteDirection.sqrMagnitude <= 0)
        {
            float speed = player.LateralVelocity.magnitude;
            if(speed > 0)
            {
                speed -= acceleration * Time.deltaTime;
                speed = (speed > 0) ? speed : 0;
            }
            player.LateralVelocity = player.gameObject.transform.forward * speed;
            player.Rigidbody.velocity = player.LateralVelocity + player.VerticalVelocity;
        }
    }
    void Rotate(Vector3 direction, float rotateSpeed)
    {
        if (direction.sqrMagnitude > 0)
        {
            player.gameObject.transform.rotation = Quaternion.RotateTowards(player.gameObject.transform.rotation,
                Quaternion.LookRotation(direction, Vector3.up), rotateSpeed * Time.deltaTime);
        }
    }
    void InlineMode(float horizontal, float inlineMaxAngle, float inclineSmoothness)
    {
        player.SkinTransform.localRotation = Quaternion.Slerp(player.SkinTransform.localRotation,
            Quaternion.Euler(0, 0, -horizontal * inlineMaxAngle), inclineSmoothness * Time.deltaTime);
    }

    public void EnableGlider(bool value)
    {
        if(scaleGliderCoroutine != null)
        {
            StopCoroutine(scaleGliderCoroutine);
        }
        if(value)
        {
            scaleGliderCoroutine = ScaleGliderCoroutine(gliderTransform.localScale, Vector3.one);
            player.PlayerAudio.PlayAudio(PlayerAudioClipType.Glider);
            foreach(var trail in trails)
            {
                trail.enabled = true;
            }
        }
        else
        {
            scaleGliderCoroutine = ScaleGliderCoroutine(gliderTransform.localScale, Vector3.zero);
            player.PlayerAudio.PlayAudio(PlayerAudioClipType.Glider);
            foreach (var trail in trails)
            {
                trail.enabled = false;
            }
        }
        StartCoroutine(scaleGliderCoroutine);
    }

    IEnumerator ScaleGliderCoroutine(Vector3 from,Vector3 to)
    {
        float passTime = 0;
        while (true)
        {
            gliderTransform.localScale = Vector3.Lerp(from, to, passTime / scaleDuration);
            passTime += Time.deltaTime;
            if(passTime >= scaleDuration)
            {
                break;
            }
            yield return null;
        }
        gliderTransform.localScale = to;
    }
}
