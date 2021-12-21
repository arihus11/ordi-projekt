using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDialogueBox : MonoBehaviour
{
    public float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyThisBox", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void destroyThisBox()
    {
        Destroy(this.gameObject);
    }
}
