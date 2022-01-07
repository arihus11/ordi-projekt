using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBasicPlanetTriggers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DestroyTriggers.destroyBasicPlanetTriggers == true)
        {
            Invoke("destroyAfterText3", 7.9f);
        }
    }

    public void destroyAfterText3()
    {
        PlayerPrefs.SetInt("InfrontOfBasicPlanetTriggerPref", 1);
        Destroy(this.gameObject);
    }
}
