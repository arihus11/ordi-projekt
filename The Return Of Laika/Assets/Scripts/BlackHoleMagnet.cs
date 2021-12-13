using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleMagnet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 holeDirection;
    float timeStamp;
    bool flyToHole;
    public float holeForce;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (flyToHole)
        {

            holeDirection = -(transform.position - (GameObject.FindGameObjectWithTag("blackHole").gameObject.transform.position)).normalized;
            rb.velocity = new Vector2(holeDirection.x, holeDirection.y) * holeForce * (Time.time / timeStamp);

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "blackHole")
        {
            timeStamp = Time.time;
            flyToHole = true;
        }
    }

}
