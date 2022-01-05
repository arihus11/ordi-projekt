using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NewGameBTNScript : MonoBehaviour, ISelectHandler
{
    private int counter = 0;
    public Sprite NotSelected;
    public Sprite Selected;

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
        GameObject.Find("Sprite").gameObject.GetComponent<SpriteRenderer>().sprite = Selected;
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
