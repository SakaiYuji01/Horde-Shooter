using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

   public static void play_audio(AudioSource audio, AudioClip toplay)
    {
        audio.Stop();
        audio.clip = toplay;
        audio.Play();
    }

    public static void play_audio_onshot(AudioSource audio, AudioClip toplay)
    {
        audio.PlayOneShot(toplay ,0.10f);
    }
}
