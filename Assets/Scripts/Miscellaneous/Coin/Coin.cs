using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("COIN AUDIO CLIP")]
    [SerializeField] AudioClip coin;
    [SerializeField] AudioClip pop;

    AudioSource audioSource;

    void Awake()
    {
        LoadComponent();
    }

    void LoadComponent()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayCoinAudio(bool isPopClip)
    {
        audioSource.clip = isPopClip ? pop : coin;
        audioSource.Play();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer(Setting.Player))
        {
            AudioManager.Instance.PlayAudio(coin);
            UIManager.Instance.UpdataCoinsNumUI(PlayerGameDataManager.Instance.AddCoins(1));
            ObjectPoolManager.Instance.GetFlashEffectGO().transform.position = gameObject.transform.position;
            ObjectPoolManager.Instance.ReleaseCoinGO(gameObject);
        }
    }
}
