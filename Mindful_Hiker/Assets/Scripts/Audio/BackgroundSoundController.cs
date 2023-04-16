using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] bgMusic;

    private int index;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        index = -1;
        audioSource.Stop();
    }

    private void Update()
    {
        if (audioSource.isPlaying == false)
        {
            index++;
            if (index >= bgMusic.Length)
            {
                index = 0;
            }

            Play();
        }
    }

    private void Play()
    {
        audioSource.clip = bgMusic[index];
        audioSource.Play();
    }
}
