using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            AudioListener.volume = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
