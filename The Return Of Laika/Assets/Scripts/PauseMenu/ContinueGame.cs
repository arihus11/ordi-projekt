using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContinueGame : MonoBehaviour, ISelectHandler
{
    public GameObject yesText, noText;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ContinueGameButton()
    {
        Time.timeScale = 1;
        PauseMenu.oneSwitchSound = false;
        GameObject.Find("PauseMenu").gameObject.transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("PauseMenu").gameObject.transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("PauseMenu").gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void OnSelect(BaseEventData selected)
    {
        noText.gameObject.GetComponent<Text>().color = Color.white;
        yesText.gameObject.GetComponent<Text>().color = Color.black;
        if (counter == 0)
        {
            counter = 1;
        }
        else
        {
            SoundManagerScript.PlaySound("button_switch");
        }
    }
}
