using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuBTNs2 : MonoBehaviour, ISelectHandler
{
    private int counter = 0;

    public void PlayGame()
    {
        SoundManagerScript.PlaySound("start");
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnSelect(BaseEventData selected)
    {
        if (counter == 0) {
            counter = 1;
        } else {
            SoundManagerScript.PlaySound("button_switch");
        }    
    }

}
