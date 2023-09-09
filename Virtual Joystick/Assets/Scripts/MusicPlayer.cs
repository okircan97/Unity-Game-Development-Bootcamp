using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    // Fields
    MusicPlayer musicPlayer;
    AudioSource audioSource;

    // Singleton pattern.
    private void Awake()
    {
        if (musicPlayer == null)
        {
            musicPlayer = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        // Get the audio source component.
        audioSource = GetComponent<AudioSource>();
    }

    // Handle the music player.
    public void HandleMusic()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
        else
            audioSource.Stop();
    }
}
