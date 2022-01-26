using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContinueGame : MonoBehaviour, ISelectHandler
{
    public GameObject yesText, noText;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.mainSceneSelected = this.gameObject.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ContinueGameButton()
    {
        Time.timeScale = 1;
        if (MeteorShowerSpawner.meteorMusicPlaying == true)
        {
            GameObject.Find("MeteorMusic").gameObject.GetComponent<AudioSource>().Play();
            GameObject.Find("SoundManager").gameObject.GetComponent<AudioSource>().Play();
        }
        else if (MeteorShowerSpawner.meteorMusicPlaying == false)
        {
            GameObject.Find("Music").gameObject.GetComponent<AudioSource>().Play();
            GameObject.Find("SoundManager").gameObject.GetComponent<AudioSource>().Play();
        }

        PauseMenu.oneSwitchSound = false;
        GameObject.Find("PauseMenu").gameObject.transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("PauseMenu").gameObject.transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("PauseMenu").gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void OnSelect(BaseEventData selected)
    {
        PauseMenu.mainSceneSelected = this.gameObject.GetComponent<Button>();
        noText.gameObject.GetComponent<Text>().color = Color.black;
        yesText.gameObject.GetComponent<Text>().color = Color.white;
        if (!(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
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
    }
}
