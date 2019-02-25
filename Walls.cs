using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{

    //Wallオブジェクトを格納
    public GameObject wall;

    // Use this for initialization
    void Start()
    {

        //Wallオブジェクトを9つ複製
        for (int i = 0; i < 8; i++)
        {
            //left
            //上
            Instantiate(wall, new Vector3(-10, 15, 10 * i), transform.rotation);
            //下
            Instantiate(wall, new Vector3(-10, 5, 10 * i), transform.rotation);

            //right
            //上
            Instantiate(wall, new Vector3(80, 15, 10 * i), transform.rotation);
            //下
            Instantiate(wall, new Vector3(80, 5, 10 * i), transform.rotation);

            //top
            //上
            Instantiate(wall, new Vector3(10 * i, 15, 80), transform.rotation);
            //下
            Instantiate(wall, new Vector3(10 * i, 5, 80), transform.rotation);

            //bottom
            //上
            Instantiate(wall, new Vector3(10 * i, 15, -10), transform.rotation);
            //下
            Instantiate(wall, new Vector3(10 * i, 5, -10), transform.rotation);
        }        
    }
}