using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[DisallowMultipleComponent]
public class Star : MonoBehaviour
{
    [Header("PLAYER COLLECT STARS AUDIO")]
    [SerializeField] AudioClip star;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(Setting.Player))
        {
            AudioManager.Instance.PlayAudio(star);
            PlayerGameDataManager.Instance.AddStars(1);
            UIManager.Instance.UpdataStartsUI();
            ObjectPoolManager.Instance.GetStarEffectGO().transform.position = gameObject.transform.position;
            ObjectPoolManager.Instance.GetFlashEffectGO().transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
    }
}
