using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    private static SoundController instance;
    public static SoundController Instance { get { return instance; } }

    public Slider VolumeSlider;
    public AudioSource SoundEffect;
    public AudioSource SoundMusic;
    [Range(0f, 1f)] public float userVolume;
    public bool IsMute;
    public bool MoveLoop;
    public float Volume = 1f;

    public SoundType[] Sounds;



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
  
    private void Start()
    {
        SetVolume(userVolume);
        PlayMusic(global::Sounds.music);
        VolumeSlider.value = Volume;
    }
    private void Update()
    {
        SoundEffect.volume = VolumeSlider.value;
        SoundMusic.volume=VolumeSlider.value;
      
    }
    public void Mute(bool status)
    {
        IsMute = status;
    }
    public void SetVolume(float volume)
    {
        Volume = volume;
        SoundEffect.volume = Volume;
        SoundMusic.volume = Volume;
    }

    public void PlayMusic(Sounds sound)
    {
        if (IsMute) return;
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
            SoundMusic.clip = clip;
            SoundMusic.Play();
        }
        else
        {
            Debug.LogError("Sound Clip :" + clip.name + "not found");
        }
    }
    public void Play(Sounds sound)
    {
        if (IsMute) return;
        AudioClip clip = getSoundClip(sound);
        if (clip != null)
        {
                SoundEffect.loop = false;
                SoundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("Sound Clip :" + clip.name + "not found");
        }
    }
    public bool FootstepLoop(Sounds sounds)
    {   MoveLoop = false;        
        return MoveLoop;
    }

    private AudioClip getSoundClip(Sounds sound)
    {
        SoundType returnsound = Array.Find(Sounds, item => item.soundType == sound);
        if (returnsound != null)
        {
            return returnsound.soundclip;
        }
        return null;
    }

    public void StopEffect()
    {
        SoundEffect.Stop();
    }
}


[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundclip;
}
public enum Sounds
{
    ButtonClick,
    PlayerDied,
    music,
    LevelFinished,
    LevelStarted,

}

