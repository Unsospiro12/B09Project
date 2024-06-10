using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip[] BGM;
    AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
            PlayRandom();
    }

    private void PlayRandom()
    {
        audioSource.clip = BGM[Random.Range(0, BGM.Length)];
        audioSource.Play();
    }
}
