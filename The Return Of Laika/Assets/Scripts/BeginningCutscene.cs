using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningCutscene : MonoBehaviour
{
    private GameObject playerObject;
    private GameObject canvasChildren;
    // Start is called before the first frame update
    void Start()
    {
        canvasChildren = GameObject.Find("CanvasBeginningScene").gameObject;
        playerObject = GameObject.Find("Player").gameObject;
        GameObject.Find("Main Camera").gameObject.GetComponent<Animator>().enabled = true;
        disableMovement();
        Invoke("enableFirstMonologue", 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void disableMovement()
    {
        playerObject.GetComponent<LaikaMovement>().enabled = false;
        GameObject.Find("Main Camera").gameObject.GetComponent<CameraFollowPlayerScript>().enabled = false;
    }

    public void enableFirstMonologue()
    {
        canvasChildren.transform.GetChild(0).gameObject.SetActive(true);
        Invoke("showPartsAnimation", 9.3f);
    }

    public void showPartsAnimation()
    {
        GameObject.Find("Main Camera").gameObject.GetComponent<Animator>().Play("ShowShipParts");
        Invoke("enableMovement", 15f);
    }

    public void enableMovement()
    {
        playerObject.GetComponent<LaikaMovement>().enabled = true;
        GameObject.Find("Main Camera").gameObject.GetComponent<CameraFollowPlayerScript>().enabled = true;
        GameObject.Find("Main Camera").gameObject.GetComponent<Animator>().enabled = false;
    }
}
