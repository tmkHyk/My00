using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planes : MonoBehaviour {

    public GameObject plane;

    // Use this for initialization
    void Start()
    {
        for (var i = 0; i < 8; i++)
        {
            //Instantiate(plane, new Vector3(0, 0, 10 * i), transform.rotation);
            for (var j = 0; j < 8; j++)
            {
                Instantiate(plane, new Vector3(j*10, -5, 10*i), transform.rotation);
            }
        }
    }
}
