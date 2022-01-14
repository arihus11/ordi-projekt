using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenuButtonsControler : MonoBehaviour
{
    public static string selectedButtonOptions;
    private bool oneChange1;
    public GameObject Text1;
    // Start is called before the first frame update
    void Start()
    {
        calculatePrefs();
        oneChange1 = false;
        selectedButtonOptions = "Music";
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedButtonOptions == "Music")
        {
            Text1.gameObject.GetComponent<Text>().color = Color.white;
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                if (Text1.gameObject.GetComponent<Text>().text == "OFF")
                {
                    if (!oneChange1)
                    {
                        oneChange1 = true;
                        SoundManagerScript.PlaySound("button_switch");
                        Text1.gameObject.GetComponent<Text>().text = "ON";
                        PlayerPrefs.SetInt("Sound", 0);
                        Invoke("changeSwitchTrue", 0.2f);
                    }
                }
                else if (Text1.gameObject.GetComponent<Text>().text == "ON")
                {
                    if (!oneChange1)
                    {
                        oneChange1 = true;
                        SoundManagerScript.PlaySound("button_switch");
                        PlayerPrefs.SetInt("Sound", 1);
                        Text1.gameObject.GetComponent<Text>().text = "OFF";
                        Invoke("changeSwitchTrue", 0.2f);
                    }
                }
            }
        }
        else if (selectedButtonOptions == "ExitOptions")
        {
            Text1.gameObject.GetComponent<Text>().color = Color.black;
        }
    }

    public void changeSwitchTrue()
    {
        oneChange1 = false;
    }

    public void calculatePrefs()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            Text1.gameObject.GetComponent<Text>().text = "ON";
        }
        else if (PlayerPrefs.GetInt("Sound") == 1)
        {
            Text1.gameObject.GetComponent<Text>().text = "OFF";
        }
    }
}
