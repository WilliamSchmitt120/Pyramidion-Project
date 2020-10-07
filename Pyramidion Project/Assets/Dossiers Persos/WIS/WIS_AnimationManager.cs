using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIS_AnimationManager : MonoBehaviour
{

    public static WIS_AnimationManager instance;

    public enum form { Chose, Pierre, Amas, Eclat, Sphere, Pyramide}

    public form currentForm;

    public bool inAnimation;

    public Mesh meshChose;
    public Mesh meshPierre;
    public Mesh meshAmas;
    public Mesh meshEclat;
    public Mesh meshSphere;
    public Mesh meshPyramide;

    public MeshFilter cube;


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
                cube.mesh = meshChose;
                break;
            case form.Pierre:
                cube.mesh = meshPierre;
                break;
            case form.Amas:
                cube.mesh = meshAmas;
                break;
            case form.Eclat:
                cube.mesh = meshEclat;
                break;
            case form.Sphere:
                cube.mesh = meshSphere;
                break;
            case form.Pyramide:
                cube.mesh = meshPyramide;           
                break;
            default:
                break;
        }


        


        Debug.Log("EndAnimation");

        inAnimation = false;

    }



}
