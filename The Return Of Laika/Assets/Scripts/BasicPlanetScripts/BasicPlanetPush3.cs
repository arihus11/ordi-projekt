using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlanetPush3 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float force = 20f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        freezeConstraints();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (BasicPlanetRange.insidePlanetRange3 == true)
            {
                if (BasicPlanetDirection.possiblePush == "up")
                {
                    unfreezeConstraints();

                    Vector2 pos = transform.position;
                    rb.AddForce(transform.up * force, ForceMode2D.Impulse);
                    transform.position = pos;

                    Invoke("freezeConstraints", 0.5f);
                }
                else if (BasicPlanetDirection.possiblePush == "down")
                {
                    unfreezeConstraints();

                    Vector2 pos = transform.position;
                    rb.AddForce(transform.up * (-force), ForceMode2D.Impulse);
                    transform.position = pos;

                    Invoke("freezeConstraints", 0.5f);
                }
                else if (BasicPlanetDirection.possiblePush == "left")
                {
                    unfreezeConstraints();

                    Vector2 pos = transform.position;
                    rb.AddForce(transform.right * (-force), ForceMode2D.Impulse);
                    transform.position = pos;

                    Invoke("freezeConstraints", 0.5f);
                }
                else if (BasicPlanetDirection.possiblePush == "right")
                {
                    unfreezeConstraints();

                    Vector2 pos = transform.position;
                    rb.AddForce(transform.right * force, ForceMode2D.Impulse);
                    transform.position = pos;

                    Invoke("freezeConstraints", 0.5f);
                }
            }
        }
    }

    public void freezeConstraints()
    {
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    public void unfreezeConstraints()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


}
