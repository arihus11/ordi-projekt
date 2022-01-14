using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushToGrab : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "bp1" || col.gameObject.tag == "bp2" || col.gameObject.tag == "bp3" || col.gameObject.tag == "bp4" || col.gameObject.tag == "bp5" || col.gameObject.tag == "bp6" || col.gameObject.tag == "bp7" || col.gameObject.tag == "bp8" || col.gameObject.tag == "bp9" || col.gameObject.tag == "bp10" || col.gameObject.tag == "bp11" || col.gameObject.tag == "bp12" || col.gameObject.tag == "bp13")
        {
            if (this.gameObject.transform.parent.gameObject.GetComponent<CircleCollider2D>() != null)
            {
                try
                {
                    this.gameObject.transform.parent.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                }
                catch (MissingComponentException)
                {
                    Debug.Log("Ignore Exception");
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "bp1" || col.gameObject.tag == "bp2" || col.gameObject.tag == "bp3" || col.gameObject.tag == "bp4" || col.gameObject.tag == "bp5" || col.gameObject.tag == "bp6" || col.gameObject.tag == "bp7" || col.gameObject.tag == "bp8" || col.gameObject.tag == "bp9" || col.gameObject.tag == "bp10" || col.gameObject.tag == "bp11" || col.gameObject.tag == "bp12" || col.gameObject.tag == "bp13")
        {
            this.gameObject.transform.parent.gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
