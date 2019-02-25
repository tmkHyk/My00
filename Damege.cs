using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Damege : MonoBehaviour
{

    CharacterControl chara;
    Image image;

    // Use this for initialization
    void Start()
    {
        chara = this.gameObject.transform.parent.transform.parent.GetComponent<CharacterControl>();
        image = GetComponent<Image>();
    }

    public bool isStop;
    // Update is called once per frame
    void Update()
    {
        isStop = chara.move == 1 ? false : true;

        image.enabled = isStop;
    }
}
