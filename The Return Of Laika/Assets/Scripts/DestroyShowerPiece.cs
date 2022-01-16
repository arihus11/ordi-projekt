using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyShowerPiece : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "lastMeteorTrigger")
        {
            GameObject.Find("DangerMessageContainer").gameObject.transform.GetChild(0).gameObject.SetActive(false);
            GameObject.Find("MeteorMusic").gameObject.GetComponent<AudioSource>().Stop();
            MeteorShowerSpawner.meteorMusicPlaying = false;
            GameObject.Find("Music").gameObject.GetComponent<AudioSource>().Play();
            MeteorShowerSpawner.meteorShowerActive = false;
            Destroy(this.gameObject.transform.parent.parent.parent.parent.gameObject);
        }
    }
}
