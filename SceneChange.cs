using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

    //制限時間　タイマー
    public static float time = 10;  //Timerクラスで使用
    //カウントダウン可能か　trueのとき開始可能
    bool timelimit = false;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {

        //ボタン()が押されたら
        if (Input.GetKeyDown(KeyCode.Joystick2Button3))
        {
            //現在のシーンがMainなら
            if (SceneManager.GetActiveScene().name == "Main")
            {
                //Boardシーンへ
                SceneManager.LoadScene("Board");
            }
            //現在のシーンがBordかつタイマーが0のとき
            if (SceneManager.GetActiveScene().name == "Board")
            {
                //Mainシーンへ
                SceneManager.LoadScene("Main");
            }
        }
        //消さない
        DontDestroyOnLoad(this);
    }
}
