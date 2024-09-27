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


    float timerAudio = 7.0f;
    float timerBaillement = 5.0f;
    public void Start()
    {
        PlaySFX(reveil);
        StartCoroutine(PlaySFXAfterDelay());
        StartCoroutine(PlayMusicAfterDelay());
        musicSource.clip = background;
    }

    // play the music after a delay
    private IEnumerator PlaySFXAfterDelay()
    {
        yield return new WaitForSeconds(timerBaillement);
        PlaySFX(reveilBaillement);
    }
    private IEnumerator PlayMusicAfterDelay()
    {
        yield return new WaitForSeconds(timerAudio);
        musicSource.Play();
    }

    // play the SFX
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
