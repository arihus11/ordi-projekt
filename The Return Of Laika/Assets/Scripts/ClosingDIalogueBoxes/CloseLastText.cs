using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseLastText : MonoBehaviour
{
    public float closeTextTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("closeLastText", closeTextTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void closeLastText()
    {
        Destroy(this.gameObject);
    }
}
