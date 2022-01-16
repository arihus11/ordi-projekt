using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorShowerSpawner : MonoBehaviour
{
    public GameObject shower1, shower2;
    public static bool meteorShowerActive;
    public static bool destroyMeteorsGameOver;
    public static bool meteorMusicPlaying;
    public float maxTime = 75f;
    public float minTime = 55f;


    //current time
    private float time;
    //The time to spawn the object
    private float spawnTime;
    private bool setOneTime;
    private int randomShowerNumber;
    // Start is called before the first frame update
    void Start()
    {
        setOneTime = false;
        destroyMeteorsGameOver = false;
        meteorShowerActive = false;
        meteorMusicPlaying = false;
        time = minTime;
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        if (GrabShipPart.firstGrabEver == true)
        {
            if (!setOneTime)
            {
                SetRandomTime();
            }
        }

        //Check if its the right time to spawn the object
        /*  if (time >= spawnTime)
          {
              if (LaikaHealth.gameOver == false && PlayerPrefs.GetInt("FirstMeteorShowerPref") == 1)
              {
                  SpawnObject();
              }
          } */
        if (GrabShipPart.newPartGrabForShower == true)
        {
            if (LaikaHealth.gameOver == false && PlayerPrefs.GetInt("FirstMeteorShowerPref") == 1)
            {
                GrabShipPart.newPartGrabForShower = false;
                SpawnObject();
            }
        }
        if (LaikaHealth.gameOver == true)
        {
            GameObject.Find("DangerMessageContainer").gameObject.transform.GetChild(0).gameObject.SetActive(false);
            destroyMeteorsGameOver = true;
            GameObject.Find("MeteorMusic").gameObject.GetComponent<AudioSource>().Stop();
            GameObject.Find("Music").gameObject.GetComponent<AudioSource>().Play();
            meteorMusicPlaying = false;
        }

    }

    //Spawns the object and resets the time
    void SpawnObject()
    {
        GameObject.Find("Music").gameObject.GetComponent<AudioSource>().Pause();
        GameObject.Find("MeteorMusic").gameObject.GetComponent<AudioSource>().Play();
        meteorMusicPlaying = true;
        time = 0;
        if (LaikaHealth.gameOver == false)
        {
            GameObject.Find("DangerMessageContainer").gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        Invoke("actualSpawn", 5f);
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
        randomShowerNumber = Random.Range(0, 101);
    }

    public void actualSpawn()
    {
        if ((randomShowerNumber % 2) == 0)
        {
            meteorShowerActive = true;
            Instantiate(shower1, transform.position, shower1.transform.rotation);
        }
        else if ((randomShowerNumber % 2) != 0)
        {
            meteorShowerActive = true;
            Instantiate(shower1, transform.position, shower2.transform.rotation);
        }
        SetRandomTime();
    }

}
