using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlanetPush6 : MonoBehaviour
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
            if (BasicPlanetRange.insidePlanetRange6 == true && GrabShipPart.holdingPart == false)
            {
                if (BasicPlanetDirection.possiblePush == "up")
                {
                    unfreezeConstraints();
                    SoundManagerScript.PlaySound("push_planet");
                    Vector2 pos = transform.position;
                    rb.AddForce(transform.up * force, ForceMode2D.Impulse);
                    transform.position = pos;

                    Invoke("freezeConstraints", 0.5f);
                }
                else if (BasicPlanetDirection.possiblePush == "down")
                {
                    unfreezeConstraints();
                    SoundManagerScript.PlaySound("push_planet");
                    Vector2 pos = transform.position;
                    rb.AddForce(transform.up * (-force), ForceMode2D.Impulse);
                    transform.position = pos;

                    Invoke("freezeConstraints", 0.5f);
                }
                else if (BasicPlanetDirection.possiblePush == "left")
                {
                    unfreezeConstraints();
                    SoundManagerScript.PlaySound("push_planet");
                    Vector2 pos = transform.position;
                    rb.AddForce(transform.right * (-force), ForceMode2D.Impulse);
                    transform.position = pos;

                    Invoke("freezeConstraints", 0.5f);
                }
                else if (BasicPlanetDirection.possiblePush == "right")
                {
                    unfreezeConstraints();
                    SoundManagerScript.PlaySound("push_planet");
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