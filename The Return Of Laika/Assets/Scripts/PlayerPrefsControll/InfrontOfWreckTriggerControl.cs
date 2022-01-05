using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfrontOfWreckTriggerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("InfrontOfWreckTriggerPref") == 1)
        {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
