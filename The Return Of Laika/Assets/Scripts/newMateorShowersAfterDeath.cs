using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newMateorShowersAfterDeath : MonoBehaviour
{
    public GameObject theOneToSpawn;
    private bool oneSpawn;
    // Start is called before the first frame update
    void Start()
    {
        oneSpawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.childCount == 0 && AssembleShipPart.numberOfPartsAssambled < 5)
        {
            if (oneSpawn == false)
            {
                Instantiate(theOneToSpawn, transform.position, theOneToSpawn.transform.rotation, this.gameObject.transform);
                //   Invoke("changeOneSpawn", 1.5f);
            }

        }
    }

    public void changeOneSpawn()
    {
        oneSpawn = true;
    }
}
