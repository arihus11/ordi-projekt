using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleMagnet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 holeDirection;
    float timeStamp;
    bool flyToHole;
    private Vector2 hole;
    public float holeForce;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float step = holeForce * Time.deltaTime;
        if (flyToHole)
        {
            holeDirection = -(transform.position - (GameObject.FindGameObjectWithTag("blackHole").gameObject.transform.position)).normalized;
            transform.position = Vector2.MoveTowards(transform.position, hole, step);
            //rb.velocity = new Vector2(holeDirection.x, holeDirection.y) * holeForce * (Time.time / timeStamp);

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "blackHole")
        {
            hole = col.gameObject.transform.position;
            timeStamp = Time.time;
            flyToHole = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "blackHole")
        {
            flyToHole = false;
        }
    }

}
