using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHoleTriggers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EnableMonologue.destroyHoleTriggers == true)
        {
            Invoke("destroyAfterText", 7.7f);
        }
    }

    public void destroyAfterText()
    {
        PlayerPrefs.SetInt("InfrontOfBlackHoleTriggerPref", 1);
        Destroy(this.gameObject);
    }
}
