using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestBullet : MonoBehaviour {
    
    //テキスト
    Text bulletext;
    //現在の残弾数
    Bullet bullet;

	// Use this for initialization
	void Start () {

        bulletext = this.gameObject.GetComponent<Text>();
        bullet = this.gameObject.transform.parent.transform.parent.GetComponent<Bullet>();
	}
	
	// Update is called once per frame
	void Update () {

        //残弾数を表示
        bulletext.text = "残弾数 : " + bullet.nowResBullet.ToString();
	}
}
