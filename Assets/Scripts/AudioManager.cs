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
            introAudioSource.Play();
            introAudioSource.loop = false;
            
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
