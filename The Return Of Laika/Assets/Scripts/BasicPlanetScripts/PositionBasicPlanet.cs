using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBasicPlanet : MonoBehaviour
{
    private Vector3 planetPosition;
    // Start is called before the first frame update
    void Start()
    {
        planetPosition = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (LaikaHealth.movePlanets == true)
        {

            this.gameObject.transform.position = planetPosition;

        }
    }

}
