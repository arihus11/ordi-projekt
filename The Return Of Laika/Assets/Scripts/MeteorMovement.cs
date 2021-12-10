using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    public float speed = 3f;
    private int randomSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.x += -speed * Time.deltaTime;
        pos.y += -speed * Time.deltaTime;
        transform.position = pos;
    }
}
