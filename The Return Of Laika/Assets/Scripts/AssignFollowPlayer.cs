using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignFollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<CameraFollowPlayerScript>().enabled = false;
        Invoke("AssignPlayer", 15.8f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AssignPlayer()
    {
        this.gameObject.GetComponent<CameraFollowPlayerScript>().enabled = true;
    }
}
