using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDialogueBox : MonoBehaviour
{
    public float disableTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("disableThisBox", disableTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void disableThisBox()
    {
        this.gameObject.SetActive(false);
    }
}

