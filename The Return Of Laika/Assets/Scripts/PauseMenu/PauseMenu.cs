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
                oneSwitchSound = true;
                SoundManagerScript.PlaySound("button_switch");
                GameObject.Find("Music").gameObject.GetComponent<AudioSource>().Pause();
                try
                {
                    GameObject.Find("MeteorMusic").gameObject.GetComponent<AudioSource>().Pause();
                }
                catch (System.NullReferenceException)
                {
                    Debug.Log("Meteor sound not active");
                }
            }
            Time.timeScale = 0;
            GameObject.Find("PauseMenu").gameObject.transform.GetChild(0).gameObject.SetActive(true);
            GameObject.Find("PauseMenu").gameObject.transform.GetChild(1).gameObject.SetActive(true);
            GameObject.Find("PauseMenu").gameObject.transform.GetChild(2).gameObject.SetActive(true);
        }
    }
}
