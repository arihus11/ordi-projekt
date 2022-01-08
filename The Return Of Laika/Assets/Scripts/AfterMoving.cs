using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AfterMoving : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject dialogueBox2;
    public GameObject textBox2;
    public GameObject explosion;

    public GameObject spaceship;
    public Sprite brokenShip;
    private bool oneFlyOut;
    private bool oneRumble;

    // Start is called before the first frame update
    void Start()
    {
        oneRumble = false;
        oneFlyOut = false;
        textBox2.SetActive(false);
        dialogueBox2.SetActive(false);
        explosion.SetActive(false);
        this.gameObject.GetComponent<Animator>().enabled = false;
        Invoke("rumbleActions", 61f);
        Invoke("deactivateShaking", 70f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Invoke("stopTheMusic", 3f);
            GameObject.FindGameObjectWithTag("pressKeyToSkip").gameObject.SetActive(false);
            closeCutscene();
        }
    }

    public void stopTheMusic()
    {
        GameObject.Find("Music").gameObject.GetComponent<AudioSource>().Stop();
        GameObject.Find("SoundManager").gameObject.GetComponent<AudioSource>().Stop();
        GameObject.Find("ShipSoundManager").gameObject.GetComponent<AudioSource>().Stop();
    }

    public void rumbleActions()
    {

        GameObject.Find("Music").gameObject.GetComponent<AudioSource>().Pause();

        if (!oneRumble)
        {
            SoundManagerScript.PlaySound("cutscene_rumble");
        }
        dialogueBox2.SetActive(true);
        dialogueBox.SetActive(false);
        this.gameObject.GetComponent<CameraFollowPlayerScript>().enabled = false;
        // this.gameObject.GetComponent<Animator>().enabled = true;
        // this.gameObject.GetComponent<Animator>().Play("ShipShaking");
        spaceship.GetComponent<Animator>().Play("ShipShake");

    }

    public void deactivateShaking()
    {
        this.gameObject.GetComponent<Animator>().enabled = false;
        Invoke("explode", 2f);
    }

    public void explode()
    {
        explosion.SetActive(true);
        GameObject.FindGameObjectWithTag("shipRawSprite").gameObject.GetComponent<SpriteRenderer>().sprite = brokenShip;
        GameObject.FindGameObjectWithTag("realShip").gameObject.transform.GetChild(1).gameObject.SetActive(true);
        blowUpSound();
        Invoke("laikaFlyOut", 0.1f);
        Invoke("beginTypingAgain", 3f);
    }

    public void laikaFlyOut()
    {
        spaceship.GetComponent<Animator>().Play("LaikaBlownUp");
        GameObject.FindGameObjectWithTag("shipRawSprite").gameObject.GetComponent<Animator>().Play("ShipFlyAway");

    }

    public void blowUpSound()
    {
        if (!oneFlyOut)
        {
            SoundManagerScript.PlaySound("ship_explosion");
            oneFlyOut = true;
        }
    }


    public void beginTypingAgain()
    {
        textBox2.SetActive(true);
        Invoke("closeCutscene", 11f);
    }

    public void closeCutscene()
    {
        GameObject.FindGameObjectWithTag("cosingPanel").gameObject.GetComponent<Animator>().Play("closeCutscene1");
        Invoke("stopTheMusic", 3f);
        Invoke("changeToMain", 4.0f);
    }

    public void changeToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
