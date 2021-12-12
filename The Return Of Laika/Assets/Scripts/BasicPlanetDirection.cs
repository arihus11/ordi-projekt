using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlanetDirection : MonoBehaviour
{
    public static string possiblePush;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "pushUp")
        {
            possiblePush = "up";
        }
        else if (col.gameObject.tag == "pushDown")
        {
            possiblePush = "down";
        }
        else if (col.gameObject.tag == "pushLeft")
        {
            possiblePush = "left";
        }
        else if (col.gameObject.tag == "pushRight")
        {
            possiblePush = "right";
        }
    }

    /* void OnTriggerExit2D(Collider2D col)
     {
         if (col.gameObject.tag == "pushUp" || col.gameObject.tag == "pushDown" || col.gameObject.tag == "pushRight" || col.gameObject.tag == "pushLeft")
         {
             possiblePush = "none";
         }
     } */
}
