using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            this.gameObject.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            this.gameObject.GetComponent<AudioSource>().mute = false;
        }
    }

    void Awake()
    {
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            this.gameObject.GetComponent<AudioSource>().mute = true;
        }
    }
}
