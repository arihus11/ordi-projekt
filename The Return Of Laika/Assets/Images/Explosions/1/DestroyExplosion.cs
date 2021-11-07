using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyExpl", 0.6f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void destroyExpl()
    {
        Destroy(this.gameObject);
    }
}
