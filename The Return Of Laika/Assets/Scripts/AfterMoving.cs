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

    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.anyKey)
        {
            closeCutscene();
        }
    }

    public void rumbleActions()
    {
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
        laikaFlyOut();
        Invoke("beginTypingAgain", 3f);
    }

    public void laikaFlyOut()
    {
        spaceship.GetComponent<Animator>().Play("LaikaBlownUp");
    }

    public void beginTypingAgain()
    {
        textBox2.SetActive(true);
        Invoke("closeCutscene", 11f);
    }

    public void closeCutscene()
    {
        GameObject.FindGameObjectWithTag("cosingPanel").gameObject.GetComponent<Animator>().Play("closeCutscene1");
        Invoke("changeToMain", 4.0f);
    }

    public void changeToMain()
    {
        SceneManager.LoadScene("Main");
    }
}
