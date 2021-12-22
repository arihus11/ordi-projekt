using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollide : MonoBehaviour
{
    public static bool collidedOnChild;
    // Start is called before the first frame update
    void Start()
    {
        collidedOnChild = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "meteor")
        {
            if (LaikaHealth.gameOver == false)
            {
                collidedOnChild = true;
                GameObject.Find("MeteorExplosionShield").gameObject.GetComponent<Animator>().Play("Explosion1", -1, 0f);
                Invoke("changeState", 0.5f);
                Destroy(col.gameObject);

            }
        }

    }

    public void changeState()
    {
        collidedOnChild = false;
    }

}
