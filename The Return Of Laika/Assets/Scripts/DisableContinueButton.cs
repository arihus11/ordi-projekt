using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableContinueButton : MonoBehaviour
{
    public static bool disabledContinue;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("NewGamePressed") == 0)
        {
            disabledContinue = true;
            this.gameObject.GetComponent<Image>().color = new Color32(140, 137, 137, 255);
        }
        else if (PlayerPrefs.GetInt("NewGamePressed") == 1)
        {
            disabledContinue = false;
            this.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
