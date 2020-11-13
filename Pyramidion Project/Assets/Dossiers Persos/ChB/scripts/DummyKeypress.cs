using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;

public class DummyKeypress : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            UduinoManager.Instance.sendCommand("victory");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            UduinoManager.Instance.sendCommand("defeat");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            UduinoManager.Instance.sendCommand("reset");
        }
    }
}
