using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float timeRemaining = 20f;
    public float timePassed = 0f;
    public float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        Vector2 pos = transform.position;
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            pos.y += speed * Time.deltaTime;
        }
        transform.position = pos;
    }



}
