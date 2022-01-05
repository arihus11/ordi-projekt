using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShipPartTriggers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EnableMonologue.destroyShipPartTriggers == true)
        {
            Invoke("destroyAfterText9", 9.8f);
        }
    }

    public void destroyAfterText9()
    {
        PlayerPrefs.SetInt("InfrontOfShipPartTriggerPref", 1);
        Destroy(this.gameObject);
    }
}
