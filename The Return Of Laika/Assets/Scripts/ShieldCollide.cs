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
                SoundManagerScript.PlaySound("meteor_shield");
                //   collidedOnChild = true;
                if (col.contacts[0].otherCollider.tag == "rightShield")
                {
                    //       GameObject.Find("MeteorExplosionShield").gameObject.GetComponent<Animator>().Play("Explosion1", -1, 0f);
                    this.gameObject.GetComponent<Animator>().Play("ShieldHit", -1, 0f);
                }
                else if (col.contacts[0].otherCollider.tag == "leftShield")
                {
                    //      GameObject.Find("MeteorExplosionShield2").gameObject.GetComponent<Animator>().Play("Explosion1", -1, 0f);
                    this.gameObject.GetComponent<Animator>().Play("ShieldHit", -1, 0f);
                }
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
