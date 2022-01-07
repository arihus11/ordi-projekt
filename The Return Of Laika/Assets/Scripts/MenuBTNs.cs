using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuBTNs : MonoBehaviour, ISelectHandler
{

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnSelect(BaseEventData selected)
    {
        SoundManagerScript.PlaySound("button_switch");
    }

    public void CointinueGame()
    {
        SoundManagerScript.PlaySound("start");
        GameObject.Find("ClosingPanelParent").gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Invoke("changeSceneContinue", 1.85f);
    }

    public void changeSceneContinue()
    {
        SceneManager.LoadScene("Main");
    }

    public void optionsButton()
    {
        SoundManagerScript.PlaySound("button_switch");
    }

}
