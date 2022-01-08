using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawNewCookie : MonoBehaviour
{
    private bool spawnOnlyOne;
    public GameObject newCookie;
    // Start is called before the first frame update
    void Start()
    {
        spawnOnlyOne = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LaikaHealth.movePlanets == true && this.gameObject.transform.childCount < 1)
        {
            if (spawnOnlyOne == false)
            {
                spawnOnlyOne = true;
                Instantiate(newCookie, transform.position, newCookie.transform.rotation, this.gameObject.transform);
                Invoke("revokeOnlyOne", 3f);
            }
        }
    }

    public void revokeOnlyOne()
    {
        spawnOnlyOne = false;
    }
}
