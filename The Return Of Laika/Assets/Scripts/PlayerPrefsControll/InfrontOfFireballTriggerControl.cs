using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfrontOfFireballTriggerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Awake()
    {
        if (PlayerPrefs.GetInt("InfrontOfFireballTriggerPref") == 1)
        {
            this.gameObject.SetActive(false);
        }
    }

}
