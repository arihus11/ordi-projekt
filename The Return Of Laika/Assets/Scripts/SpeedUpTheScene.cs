using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpTheScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Time.timeScale = 1.2F;
    }
}
