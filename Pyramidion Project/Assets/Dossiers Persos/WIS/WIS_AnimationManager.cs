using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIS_AnimationManager : MonoBehaviour
{

    public static WIS_AnimationManager instance;

    public enum form { Chose, Pierre, Amas, Eclat, Sphere, Pyramide}

    public form currentForm;

    public bool inAnimation;

    public GameObject chose;
    public GameObject pierre;
    public GameObject amas;
    public GameObject eclat;
    public GameObject sphere;
    public GameObject pyramide;

    public GameObject cube;


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

        switch (WIS_MainManager.instance.currentSection.form)
        {
            case form.Chose:
                HideAll();
                chose.SetActive(true);
                break;
            case form.Pierre:
                HideAll();
                pierre.SetActive(true);
                break;
            case form.Amas:
                HideAll();
                amas.SetActive(true);
                break;
            case form.Eclat:
                HideAll();
                eclat.SetActive(true);
                break;
            case form.Sphere:
                HideAll();
                sphere.SetActive(true);
                break;
            case form.Pyramide:
                HideAll();
                pyramide.SetActive(true);
                break;
            default:
                break;
        }
        Debug.Log("EndAnimation");

        inAnimation = false;

    }

    private void HideAll()
    {

        chose.SetActive(false);
        pierre.SetActive(false);
        amas.SetActive(false);
        eclat.SetActive(false);
        sphere.SetActive(false);
        pyramide.SetActive(false);

    }

}
