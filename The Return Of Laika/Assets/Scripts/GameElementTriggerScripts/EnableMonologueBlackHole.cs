using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMonologueBlackHole : MonoBehaviour
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
                DestroyTriggers.destroyHoleTriggers = true;
                this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                disableMovementWhileTalking();
                GameObject.Find("CanvasGameElementTriggers").gameObject.transform.GetChild(numberOfChildToEnable).gameObject.SetActive(true);
                Invoke("enableMovementAfterTalking2", enableWalkingTime);
            }

        }
    }

    public void disableMovementWhileTalking()
    {
        GameObject.Find("Player").gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        InsideMonologue.insideMonologue = true;
        GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().enabled = false;
        GameObject.Find("Player").gameObject.GetComponent<LaikaMovement>().enabled = false;
        GameObject.FindGameObjectWithTag("laikaSprite").GetComponent<SpriteRenderer>().sprite = emptySprite;
        GameObject.Find("Player").gameObject.GetComponent<LaikaMovement>().enabled = true;

    }

    public void enableMovementAfterTalking2()
    {
        InsideMonologue.insideMonologue = false;
        GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().enabled = true;
        GameObject.Find("Player").gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        GameObject.Find("Player").gameObject.GetComponent<LaikaMovement>().enabled = true;
        PlayerPrefs.SetInt("InfrontOfBlackHoleTriggerPref", 1);
        Invoke("destoryThisBox", 0.5f);

    }

    public void destoryThisBox()
    {
        Destroy(this.gameObject);
    }
}
