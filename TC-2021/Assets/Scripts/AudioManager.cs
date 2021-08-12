using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<SoundEffect> soundEffects = new List<SoundEffect>();


    public void PlaySoundEffect(SoundType sound)
    {
        SoundEffect soundEffect = FindSoundEffect(sound);
        AudioSource audio = GameObject.FindGameObjectWithTag("Player").AddComponent<AudioSource>();
        audio.clip = soundEffect.soundClip;
        audio.Play();
    }

    public SoundEffect FindSoundEffect(SoundType soundType)
    {
        foreach (SoundEffect soundEffect in soundEffects)
        {
            if (soundEffect.soundType == soundType)
            {
                return soundEffect;
            }
        }
        Debug.Log("Error: SoundEffect not found/registered.");
        return soundEffects[0];
    }
}
