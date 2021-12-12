using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LaikaHealth : MonoBehaviour
{
    public static int health = 5;
    private bool isWaiting = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("LAIKA HEALTH: " + health.ToString());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Glow")
        {
            if (isWaiting == false)
            {
                health--;
                showWhenHurt();
                Debug.Log("LAIKA HEALTH: " + health.ToString());
                StartCoroutine(DamageForTwoSeconds());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "powerUp")
        {
            if (health == 5)
            {
                GameObject.Find("PowerUpMessageContainer").gameObject.GetComponent<Animator>().Play("PowerUpNotSick", -1, 0f);
            }
            else if (health < 5)
            {
                GameObject.Find("PowerUpMessageContainer").gameObject.GetComponent<Animator>().Play("PowerUpSick", -1, 0f);
                health++;
                Debug.Log("LAIKA HEALTH: " + health.ToString());
                Destroy(col.gameObject);
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

}
