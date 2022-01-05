using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShowerMainParent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (AssembleShipPart.numberOfPartsAssambled == 5)
        {
            Destroy(this.gameObject);
        }
    }
}
