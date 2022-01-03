using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LaikaHealth : MonoBehaviour
{
    public static int health = 5;
    private bool isWaiting = false;
    public static bool gameOver;
    private Rigidbody2D rb;
    Vector2 startDirection;
    float timeStamp;
    private bool doOnce, doOnce2;

    [Header("Health Display")]
    public GameObject healthSystemCanvas;
    public Sprite fullHealthPointSprite;
    public Sprite emptyHealthPointSprite;
    private Transform healthSystem;


    // Start is called before the first frame update
    void Start()
    {
        doOnce = false;
        doOnce2 = false;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        gameOver = false;
        setHealth(5);
        healthSystem = healthSystemCanvas.transform;
    }

    // Update is called once per frame
    void Update()
    {
        updateHealthDisplay();
        if (health == 0)
        {
            GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().enabled = false;
            gameOver = true;
            this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            GameObject.FindGameObjectWithTag("gameOverCanvas").gameObject.GetComponent<Animator>().Play("DisplayGameOverText1");
            Invoke("reverseDisplayGameOver", 4.5f);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Glow")
        {
            if (gameOver == false)
            {
                if (isWaiting == false)
                {
                    SoundManagerScript.PlaySound("damage");
                    setHealth(health - 1);
                    showWhenHurt();
                    Debug.Log("LAIKA HEALTH: " + health.ToString());
                    StartCoroutine(DamageForTwoSeconds());
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "powerUp")
        {
            if (gameOver == false)
            {
                if (health == 5)
                {
                    GameObject.Find("PowerUpMessageContainer").gameObject.GetComponent<Animator>().Play("PowerUpNotSick", -1, 0f);
                }
                else if (health < 5)
                {
                    SoundManagerScript.PlaySound("eat");
                    GameObject.Find("PowerUpMessageContainer").gameObject.GetComponent<Animator>().Play("PowerUpSick", -1, 0f);
                    setHealth(health + 1);
                    Debug.Log("LAIKA HEALTH: " + health.ToString());
                    Destroy(col.gameObject);
                }
            }
        }
    }

    IEnumerator DamageForTwoSeconds()
    {
        isWaiting = true;
        yield return new WaitForSecondsRealtime(2);
        isWaiting = false;
    }

    public void showWhenHurt()
    {
        GameObject.FindGameObjectWithTag("blood").gameObject.GetComponent<Animator>().Play("BloodAnim", -1, 0f);
        if (RandomAnimGenerator.randomNumber == 1)
        {

            GameObject.Find("HurtMessageContainer").gameObject.GetComponent<Animator>().Play("OuchDisplay", -1, 0f);
            RandomAnimGenerator.calculateRandomNumber();
        }
        else
        {
            GameObject.Find("HurtMessageContainer").gameObject.GetComponent<Animator>().Play("ThatHurtsDisplay", -1, 0f);
            RandomAnimGenerator.calculateRandomNumber();
        }
    }

    public void reverseDisplayGameOver()
    {
        GameObject.FindGameObjectWithTag("gameOverCanvas").gameObject.GetComponent<Animator>().Play("DisplayGameOverText1Reverse");
        setHealth(5);
        Invoke("laikaDisapear", 1.3f);
        Invoke("moveLaikaBackInTime", 2f);

    }

    public void moveLaikaBackInTime()
    {
        if (doOnce2 == false)
        {
            this.gameObject.transform.position = GameObject.FindGameObjectWithTag("startPosition").gameObject.transform.position;
            Invoke("makeEverythingNormal", 2f);
            doOnce2 = true;
        }
    }

    public void laikaDisapear()
    {
        if (doOnce == false)
        {
            this.gameObject.GetComponent<Animator>().Play("LaikaDisapear");
            doOnce = true;
        }
    }

    public void makeEverythingNormal()
    {
        gameOver = false;
        this.gameObject.GetComponent<Animator>().Play("LaikaFloatInSpace");
        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().enabled = true;
        Invoke("changeSwitches", 4f);
    }

    public void changeSwitches()
    {
        doOnce = false;
        doOnce2 = false;
    }

    private void setHealth(int newHealth)
    {
        health = newHealth;

    }

    public void updateHealthDisplay()
    {
        for (int i = 1; i <= healthSystem.childCount; i++)
        {
            healthSystem
                .GetChild(i - 1)
                .Find("Sprite")
                .GetComponent<SpriteRenderer>()
                .sprite = i <= health ? fullHealthPointSprite : emptyHealthPointSprite;
        }
    }
}
