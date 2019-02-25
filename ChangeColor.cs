using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

    //マテリアルを格納
    [SerializeField,Tooltip("マテリアルを格納 0:白or緑 1:赤 2:青")]
    public Material[] mats;

    public int col = 0;

	// Use this for initialization
	void Start () {

        this.GetComponent<Renderer>().material = mats[0];
    }

    /// <summary>
    /// 衝突判定
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        //RedBulletタグのオブジェクトが衝突した場合
        if (other.gameObject.tag == "RedBullet")
        {
            //もし白なら
            if (this.GetComponent<Renderer>().material.color == Color.white
                || this.GetComponent<Renderer>().material.color == new Color(0,0.5f,0,1))
            {
                //マテリアルを白から赤に変更
                this.GetComponent<Renderer>().material = mats[1];
                //リストに追加
                Score.redScore.Add(this.gameObject);
            }
            //もし青なら
            else if (this.GetComponent<Renderer>().material.color == Color.blue)
            {
                //5になったら
                if (col >= 5)
                {
                    //マテリアルを青から赤に変更
                    this.GetComponent<Renderer>().material = mats[1];
                    //リストに追加
                    Score.redScore.Add(this.gameObject);
                    col = 0;
                }
                else
                {
                    //衝突回数を1増加
                    col++;
                }
            }

            //衝突した弾を削除
            Destroy(other.gameObject);
        }
        //BlueBulletタグのオブジェクトが衝突した場合
        if (other.gameObject.tag == "BlueBullet")
        {
            //もし白なら
            if (this.GetComponent<Renderer>().material.color == Color.white
                || this.GetComponent<Renderer>().material.color == new Color(0,1.5f,0,1))
            {
                //マテリアルを白から赤に変更
                this.GetComponent<Renderer>().material = mats[2];
                //リストに追加
                Score.blueScore.Add(this.gameObject);
            }
            //もし赤なら
            else if (this.GetComponent<Renderer>().material.color == Color.red)
            {
                //5になったら
                if (col >= 5)
                {
                    //マテリアルを赤から青に変更
                    this.GetComponent<Renderer>().material = mats[2];
                    //リストに追加
                    Score.blueScore.Add(this.gameObject);
                    col = 0;
                }
                else
                {
                    //衝突回数を1増加
                    col++;
                }
            }

            //衝突した弾を削除
            Destroy(other.gameObject);
        }
    }
}
