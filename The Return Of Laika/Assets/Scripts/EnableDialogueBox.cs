using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDialogueBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        Invoke("enableTextBox", 13f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void enableTextBox()
    {
        this.gameObject.SetActive(true);
    }
}
