using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTriggers : MonoBehaviour
{
    public static bool destroyHoleTriggers, destroyFireballTriggers, destroyBasicPlanetTriggers, destroyShipPartTriggers;
    // Start is called before the first frame update
    void Start()
    {
        destroyHoleTriggers = false;
        destroyFireballTriggers = false;
        destroyBasicPlanetTriggers = false;
        destroyShipPartTriggers = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
