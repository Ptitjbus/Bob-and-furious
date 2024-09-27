using System.Collections;
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

    // delay for the audio
    float timerAudio = 7.0f;
    float timerBaillement = 5.0f;

    public void Start()
    {
        PlaySFX(reveil);
        StartCoroutine(PlayAudioAfterDelay(SFXSource, reveilBaillement, timerBaillement));
        StartCoroutine(PlayAudioAfterDelay(musicSource, background, timerAudio));
    }

    // play the audio after a delay
    private IEnumerator PlayAudioAfterDelay(AudioSource source, AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);
        source.PlayOneShot(clip);
    }

    // play the SFX in the game
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
