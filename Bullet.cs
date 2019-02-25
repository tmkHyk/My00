using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    //銃弾
    public GameObject bullet;
    //発射位置
    public Transform muzzle;
    [SerializeField,Range(100,2000),Tooltip("弾の速度")]
    float speed = 100;
    [SerializeField,Range(1,50),Tooltip("残弾数")]
    int resBullet = 30;
    //現在の残弾数
    public int nowResBullet;

    [SerializeField,Range(0,100),Tooltip("残弾数のリセット時間")]
    public int timer = 50;
    //ボタンが押せるか　trueのとき押せる
    bool pushFlag = false;
    
    CharacterControl chara;

	// Use this for initialization
	void Start () {

        nowResBullet = resBullet;

        chara = this.gameObject.GetComponent<CharacterControl>();
    }
	
	// Update is called once per frame
	void Update () {

        //カウントダウン処理
        CountDown();
        //発砲処理
        Shot();
    }

    /// <summary>
    /// 弾を増やせるかどうか
    /// </summary>
    /// <returns></returns>
    bool GetPush()
    {
        //残段数が0になったらtrueを返す
        pushFlag = nowResBullet == 0 ? true : false;
        return pushFlag;
    }

    /// <summary>
    /// タイマーのカウントダウン処理
    /// </summary>
    void CountDown()
    {
        if (GetPush() == true)
        {
            //ボタン()が押されたらカウントダウン開始
            timer -= Input.GetButton("Fire3_" + chara.playerNumber.ToString()) ? 1 : 0;

            //タイマーが0以下なら
            if (timer <= 0)
            {
                //タイマーを0に指定
                timer = 0;
                //残弾数を30に指定(弾数回復)
                nowResBullet = resBullet;
                //タイマーを1に指定(タイマー初期化)
                timer = 100;
            }
        }
    }

    /// <summary>
    /// 発砲処理
    /// </summary>
    void Shot()
    {
        //ボタン()を押されたとき
        if (Input.GetButtonDown("Fire2_" + chara.playerNumber.ToString()) && chara.move != 0)
        {
            //残弾数を1減らす
            nowResBullet-=1;
            //弾の複製処理
            CreateBullets();
        }
    }

    /// <summary>
    /// 弾の複製処理
    /// </summary>
    void CreateBullets()
    {
        //残弾数が0より大きいのとき
        if (nowResBullet > 0)
        {
            //bulletsオブジェクトを新しく宣言、bulletの複製を生成
            GameObject bullets = GameObject.Instantiate(bullet) as GameObject;
            //進行方向への力
            Vector3 force;
            //進行方向×100×speed
            force = muzzle.transform.forward * 100 * speed;
            //bulletsに力forceを追加
            bullets.GetComponent<Rigidbody>().AddForce(force);            
            //bulletsの生成位置を発射位置muzzleに指定
            bullets.transform.position = muzzle.position;
            //生成(発砲)して1秒後に削除
            Destroy(bullets, 1.0f);
        }
        //残弾数が0以下のとき
        else
        {
            //残弾数は0以下にはならないので0に指定
            nowResBullet = 0;
        }
    }
}