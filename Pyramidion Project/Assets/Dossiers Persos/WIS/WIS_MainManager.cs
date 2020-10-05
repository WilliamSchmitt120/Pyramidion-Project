using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (currentSectionState == sectionState.intro) { Intro(); }

        if (currentSectionState == sectionState.action) { Action(); }

        if (currentSectionState == sectionState.end) { End(); }



    }

    private void Intro()
    {
        // Sound Transition / StartAnimation

        Debug.Log("In " + currentSection.sectionName);

        animationPlayed = false;
        transitionPlayed = false;
        playedMainDialogue = false;

        if (animationPlayed == false && WIS_AnimationManager.instance.inAnimation == false)
        {

            WIS_AnimationManager.instance.StartAnimation();
            animationPlayed = true;



        }

        if (transitionPlayed == false && WIS_AudioManager.instance.inTransition == false)
        {

            transitionPlayed = true;



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

        if (WIS_AudioManager.instance.inMainDialogue == false && playedMainDialogue == false)
        {

            WIS_AudioManager.instance.StartMainDialogue();
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

        

        int keyNotPressed = 0;

        

        foreach (var endSection in currentSection.endSections)
        {

            switch (endSection.endInput)
            {
                case WIS_EndSection.inputTypes.Air:
                    if (WIS_InputManager.instance.airInput)
                    {
                        StartNextSection(endSection.nextSection);
                        Debug.Log("EndEnd");
                    };
                    break;
                case WIS_EndSection.inputTypes.Water:
                    if (WIS_InputManager.instance.waterInput)
                    {
                        StartNextSection(endSection.nextSection);
                        Debug.Log("EndEnd");
                    };
                    break;
                case WIS_EndSection.inputTypes.Earth:
                    if (WIS_InputManager.instance.earthInput)
                    {
                        StartNextSection(endSection.nextSection);
                        Debug.Log("EndEnd");
                    };
                    break;
                case WIS_EndSection.inputTypes.Fire:
                    if (WIS_InputManager.instance.fireInput)
                    {
                        StartNextSection(endSection.nextSection);
                        Debug.Log("EndEnd");
                    };
                    break;
                default:
                    break;
            }


            

        }

        if (keyNotPressed >= currentSection.endSections.Length && Input.anyKey == true && WIS_AudioManager.instance.inWrongDialogue == false)
        {

            WIS_AudioManager.instance.StartWrongDialogue();
            Debug.Log("KeyNotPressed = " + keyNotPressed);

        }

        

    }

    public void StartNextSection(WIS_Section section)
    {

        currentSection = section;
        currentSectionState = sectionState.intro;

        Debug.Log("StartNextSection");

    }

}
