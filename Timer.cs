using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    //テキスト
    Text timerText;
    //制限時間
    public float timer = 10;

	// Use this for initialization
	void Start () {

        timerText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        timer -= timer >= 0 ? Time.deltaTime : 0;

        //タイマーの表示
        timerText.text = timer.ToString("f0");

        if (timer <= 0)
        {
            SceneManager.LoadScene("Result");
        }
	}
}
