using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    [Header("PLAYER ENTER WATER PLAY AUDIO CLIP")]
    [SerializeField] AudioClip enter;

    [Header("PLAYER EXIT WATER PLAY AUDIO CLIP")]
    [SerializeField] AudioClip exit;

    AudioSource audioSource;
    const float floatForce = 8.0f;

    void Awake()
    {
        LoadComponent();
    }

    void LoadComponent()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag(Setting.Player) || other.gameObject.CompareTag(Setting.Crate))
        {
            audioSource.clip = enter;
            audioSource.Play();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Setting.Player) || other.gameObject.CompareTag(Setting.Crate))
        {
            audioSource.clip = exit;
            audioSource.Play();
            if (other.gameObject.GetComponent<Player>() != null)
            {
                other.gameObject.GetComponent<Player>().IsInWater = false;
            }
        }
    }
}
