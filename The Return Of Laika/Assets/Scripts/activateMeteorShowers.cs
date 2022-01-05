using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateMeteorShowers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GrabShipPart.firstGrabEver == false)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (GrabShipPart.firstGrabEver == true)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

        if (LaikaHealth.gameOver == true)
        {
            Destroy(this.gameObject);
        }
    }
}
