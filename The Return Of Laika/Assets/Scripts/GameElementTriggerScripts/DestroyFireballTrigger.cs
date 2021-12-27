using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireballTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EnableMonologue.destroyFireballTriggers == true)
        {
            Invoke("destroyAfterText2", 7.7f);
        }
    }

    public void destroyAfterText2()
    {
        Destroy(this.gameObject);
    }
}
