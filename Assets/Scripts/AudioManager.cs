using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource introAudioSource;
    public AudioSource normalAudioSource;

    void Start()
    {
        if (introAudioSource != null && introAudioSource.clip != null)
        {
            Debug.Log("Playing intro audio...");
            introAudioSource.Play();
            introAudioSource.loop = false;

            Debug.Log("Intro audio length: " + introAudioSource.clip.length);
            Invoke("PlayNormalBackgroundMusic", introAudioSource.clip.length);
        }
        else
        {
            Debug.LogWarning("Intro audio source or clip is missing.");
        }
    }

    void PlayNormalBackgroundMusic()
    {
        if (normalAudioSource != null)
        {
            Debug.Log("Switching to normal background music...");
            normalAudioSource.loop = true;
            normalAudioSource.Play();
        }
        else
        {
            Debug.LogWarning("Normal audio source is missing.");
        }
    }
}
