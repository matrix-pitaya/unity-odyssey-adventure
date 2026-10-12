using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [Header("HEART PICKED UP AUDIO CLIP")]
    [SerializeField] AudioClip pickUp;

    [Header("HEART BRON AUDIO CLIP")]
    [SerializeField] AudioClip bron;

    AudioSource audioSource;

     void Awake()
    {
        LoadComponent();
    }

    void LoadComponent()
    {
        audioSource = gameObject.GetComponentInChildren<AudioSource>();
    }

    public void PlayHeartAudio(bool isPick)
    {
        audioSource.clip = isPick ? pickUp : bron;
        audioSource.Play();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(Setting.Player))
        {
            AudioManager.Instance.PlayAudio(pickUp);
            UIManager.Instance.UpdataHeartsNumUI(GameManager.Instance.Player.Health.Value >= 3 ? Setting.PlayerDefaulHurtNum : GameManager.Instance.Player.Health.IncreaseHealth(1));
            ObjectPoolManager.Instance.GetHeartEffectGO().transform.position = gameObject.transform.position;
            ObjectPoolManager.Instance.ReleaseHeartGO(gameObject);
        }
    }
}
