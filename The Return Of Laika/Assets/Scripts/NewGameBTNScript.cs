using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewGameBTNScript : MonoBehaviour, ISelectHandler
{
    private int counter = 0;

    public void PlayGame()
    {
        GameObject.Find("Music").gameObject.GetComponent<AudioSource>().Stop();
        SoundManagerScript.PlaySound("start");
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

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnSelect(BaseEventData selected)
    {
        if (counter == 0)
        {
            counter = 1;
        }
        else
        {
            SoundManagerScript.PlaySound("button_switch");
        }
    }

    public void changeScene()
    {
        SceneManager.LoadScene("Cutscene1");
    }

}
