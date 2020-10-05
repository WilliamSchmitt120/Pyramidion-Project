using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIS_AnimationManager : MonoBehaviour
{

    public static WIS_AnimationManager instance;

    public enum form { Chose, Pierre, Amas, Eclat, Sphère, Pyramide}

    public form currentForm;

    public bool inAnimation;

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

    public void StartAnimation()
    {
        Debug.Log("InAnimation");

        inAnimation = true;

        Debug.Log("EndAnimation");

        inAnimation = false;

    }



}
