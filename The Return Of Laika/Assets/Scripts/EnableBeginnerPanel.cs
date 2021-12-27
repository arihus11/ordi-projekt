using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBeginnerPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("disableBeginnerPanel", 3.5f);
    }

    public void disableBeginnerPanel()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
