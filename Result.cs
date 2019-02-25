using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public Slider slider1, slider2;
    Text text;

    // Use this for initialization
    void Start()
    {
        slider1 = this.gameObject.transform.GetChild(0).GetComponent<Slider>();
        slider2 = this.gameObject.transform.GetChild(1).GetComponent<Slider>();

        slider1.maxValue = 128;
        slider2.maxValue = 128;

        slider1.value = 128 - Score.blueScore.Count;
        slider2.value = Score.redScore.Count;


        text = GameObject.Find("VictoryText").GetComponent<Text>();
        if (Score.redScore.Count == Score.blueScore.Count)
        {
            text.color = Color.black;
            text.text = "DRAW";
        }
        else if (Score.redScore.Count > Score.blueScore.Count)
        {
            text.color = Color.red;
            text.text = "PLAYER 1 WIN";
        }
        else if (Score.redScore.Count < Score.blueScore.Count)
        {
            text.color = Color.blue;
            text.text = "PLAYER 2 WIN";
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1_1") || Input.GetButtonDown("Fire1_1"))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
