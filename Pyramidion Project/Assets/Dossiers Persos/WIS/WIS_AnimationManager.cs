using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WIS_AnimationManager : MonoBehaviour
{

    public static WIS_AnimationManager instance;

    public enum form { Chose, Pierre, Amas, Eclat, Sphere, Pyramide}

    public form currentForm;

    public bool inAnimation;
    public bool inEndAnimation;

    public GameObject chose;
    public GameObject pierre;
    public GameObject amas;
    public GameObject eclat;
    public GameObject sphere;
    public GameObject pyramide;

    public GameObject cube;

    [Header("VFX")]

    public ParticleSystem fireFX1;
    public ParticleSystem fireFX2;
    public ParticleSystem fireFX3;
    public ParticleSystem fireFX4;

    public ParticleSystem rockFX1;
    public ParticleSystem rockFX2;
    public ParticleSystem rockFX3;
    public ParticleSystem rockFX4;

    public ParticleSystem waterFX1;
    public ParticleSystem waterFX2;
    public ParticleSystem waterFX3;
    public ParticleSystem waterFX4;

    public ParticleSystem windFX1;
    public ParticleSystem windFX2;
    public ParticleSystem windFX3;
    public ParticleSystem windFX4;

    [Header("Forms Positions & Canvas")]

    public float formPosition;

    


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

    public IEnumerator PlayFX(WIS_EndSection.inputTypes type)
    {

        inAnimation = true;

        float duration;

        switch (type)
        {
            case WIS_EndSection.inputTypes.Air:
                windFX1.Play();
                windFX2.Play();
                windFX3.Play();
                windFX4.Play();
                duration = windFX1.main.duration;
                break;
            case WIS_EndSection.inputTypes.Water:
                waterFX1.Play();
                waterFX2.Play();
                waterFX3.Play();
                waterFX4.Play();
                duration = waterFX1.main.duration;
                break;
            case WIS_EndSection.inputTypes.Earth:
                rockFX1.Play();
                rockFX2.Play();
                rockFX3.Play();
                rockFX4.Play();
                duration = rockFX1.main.duration;
                break;
            case WIS_EndSection.inputTypes.Fire:
                fireFX1.Play();
                fireFX2.Play();
                fireFX3.Play();
                fireFX4.Play();
                duration = fireFX1.main.duration;
                break;
            default:
                duration = 0;
                break;
        }

        yield return new WaitForSeconds(duration/2);

        StartAnimation();

        yield return new WaitForSeconds(duration/2);

        inAnimation = false;

    }

    public IEnumerator EndAnimation()
    {

        inEndAnimation = true;

        while (cube.transform.position.y > -50)
        {

            cube.transform.Translate(new Vector3(0, -10, 0) * Time.deltaTime, Space.World);

            if (WIS_AnimationManager.instance.inAnimation == false)
            {

                StartCoroutine(PlayFX(WIS_MainManager.instance.lastInput));

            }

            yield return null;

        }


        inEndAnimation = false;


    }

    public void InitialisePosition()
    {

        cube.transform.position = new Vector3(0, 0, 50);

    }





}
