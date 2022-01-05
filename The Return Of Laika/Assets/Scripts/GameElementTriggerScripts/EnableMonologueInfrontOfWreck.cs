using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMonologueInfrontOfWreck : MonoBehaviour
{
    // Start is called before the first frame update
    public int numberOfChildToEnable;
    public float enableWalkingTime;
    public Sprite emptySprite;
    // Start is called before the first frame update
    void Start()
    {
        EnableMonologue.insideMonologue = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Laika")
        {
            if (EnableMonologue.insideMonologue == false && BlackHoleMagnet.takenByHole == false)
            {
                disableMovementWhileTalking();
                GameObject.Find("CanvasGameElementTriggers").gameObject.transform.GetChild(numberOfChildToEnable).gameObject.SetActive(true);
                Invoke("enableMovementAfterTalking", enableWalkingTime);
            }

        }
    }

    public void disableMovementWhileTalking()
    {
        EnableMonologue.insideMonologue = true;
        GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().enabled = false;
        GameObject.Find("Player").gameObject.GetComponent<LaikaMovement>().enabled = false;
        GameObject.FindGameObjectWithTag("laikaSprite").GetComponent<SpriteRenderer>().sprite = emptySprite;

    }

    public void enableMovementAfterTalking()
    {
        EnableMonologue.insideMonologue = false;
        GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().enabled = true;
        GameObject.Find("Player").gameObject.GetComponent<LaikaMovement>().enabled = true;
        Invoke("destoryThisBox", 0.5f);
        PlayerPrefs.SetInt("InfrontOfWreckTriggerPref", 1);
    }

    public void destoryThisBox()
    {
        Destroy(this.gameObject);
    }
}
