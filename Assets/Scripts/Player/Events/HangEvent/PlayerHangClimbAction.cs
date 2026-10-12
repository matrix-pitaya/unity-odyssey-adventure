using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerHangClimbAction : MonoBehaviour
{
    Player player;
    bool isHangClimb;

    void Awake()
    {
        LoadComponent();
    }
    void OnEnable()
    {
        player.PlayerEvents.HangClimbEvent.OnHangClimb += HangClimbEvent_OnHangClimb;
    }
    void OnDisable()
    {
        player.PlayerEvents.HangClimbEvent.OnHangClimb -= HangClimbEvent_OnHangClimb;
    }

    public bool IsHangClimb
    {
        get
        {
            return isHangClimb;
        }
    }

    void LoadComponent()
    {
        player = gameObject.GetComponentInParent<Player>();
    }
    void HangClimbEvent_OnHangClimb(HangClimbEvent hangClimbEvent)
    {
        HangClimb();
    }
    void HangClimb()
    {
        StartCoroutine(HangClimbCoroutine(player.PlayerDetail.HangClimbDuration));
    }

    IEnumerator HangClimbCoroutine(float duration)
    {
        isHangClimb = true;
        player.EnableGravity = false;
        player.CapsuleCollider.enabled = false;
        player.SkinTransform.parent = null;
        Vector3 src = player.transform.position;
        float passTime = 0;
        while (true)
        {
            player.transform.position = Vector3.Lerp(src, player.FootCenterPosition, passTime / duration);
            passTime += Time.deltaTime;
            if (passTime >= duration)
            {
                break;
            }
            yield return null;
        }
        player.transform.position = player.FootCenterPosition;
        player.EnableGravity = true;
        player.CapsuleCollider.enabled = true;
        player.PlayerAnimator.PlayIdleAnimationImmediate();
        player.SkinTransform.parent = player.transform;
        player.SkinTransform.localPosition = Vector3.zero;
        player.SkinTransform.localRotation = Quaternion.identity;
        isHangClimb = false;
    }
}
