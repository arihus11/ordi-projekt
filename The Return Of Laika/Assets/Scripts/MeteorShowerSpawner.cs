using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorShowerSpawner : MonoBehaviour
{
    public GameObject shower1, shower2;
    public static bool meteorShowerActive;
    public static bool destroyMeteorsGameOver;
    public float maxTime = 70;
    public float minTime = 50;


    //current time
    private float time;

    //The time to spawn the object
    private float spawnTime;
    private int randomShowerNumber;
    // Start is called before the first frame update
    void Start()
    {
        destroyMeteorsGameOver = false;
        meteorShowerActive = false;
        SetRandomTime();
        time = minTime;
    }

    void FixedUpdate()
    {
        //Counts up
        time += Time.deltaTime;

        //Check if its the right time to spawn the object
        if (time >= spawnTime)
        {
            if (LaikaHealth.gameOver == false && PlayerPrefs.GetInt("FirstMeteorShowerPref") == 1)
            {
                SpawnObject();
                SetRandomTime();
            }
        }
        if (LaikaHealth.gameOver == true)
        {
            GameObject.Find("DangerMessageContainer").gameObject.transform.GetChild(0).gameObject.SetActive(false);
            destroyMeteorsGameOver = true;
        }

    }

    //Spawns the object and resets the time
    void SpawnObject()
    {
        SoundManagerScript.PlaySound("alert_meteor_shower");
        time = 0;
        if (LaikaHealth.gameOver == false)
        {
            GameObject.Find("DangerMessageContainer").gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        if ((randomShowerNumber % 2) == 0)
        {
            meteorShowerActive = true;
            Instantiate(shower1, transform.position, shower1.transform.rotation);
        }
        else if ((randomShowerNumber % 2) != 0)
        {
            meteorShowerActive = true;
            Instantiate(shower2, transform.position, shower2.transform.rotation);
        }
    }

    //Sets the random time between minTime and maxTime
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
        randomShowerNumber = Random.Range(0, 101);
    }
}
