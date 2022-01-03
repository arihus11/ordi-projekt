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
