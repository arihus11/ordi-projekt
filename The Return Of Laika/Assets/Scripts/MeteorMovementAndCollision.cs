using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovementAndCollision : MonoBehaviour
{
    public float speed = 3f;
    private float extraSpeed = 0.8f;
    public int movementDirection;
    private int randomSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        if (movementDirection == 0)
        {
            pos.x += -speed / extraSpeed * Time.deltaTime;
            pos.y += -speed / extraSpeed * Time.deltaTime;
        }
        else if (movementDirection == 1)
        {
            pos.x += speed / extraSpeed * Time.deltaTime;
            pos.y += -speed / extraSpeed * Time.deltaTime;
        }
        transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Laika")
        {
            if (LaikaHealth.gameOver == false)
            {
                if (col.contacts[0].collider.tag == "Laika")
                {
                    Destroy(this.gameObject);
                    showWhenHurt();
                    GameObject.Find("MeteorExplosion").gameObject.GetComponent<Animator>().Play("Explosion1", -1, 0f);
                    LaikaHealth.health--;
                    Debug.Log("LAIKA HEALTH: " + LaikaHealth.health.ToString());
                    //   Debug.Log("HIT LAIKA");
                }
            }
        }
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
