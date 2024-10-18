using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public Sound[] musicClips;
    public Sound[] sfxClips;

    private bool muted;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void SetVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void MuteUnMute()
    {
        if (muted)
        {
            musicSource.mute = true;
            sfxSource.mute = true;
        }
        else if (!muted)
        {
            musicSource.mute = false;
            sfxSource.mute = false;
        }
    }

    public void PlayMusic(string name)
    {
        Sound s = System.Array.Find(musicClips, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        musicSource.clip = s.clip;
        musicSource.Play();
    }

    public void PlaySFX(string name)
    {
        Sound s = System.Array.Find(sfxClips, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("FX: " + name + " not found!");
            return;
        }
        sfxSource.clip = s.clip;
        sfxSource.Play();
    }
}
