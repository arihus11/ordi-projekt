using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ExitToMenu : MonoBehaviour, ISelectHandler
{
    public GameObject yesText2, noText2;
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
        this.gameObject.GetComponent<Button>().interactable = false;
        Time.timeScale = 1;
        GameObject.Find("Music").gameObject.GetComponent<AudioSource>().Stop();
        GameObject.Find("MeteorMusic").gameObject.GetComponent<AudioSource>().Stop();
        GameObject.Find("SoundManager").gameObject.GetComponent<AudioSource>().mute = true;
        GameObject.Find("ClosingPanelParent").gameObject.transform.GetChild(0).gameObject.SetActive(true);
        Invoke("changeSceneToMenu", 1.85f);
    }

    public void changeSceneToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnSelect(BaseEventData selected)
    {
        PauseMenu.mainSceneSelected = this.gameObject.GetComponent<Button>();
        yesText2.gameObject.GetComponent<Text>().color = Color.black;
        noText2.gameObject.GetComponent<Text>().color = Color.white;
        if (!(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
        {
            SoundManagerScript.PlaySound("button_switch");
        }
    }
}
