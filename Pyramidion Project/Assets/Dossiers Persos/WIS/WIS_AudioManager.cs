using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIS_AudioManager : MonoBehaviour
{

    public static WIS_AudioManager instance;

    public STG_Sound currentMusic;

    public STG_Sound currentDialogue;

    public STG_Sound currentTransition;

    public bool inTransition;

    public bool inMainDialogue;

    public bool inWrongDialogue;

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
        
    }

    public void StartTransition()
    {

        Debug.Log("StartTransition");
        inTransition = true;

        Debug.Log("InTransition");

        Debug.Log("EndTransition");
        inTransition = false;

    }

    public void StartMainDialogue()
    {

        Debug.Log("StartMainDialogue");
        inMainDialogue = true;

        Debug.Log("InMainDialogue");

        Debug.Log("EndMainDialogue");
        inMainDialogue = false;

    }

    public void StartWrongDialogue()
    {

        Debug.Log("StartWrongDialogue");
        inWrongDialogue = true;

        Debug.Log("InWrongDialogue");

        Debug.Log("EndWrongDialogue");
        inWrongDialogue = false;

    }

}
