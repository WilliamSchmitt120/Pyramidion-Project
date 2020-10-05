using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIS_InputManager : MonoBehaviour
{

    public static WIS_InputManager instance;

    public bool airInput;
    public bool fireInput;
    public bool earthInput;
    public bool waterInput;

    private float count;

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
        
        if (Input.GetKey(KeyCode.A))
        {
            airInput = true;
        }
        else { airInput = false; }

        if (Input.GetKey(KeyCode.F))
        {
            fireInput = true;
        }
        else { fireInput = false; }

        if (Input.GetKey(KeyCode.E))
        {
            earthInput = true;
        }
        else { earthInput = false; }

        if (Input.GetKey(KeyCode.W))
        {
            waterInput = true;
        }
        else { waterInput = false; }



    }
}
