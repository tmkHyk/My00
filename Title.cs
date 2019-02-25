using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{

    public Text t1, t2;
    bool isOK_1, isOK_2;

    // Use this for initialization
    void Start()
    {
        t1 = this.gameObject.transform.GetChild(0). GetComponent<Text>();
        t1.color = Color.black;

        t2 = this.gameObject.transform.GetChild(1).GetComponent<Text>();
        t2.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1_1"))
        {
            t1.text = "OK!";
            t1.color = Color.red;
            isOK_1 = true;
        }
        if (Input.GetButtonDown("Fire1_2") || Input.GetKeyDown(KeyCode.Space))
        {
            t2.text = "OK!";
            t2.color = Color.blue;
            isOK_2 = true;
        }

        if (isOK_1 && isOK_2)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
