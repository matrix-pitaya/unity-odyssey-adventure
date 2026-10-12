using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[DisallowMultipleComponent]
public class AudioManager : SingletenMonoBehaviour<AudioManager>
{
    [Header("UI CONFIRM AUDIO CLIP")]
    [SerializeField] AudioClip uiConfirm;

    AudioSource _audioSource;

    protected override void Awake()
    {
        base.Awake();
        LoadComponent();
        DontDestroyOnLoad(gameObject);
    }
    
    void LoadComponent()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void PlayUIConfirmAudioClip()
    {
        _audioSource.clip = uiConfirm;
        _audioSource.Play();
    }
    public void PlayAudio(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
