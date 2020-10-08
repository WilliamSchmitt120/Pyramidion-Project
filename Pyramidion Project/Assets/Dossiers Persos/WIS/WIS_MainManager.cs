using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WIS_MainManager : MonoBehaviour
{

    public static WIS_MainManager instance;

    public WIS_Section currentSection;

    public enum sectionState { intro, action, end }

    public sectionState currentSectionState;

    private bool animationPlayed;

    private bool transitionPlayed;

    private bool playedMainDialogue;

    public WIS_Section defaultSection;

    [SerializeField] public WIS_EndSection.inputTypes lastInput;

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
        currentSection = defaultSection;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentSection.isStartSection)
        {


        }
        else if (currentSection.isEndSection)
        {


        }
        else
        {

            if (currentSectionState == sectionState.intro) { Intro(); }

            if (currentSectionState == sectionState.action) { Action(); }

            if (currentSectionState == sectionState.end) { End(); }

        }





    }

    private void Intro()
    {
        // Sound Transition / StartAnimation

        Debug.Log("In " + currentSection.sectionName);

        playedMainDialogue = false;

        if (animationPlayed == false && WIS_AnimationManager.instance.inAnimation == false)
        {

            WIS_AnimationManager.instance.StartAnimation();
            animationPlayed = true;



        }

        if (transitionPlayed == false && WIS_AudioManager.instance.inTransition == false)
        {

            transitionPlayed = true;

            StartCoroutine(WIS_AudioManager.instance.Transition(lastInput));


        }

        if (animationPlayed == true && transitionPlayed == true && WIS_AnimationManager.instance.inAnimation == false && WIS_AudioManager.instance.inTransition == false)
        {

            currentSectionState = sectionState.action;

            Debug.Log("EndIntro");

        }

    }

    private void Action()
    {
        // MainDialogue

        animationPlayed = false;
        transitionPlayed = false;

        if (WIS_AudioManager.instance.inMainDialogue == false && playedMainDialogue == false)
        {

            StartCoroutine(WIS_AudioManager.instance.StartMainDialogue());
            playedMainDialogue = true;

        }


        if (WIS_AudioManager.instance.inMainDialogue == false && playedMainDialogue == true)
        {

            currentSectionState = sectionState.end;
            Debug.Log("EndAction");

        }

    }

    private void End()
    {
        // wrongDialogue if player input no correct / start next section

        foreach (var endSection in currentSection.endSections)
        {

            switch (endSection.endInput)
            {
                case WIS_EndSection.inputTypes.Air:
                    if (Input.GetKey(WIS_InputManager.instance.airKey))
                    {
                        lastInput = WIS_EndSection.inputTypes.Air;
                        currentSection = endSection.nextSection;
                        currentSectionState = sectionState.intro;

                        Debug.Log("StartNextSection");
                        return;
                    };
                    break;
                case WIS_EndSection.inputTypes.Water:
                    if (Input.GetKey(WIS_InputManager.instance.waterKey))
                    {
                        lastInput = WIS_EndSection.inputTypes.Water;
                        currentSection = endSection.nextSection;
                        currentSectionState = sectionState.intro;

                        Debug.Log("StartNextSection");
                        return;
                    };
                    break;
                case WIS_EndSection.inputTypes.Earth:
                    if (Input.GetKey(WIS_InputManager.instance.earthKey))
                    {
                        lastInput = WIS_EndSection.inputTypes.Earth;
                        currentSection = endSection.nextSection;
                        currentSectionState = sectionState.intro;

                        Debug.Log("StartNextSection");
                        return;
                    };
                    break;
                case WIS_EndSection.inputTypes.Fire:
                    if (Input.GetKey(WIS_InputManager.instance.fireKey))
                    {
                        lastInput = WIS_EndSection.inputTypes.Fire;
                        currentSection = endSection.nextSection;
                        currentSectionState = sectionState.intro;

                        Debug.Log("StartNextSection");
                        return;
                    };
                    break;
                default:
                    break;
            }


            

        }

        if (WIS_AudioManager.instance.inWrongDialogue == false && CheckInputs(currentSection) && currentSectionState == sectionState.end)
        {

            StartCoroutine(WIS_AudioManager.instance.StartWrongDialogue());
            Debug.Log("Wrong in " + currentSection.sectionName);

        }

        

    }

    public void StartNextSection(WIS_Section section)
    {



    }

    public bool CheckInputs(WIS_Section section)
    {
        //Return true if 

        int wrong;
        bool isWrong = false;
        wrong = 0;

        foreach (var endSection in section.endSections)
        {

            switch (endSection.endInput)
            {
                case WIS_EndSection.inputTypes.Air:
                    if (WIS_InputManager.instance.airInput == false) { wrong += 1; }
                    break;
                case WIS_EndSection.inputTypes.Water:
                    if (WIS_InputManager.instance.waterInput == false) { wrong += 1; }
                    break;
                case WIS_EndSection.inputTypes.Earth:
                    if (WIS_InputManager.instance.earthInput == false) { wrong += 1; }
                    break;
                case WIS_EndSection.inputTypes.Fire:
                    if (WIS_InputManager.instance.fireInput == false) { wrong += 1; }
                    break;
                default:
                    break;
            }



        }

        if (wrong >= section.endSections.Length && Input.anyKey) { isWrong = true; }

        return isWrong;

    }

}
