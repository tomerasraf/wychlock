using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource m_AudioSource;
    public AudioSource sfx_AudioSource;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayVFX(AudioClip clip, float volume)
    {
        sfx_AudioSource.PlayOneShot(clip, volume);
    }

    public void PlayMusic()
    {
        m_AudioSource.Play();

    }
}
