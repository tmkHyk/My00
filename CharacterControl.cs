using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{

    //アニメーションを扱うためのアニメーター
    Animator animator;

    [SerializeField, Range(1, 10), Tooltip("ジャンプ時に加える速度")]
    float jumpPower = 10f;
    //ジャンプ中かどうか　trueのとき
    public bool isJump = false;

    Rigidbody rb;

    //プレイヤーのカメラ
    Camera cam;
    //カメラの速度
    float cameraSpeed = 100f;
    //プレイヤー番号
    public int playerNumber;

    [SerializeField, Range(0, 10), Tooltip("攻撃を受けた時のインターバル")]
    float interval;
    //インターバル保存用
    float m_interval;
    //プレイヤーが動けるかどうか
    public int move = 1;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        cam = this.gameObject.transform.GetChild(2).GetComponent<Camera>();

        m_interval = interval;
    }

    // Update is called once per frame
    void Update()
    {
        //移動処理
        Move();
        //回転処理
        Rotate();
        //ジャンプ処理
        Jump();
        //停止処理
        Stop();
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    void Move()
    {
        //moveXにコントローラーのパッドの左右の変位を格納
        var moveX = Input.GetAxis("Horizontal_" + playerNumber.ToString()) / 10 * move;
        //moveXにコントローラーのパッドの上下の変位を格納
        var moveZ = -Input.GetAxis("Vertical_" + playerNumber.ToString()) / 10 * move;
        //左右移動はmoveX、前後移動はmoveZの値で移動する
        transform.Translate(moveX, 0f, moveZ);

        //歩くモーションは止める
        animator.SetBool("isRunning", false);
        //移動しているなら
        if (moveX != 0 || moveZ != 0)
        {
            //歩くモーション
            animator.SetBool("isRunning", true);
        }
    }

    /// <summary>
    /// 回転処理
    /// </summary>
    void Rotate()
    {
        //コントローラーのパッドの変位で回転
        this.gameObject.transform.rotation = Input.GetAxis("HorizontalR_" + playerNumber.ToString()) != 0
            ? this.gameObject.transform.rotation * Quaternion.AngleAxis(Input.GetAxis("HorizontalR_" + playerNumber.ToString()) * move, Vector3.up)
            : transform.rotation;
    }

    /// <summary>
    /// ジャンプ処理
    /// </summary>
    void Jump()
    {
        //ボタン()が押されてかつジャンプ中でないとき
        if (Input.GetButtonDown("Fire1_" + playerNumber.ToString()) && isJump == false)
        {
            //ジャンプ
            rb.velocity = Vector3.up * jumpPower * move;
            //ジャンプモーション
            animator.SetBool("isJump", true);
            //ジャンプ中である
            isJump = true;
        }
    }
    
    void Stop()
    {
        var isStop = move == 0 ? true : false;

        if (isStop)
        {
            interval -= Time.deltaTime;
            if (interval <= 0)
            {
                move = 1;
                isStop = false;
            }
        }
        else
        {
            interval = m_interval;
        }
    }

    /// <summary>
    /// 衝突判定
    /// </summary>
    /// <param name="other"></param>
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            isJump = false;
            animator.SetBool("isJump", false);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (playerNumber == 1 && other.gameObject.tag == "BlueBullet")
        {
            move = 0;
        }
        if (playerNumber == 2 && other.gameObject.tag == "RedBullet")
        {
            move = 0;
        }
    }
}