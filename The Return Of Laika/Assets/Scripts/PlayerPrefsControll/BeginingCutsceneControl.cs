using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginingCutsceneControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("BeginningCutscenePref") == 1)
        {
            this.gameObject.GetComponent<BeginningCutscene>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

}
