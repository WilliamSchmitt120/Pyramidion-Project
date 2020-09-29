using UnityEngine.Audio;
using System;
using UnityEngine;

public class STG_AudioManager : MonoBehaviour
{
    public STG_Sound[] sounds;

    public static STG_AudioManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (STG_Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

   void Start()
    {
        Play("Theme");
    }

   public void Play (string name)
    {
        STG_Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound : " + name + "not found!");
            return;
        }

        s.source.Play();
    }



}
