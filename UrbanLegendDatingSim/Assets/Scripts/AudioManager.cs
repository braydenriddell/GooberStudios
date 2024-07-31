using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    /// <summary>
    /// Play sound
    /// </summary>
    /// <param name="name"></param>
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }

        //Check is loop -- play
        if (s.source.loop == true)
        {
            s.source.Play();
        }
        else
        {
            s.source.PlayOneShot(s.clip, s.volume);
        }
        CheckIfPlaying(name);
    }

    /// <summary>
    /// Stop sound
    /// </summary>
    /// <param name="name"></param>
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }

    /// <summary>
    /// Return true/false if the sound is currently playing
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public bool CheckIfPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s.source.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
