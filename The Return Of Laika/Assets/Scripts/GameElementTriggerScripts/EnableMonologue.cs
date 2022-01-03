using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMonologue : MonoBehaviour
{

    public int numberOfChildToEnable;
    public float enableWalkingTime;
    public static bool destroyHoleTriggers, destroyFireballTriggers, destroyBasicPlanetTriggers;
    public Sprite emptySprite;
    public static bool insideMonologue;
    // Start is called before the first frame update
    void Start()
    {
        insideMonologue = false;
        destroyHoleTriggers = false;
        destroyFireballTriggers = false;
        destroyBasicPlanetTriggers = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Laika")
        {
            if (insideMonologue == false)
            {
                disableMovementWhileTalking();
                GameObject.Find("CanvasGameElementTriggers").gameObject.transform.GetChild(numberOfChildToEnable).gameObject.SetActive(true);
                Invoke("enableMovementAfterTalking", enableWalkingTime);
            }

        }
    }

    public void disableMovementWhileTalking()
    {
        insideMonologue = true;
        GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().enabled = false;
        GameObject.Find("Player").gameObject.GetComponent<LaikaMovement>().enabled = false;
        GameObject.FindGameObjectWithTag("laikaSprite").GetComponent<SpriteRenderer>().sprite = emptySprite;

    }

    public void enableMovementAfterTalking()
    {
        insideMonologue = false;
        GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().enabled = true;
        GameObject.Find("Player").gameObject.GetComponent<LaikaMovement>().enabled = true;
        Invoke("destoryThisBox", 0.5f);
    }

    public void destoryThisBox()
    {
        Destroy(this.gameObject);
    }
}
