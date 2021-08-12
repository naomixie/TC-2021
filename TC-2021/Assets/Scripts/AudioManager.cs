using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public List<SoundEffect> soundEffects = new List<SoundEffect>();

    [SerializeField]
    private List<SoundEffect> PlayingSoundEffects = new List<SoundEffect>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        GenerateAudioSources();
    }

    public void GenerateAudioSources()
    {
        foreach (SoundEffect soundEffect in soundEffects)
        {
            AudioSource audio = GameObject.FindGameObjectWithTag("Player").AddComponent<AudioSource>();
            audio.clip = soundEffect.soundClip;
            SoundEffect n_sound = new SoundEffect(soundEffect.soundType, soundEffect.soundClip, audio);
            PlayingSoundEffects.Add(n_sound);
        }
    }

    // play_loop means to play it while it stops playing, example use when moving
    public void PlaySoundEffect(SoundType sound, bool play_loop)
    {
        foreach (SoundEffect soundEffect in PlayingSoundEffects)
        {
            if (soundEffect.soundType == sound)
            {
                if ((play_loop && !soundEffect.soundAudio.isPlaying) || !play_loop)
                {
                    soundEffect.soundAudio.Play();
                }
            }
        }
    }
}
