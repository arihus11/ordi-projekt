using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool oneSwitchSound;
    // Start is called before the first frame update
    void Start()
    {
        oneSwitchSound = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (!oneSwitchSound)
            {
                SoundManagerScript.PlaySound("button_switch");
                oneSwitchSound = true;
            }
            Time.timeScale = 0;
            GameObject.Find("PauseMenu").gameObject.transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("PauseMenu").gameObject.transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("PauseMenu").gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}
