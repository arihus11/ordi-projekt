using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuBTNs : MonoBehaviour, ISelectHandler
{
    private bool pressed;
    public static Button selectedOne;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {

            selectedOne.Select();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        if (!pressed)
        {
            pressed = true;
            this.gameObject.GetComponent<Button>().interactable = false;
            Application.Quit();
        }
    }

    public void OnSelect(BaseEventData selected)
    {
        if (!(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
        {
            selectedOne = this.gameObject.GetComponent<Button>();
            SoundManagerScript.PlaySound("button_switch");
        }
    }

    public void CointinueGame()
    {
        if (!pressed && DisableContinueButton.disabledContinue == false)
        {
            pressed = true;
            this.gameObject.GetComponent<Button>().interactable = false;
            GameObject.Find("Music").gameObject.GetComponent<AudioSource>().Stop();
            SoundManagerScript.PlaySound("start");
            GameObject.Find("ClosingPanelParent").gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Invoke("changeSceneContinue", 1.85f);
        }

    }

    public void changeSceneContinue()
    {

        SceneManager.LoadScene("Main");

    }

    public void optionsButton()
    {
        SoundManagerScript.PlaySound("button_switch");
    }

    void Start()
    {
        pressed = false;
    }

}
