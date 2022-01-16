using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMonologueBeforePickup : MonoBehaviour
{
    public int numberOfChildToEnable;
    public float enableWalkingTime;
    public Sprite emptySprite;
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
            if (InsideMonologue.insideMonologue == false && BlackHoleMagnet.takenByHole == false)
            {
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                disableMovementWhileTalking();
                GameObject.Find("CanvasGameElementTriggers").gameObject.transform.GetChild(numberOfChildToEnable).gameObject.SetActive(true);
                Invoke("enableMovementAfterTalking", enableWalkingTime);
            }

        }
    }

    public void disableMovementWhileTalking()
    {
        InsideMonologue.insideMonologue = true;
        GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().enabled = false;
        GameObject.Find("Player").gameObject.GetComponent<LaikaMovement>().enabled = false;
        GameObject.FindGameObjectWithTag("laikaSprite").GetComponent<SpriteRenderer>().sprite = emptySprite;

    }

    public void enableMovementAfterTalking()
    {
        InsideMonologue.insideMonologue = false;
        GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().enabled = true;
        GameObject.Find("Player").gameObject.GetComponent<LaikaMovement>().enabled = true;
        PlayerPrefs.SetInt("BeforeMachinePickupTriggerPref", 1);
        Invoke("destoryThisBox", 0.5f);

    }

    public void destoryThisBox()
    {
        Destroy(this.gameObject);
    }
}
