using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewGameBTNScript : MonoBehaviour, ISelectHandler
{
    private int counter = 0;
    private bool pressed = false;

    public void PlayGame()
    {
        if (!pressed)
        {
            pressed = true;
            this.gameObject.GetComponent<Button>().interactable = false;
            GameObject.Find("Music").gameObject.GetComponent<AudioSource>().Stop();
            SoundManagerScript.PlaySound("start");
            PlayerPrefs.SetInt("NewGamePressed", 1);
            PlayerPrefs.SetInt("BeforeMachinePickupTriggerPref", 0);
            PlayerPrefs.SetInt("InfrontOfMachineTriggerPref", 0);
            PlayerPrefs.SetInt("InfrontOfWreckTriggerPref", 0);
            PlayerPrefs.SetInt("InfrontOfShipPartTriggerPref", 0);
            PlayerPrefs.SetInt("InfrontOfBlackHoleTriggerPref", 0);
            PlayerPrefs.SetInt("InfrontOfFireballTriggerPref", 0);
            PlayerPrefs.SetInt("InfrontOfBasicPlanetTriggerPref", 0);
            PlayerPrefs.SetInt("BeginningCutscenePref", 0);

            PlayerPrefs.SetInt("ThrustMachinePickupPref", 0);
            PlayerPrefs.SetInt("FirstMeteorShowerPref", 0);
            GameObject.Find("ClosingPanelParent").gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Invoke("changeScene", 1.85f);
        }
    }

    public void QuitGame()
    {
        if (pressed == false)
        {
            pressed = true;
            SoundManagerScript.PlaySound("button_switch");
            Application.Quit();
        }
    }

    public void OnSelect(BaseEventData selected)
    {
        if (!(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
        {
            if (counter == 0)
            {
                counter = 1;
            }
            else
            {
                MenuBTNs.selectedOne = this.gameObject.GetComponent<Button>();
                SoundManagerScript.PlaySound("button_switch");
            }
        }
    }

    public void changeScene()
    {
        SceneManager.LoadScene("Cutscene1");
    }

    void Start()
    {
        pressed = false;
        MenuBTNs.selectedOne = this.gameObject.GetComponent<Button>();

    }

}
