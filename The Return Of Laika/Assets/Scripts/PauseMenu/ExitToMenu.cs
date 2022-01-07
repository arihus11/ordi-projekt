using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExitToMenu : MonoBehaviour, ISelectHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExitToMainMenu()
    {
        SoundManagerScript.PlaySound("start");
        Time.timeScale = 1;
        GameObject.Find("ClosingPanelParent").gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Invoke("changeSceneToMenu", 1.85f);
    }

    public void changeSceneToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnSelect(BaseEventData selected)
    {
        SoundManagerScript.PlaySound("button_switch");
    }
}
