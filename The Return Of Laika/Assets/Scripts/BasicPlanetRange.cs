using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlanetRange : MonoBehaviour
{
    public static bool insidePlanetRange1, insidePlanetRange2, insidePlanetRange3, insidePlanetRange4, insidePlanetRange5, insidePlanetRange6;
    // Start is called before the first frame update
    void Start()
    {
        insidePlanetRange1 = false;
        insidePlanetRange2 = false;
        insidePlanetRange3 = false;
        insidePlanetRange4 = false;
        insidePlanetRange5 = false;
        insidePlanetRange6 = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "basicplanet1")
        {
            insidePlanetRange1 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet2")
        {
            insidePlanetRange2 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet3")
        {
            insidePlanetRange3 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet4")
        {
            insidePlanetRange4 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet5")
        {
            insidePlanetRange5 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet6")
        {
            insidePlanetRange6 = true;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("PushHintDisplay", -1, 0f);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "basicplanet1")
        {
            insidePlanetRange1 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet2")
        {
            insidePlanetRange2 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet3")
        {
            insidePlanetRange3 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet4")
        {
            insidePlanetRange4 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet5")
        {
            insidePlanetRange5 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
        else if (col.gameObject.tag == "basicplanet6")
        {
            insidePlanetRange6 = false;
            GameObject.Find("PushHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
    }
}
