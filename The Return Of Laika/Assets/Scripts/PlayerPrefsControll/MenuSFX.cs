using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    void Update()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }
    }

    void Awake()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            AudioListener.volume = 0;
        }
    }
}
