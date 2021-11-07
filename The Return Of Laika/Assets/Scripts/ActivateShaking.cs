using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShaking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("activateShaking", 10f);
        Invoke("deactivate", 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void acitvateShaking()
    {
        this.gameObject.GetComponent<Animator>().Play("ShipShaking");
    }

    public void deactivateShaking()
    {
        this.gameObject.GetComponent<Animator>().enabled = false;
    }
}
