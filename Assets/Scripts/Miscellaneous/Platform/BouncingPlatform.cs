using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[DisallowMultipleComponent]
public class BouncingPlatform : MonoBehaviour
{
    AudioSource audioSource;

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
        if (other.gameObject.CompareTag(Setting.Player))
        {
            if (other.gameObject.GetComponent<Player>() != null)
            {
                other.gameObject.GetComponent<Player>().IsOnBounce = true;
                other.gameObject.GetComponent<Player>().SwitchNode(Setting.Jump);
                audioSource.Play();
            }
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(Setting.Player))
        {
            if (other.gameObject.GetComponent<Player>() != null)
            {
                other.gameObject.GetComponent<Player>().IsOnBounce = true;
                other.gameObject.GetComponent<Player>().SwitchNode(Setting.Jump);
                audioSource.Play();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Setting.Player))
        {
            if (other.gameObject.GetComponent<Player>() != null)
            {
                other.gameObject.GetComponent<Player>().IsOnBounce = false;
            }
        }
    }
}
