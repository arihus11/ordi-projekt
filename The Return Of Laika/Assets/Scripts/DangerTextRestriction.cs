using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerTextRestriction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((GameObject.FindGameObjectWithTag("shower1") != null || GameObject.FindGameObjectWithTag("shower2") != null))
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
