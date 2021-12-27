using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMonologue : MonoBehaviour
{
    public int numberOfChildToEnable;
    public float enableWalkingTime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Laika")
        {
            disableMovementWhileTalking();
            GameObject.Find("CanvasGameElementTriggers").gameObject.transform.GetChild(numberOfChildToEnable).gameObject.SetActive(true);
            Invoke("enableMovementAfterTalking", enableWalkingTime);

        }
    }

    public void disableMovementWhileTalking()
    {
        GameObject.Find("Player").gameObject.GetComponent<LaikaMovement>().enabled = false;
    }

    public void enableMovementAfterTalking()
    {
        GameObject.Find("Player").gameObject.GetComponent<LaikaMovement>().enabled = true;
    }
}
