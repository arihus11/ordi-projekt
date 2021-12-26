using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyThisBullet", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void destroyThisBullet()
    {
        Destroy(this.gameObject);
    }
}
