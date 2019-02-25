using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour
{
    public static List<GameObject> redScore = new List<GameObject>();
    public static List<GameObject> blueScore = new List<GameObject>();

    public List<GameObject> all = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        redScore.Clear();
        blueScore.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        SetRed();
        SetBlue();

        StartCoroutine(All());
    }

    IEnumerator All()
    {
        if (all.Count == 0)
        {
            foreach (GameObject wall in GameObject.FindGameObjectsWithTag("Wall"))
            {
                all.Add(wall);
            }
            foreach (GameObject floor in GameObject.FindGameObjectsWithTag("Floor"))
            {
                all.Add(floor);
            }
        }

        yield break;
    }

    /// <summary>
    /// 赤でないものをリストから削除する
    /// </summary>
    void SetRed()
    {
        try
        {
            foreach (GameObject red in redScore)
            {
                if (red.GetComponent<Renderer>().material.color != Color.red)
                {
                    redScore.Remove(red);
                }
            }
        }
        catch
        { }
    }

    /// <summary>
    /// 青でないものをリストから削除する
    /// </summary>
    void SetBlue()
    {
        try
        {
            foreach (GameObject blue in blueScore)
            {
                if (blue.GetComponent<Renderer>().material.color != Color.blue)
                {
                    blueScore.Remove(blue);
                }
            }
        }
        catch
        { }        
    }
}