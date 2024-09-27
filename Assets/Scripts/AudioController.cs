using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : BaseController<AudioController>
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]

    public AudioClip background;
    public AudioClip collectable;
    public AudioClip reveil;
    public AudioClip reveilBaillement;
    public AudioClip lightSwitch;


    private void Start()
    {
        musicSource.clip = reveil;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
