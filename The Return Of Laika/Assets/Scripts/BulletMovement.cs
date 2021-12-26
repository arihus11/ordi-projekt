using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody2D rbBullet;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rbBullet = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        pos.y += bulletSpeed * Time.deltaTime;
        transform.position = pos;
    }
}
