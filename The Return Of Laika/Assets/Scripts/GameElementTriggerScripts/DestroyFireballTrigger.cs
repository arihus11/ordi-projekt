using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireballTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DestroyTriggers.destroyFireballTriggers == true)
        {
            Invoke("destroyAfterText2", 7.9f);
        }
    }

    public void destroyAfterText2()
    {
        PlayerPrefs.SetInt("InfrontOfFireballTriggerPref", 1);
        Destroy(this.gameObject);
    }
}
