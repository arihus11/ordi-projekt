using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMenuPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destoryThisPanel", 1.9f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void destoryThisPanel()
    {
        Destroy(this.gameObject);
    }
}
