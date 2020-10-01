using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIS_Rotate : MonoBehaviour
{

    public GameObject cube1;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        cube1.transform.Rotate(new Vector3(1, 0, 0));




    }
}
