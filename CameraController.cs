using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    GameObject player;
    GameObject bulletPos;

    CharacterControl chara;

    // Use this for initialization
    void Start()
    {
        player = this.gameObject.transform.parent.gameObject;
        bulletPos = transform.GetChild(0).gameObject;

        chara = player.GetComponent<CharacterControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chara.move != 0)
        {
            Rotate();
        }
    }

    void Rotate()
    {
        //カメラの上下回転
        transform.rotation = Input.GetAxis("VerticalR_" + chara.playerNumber.ToString()) != 0
            ? this.gameObject.transform.rotation * Quaternion.AngleAxis(Input.GetAxis("VerticalR_" + chara.playerNumber.ToString()), Vector3.right)
            : transform.rotation;

        var rot = transform.localEulerAngles.x <= 180
            ? transform.localEulerAngles.x
            : transform.localEulerAngles.x - 360;

        bulletPos.transform.rotation = Quaternion.Euler(Mathf.Clamp(rot, -25, 25), player.transform.localEulerAngles.y, 0);

        transform.rotation = Quaternion.Euler(Mathf.Clamp(rot, -25, 25), player.transform.localEulerAngles.y, 0);
    }
}