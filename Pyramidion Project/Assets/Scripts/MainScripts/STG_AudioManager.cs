using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
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
        //StartCoroutine(StartFade("Theme", 10f, 0.5f));
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

   public IEnumerator StartFade(string name, float duration, float targetVolume)
   {
        STG_Sound s = Array.Find(sounds, sound => sound.name == name);
        float currentTime = 0;
        float start = s.source.volume;
        s.source.Play();
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            s.source.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }

        yield break;
   }
}
