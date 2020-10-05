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

    public KeyCode airKey;
    public KeyCode fireKey;
    public KeyCode earthKey;
    public KeyCode waterKey;

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
        
        if (Input.GetKey(airKey))
        {
            airInput = true;
        }
        else { airInput = false; }

        if (Input.GetKey(fireKey))
        {
            fireInput = true;
        }
        else { fireInput = false; }

        if (Input.GetKey(earthKey))
        {
            earthInput = true;
        }
        else { earthInput = false; }

        if (Input.GetKey(waterKey))
        {
            waterInput = true;
        }
        else { waterInput = false; }



    }
}
