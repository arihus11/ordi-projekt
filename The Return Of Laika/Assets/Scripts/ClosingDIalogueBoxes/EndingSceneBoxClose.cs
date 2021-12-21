using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingSceneBoxClose : MonoBehaviour
{
    public float closeTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("closeDialogueBox", closeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void closeDialogueBox()
    {
        this.gameObject.GetComponent<Animator>().Play("DialogueBoxMainPopUpReverse");
    }
}
