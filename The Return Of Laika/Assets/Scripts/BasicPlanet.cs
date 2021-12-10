using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlanet : MonoBehaviour
{
    public static bool insidePlanetRange;
    // Start is called before the first frame update
    void Start()
    {
        insidePlanetRange = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "basicPlanet")
        {
            insidePlanetRange = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "basicPlanet")
        {
            insidePlanetRange = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
    }
}
