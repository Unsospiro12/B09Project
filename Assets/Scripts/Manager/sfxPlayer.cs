using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum sfxSoundType
{
    Jump,
    SideStep,
    GetCoin,
    BladeSound,
    MaxCount
}

public class sfxPlayer : MonoBehaviour
{
    AudioSource[] _sfxAudioSources = new AudioSource[(int)sfxSoundType.MaxCount];
    Dictionary<string, AudioClip> _sfxAudioClips = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        Init();
    }

    void Init()
    {
        for (int i = 0; i < _sfxAudioSources.Length; i++)
        {
            string fileName = Enum.GetName(typeof(sfxSoundType), i);

            AudioClip clip = (Resources.Load<AudioClip>($"Sounds/SFX/{fileName}"));

            if(clip != null)
            {
                _sfxAudioClips.Add(fileName, clip);
            }

            _sfxAudioSources[i] = this.gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlaySFXSound(sfxSoundType type)
    {
        foreach(AudioSource audioSource in _sfxAudioSources)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = _sfxAudioClips[type.ToString()];
                audioSource.Play();

                return;
            }
        }
    }
}
