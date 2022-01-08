using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShower : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyThisShower", 19f);
    }

    // Update is called once per frame
    void Update()
    {
        if (LaikaHealth.gameOver == true)
        {
            Destroy(this.gameObject);
        }
    }

    public void destroyThisShower()
    {

        GameObject.Find("DangerMessageContainer").gameObject.transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("MeteorMusic").gameObject.GetComponent<AudioSource>().Stop();
        GameObject.Find("Music").gameObject.GetComponent<AudioSource>().Play();
        MeteorShowerSpawner.meteorShowerActive = false;
        Destroy(this.gameObject);
    }
}
