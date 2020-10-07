using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class WIS_AudioManager : MonoBehaviour
{

    public static WIS_AudioManager instance;

    public STG_Sound currentMusic;

    public STG_Sound currentDialogue;

    public STG_Sound currentTransition;

    public bool inTransition;

    public bool inMainDialogue;

    public bool inWrongDialogue;

    public AudioSource musicSource;
    public AudioSource dialogueSource;
    public AudioSource transitionSource;

    [Header("Audio Clips")]

    public STG_Sound transitionAir;
    public STG_Sound transitionWater;
    public STG_Sound transitionEarth;
    public STG_Sound transitionFire;

    void Awake()
    {

        if (instance == null)
        {

            instance = this;

        }
        else
        {

            GameObject.Destroy(this);

        }

        DontDestroyOnLoad(this);



    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        musicSource.clip = null;
    }

    public IEnumerator Transition(WIS_EndSection.inputTypes inputType)
    {

        Debug.Log("StartTransition");
        inTransition = true;

        switch (inputType)
        {
            case WIS_EndSection.inputTypes.Air:
                transitionSource.clip = transitionAir.clip;
                transitionSource.volume = transitionAir.volume;
                transitionSource.pitch = transitionAir.pitch;
                break;
            case WIS_EndSection.inputTypes.Water:
                transitionSource.clip = transitionWater.clip;
                transitionSource.volume = transitionWater.volume;
                transitionSource.pitch = transitionWater.pitch;
                break;
            case WIS_EndSection.inputTypes.Earth:
                transitionSource.clip = transitionEarth.clip;
                transitionSource.volume = transitionEarth.volume;
                transitionSource.pitch = transitionEarth.pitch;
                break;
            case WIS_EndSection.inputTypes.Fire:
                transitionSource.clip = transitionFire.clip;
                transitionSource.volume = transitionFire.volume;
                transitionSource.pitch = transitionFire.pitch;
                break;
            default:
                break;
        }

        transitionSource.Play();

        Debug.Log("InTransition");

        yield return new WaitForSeconds(transitionSource.clip.length);


        Debug.Log("EndTransition");
        inTransition = false;

        transitionSource.Stop();

    }

    public IEnumerator StartMainDialogue()
    {

        Debug.Log("StartMainDialogue");
        inMainDialogue = true;

        dialogueSource.clip = WIS_MainManager.instance.currentSection.introductionMonologue.clip;
        dialogueSource.volume = WIS_MainManager.instance.currentSection.introductionMonologue.volume;
        dialogueSource.pitch = WIS_MainManager.instance.currentSection.introductionMonologue.pitch;

        dialogueSource.Play();

        Debug.Log("InMainDialogue");

        yield return new WaitForSeconds(dialogueSource.clip.length);

        dialogueSource.Stop();

        Debug.Log("EndMainDialogue");
        inMainDialogue = false;

    }

    public IEnumerator StartWrongDialogue()
    {

        Debug.Log("StartWrongDialogue");
        inWrongDialogue = true;

        dialogueSource.clip = WIS_MainManager.instance.currentSection.wrongMonologue.clip;
        dialogueSource.volume = WIS_MainManager.instance.currentSection.wrongMonologue.volume;
        dialogueSource.pitch = WIS_MainManager.instance.currentSection.wrongMonologue.pitch;

        dialogueSource.Stop();

        Debug.Log("InWrongDialogue");

        yield return new WaitForSeconds(dialogueSource.clip.length);

        Debug.Log("EndWrongDialogue");
        inWrongDialogue = false;

    }





}
