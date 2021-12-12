using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimGenerator : MonoBehaviour
{
    public static int randomNumber;
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void calculateRandomNumber()
    {
        randomNumber = Random.Range(1, 3);
    }
}
