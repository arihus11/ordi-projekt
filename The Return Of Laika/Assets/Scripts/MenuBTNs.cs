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

}
