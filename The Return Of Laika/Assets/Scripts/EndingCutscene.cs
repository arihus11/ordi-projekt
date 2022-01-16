using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingCutscene : MonoBehaviour
{

    Rigidbody2D rb;
    public Sprite movingSprite, stayingSprite;
    Vector2 placeToStandDirection;
    public float placeToStandForce;
    public GameObject standingPlace;
    public static bool endingStarted;
    private bool oneRumble;
    float timeStamp;
    private bool oneFlyout;
    public static bool doOnce, flying, oneFlash;
    // Start is called before the first frame update
    void Start()
    {
        oneFlyout = false;
        oneRumble = false;
        oneFlash = false;
        flying = false;
        rb = GameObject.Find("Player").gameObject.GetComponent<Rigidbody2D>();
        doOnce = false;
        endingStarted = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (AssembleShipPart.numberOfPartsAssambled == 5)
        {
            if (doOnce == false)
            {
                endingStarted = true;
                disablePlayerControllls();
                Invoke("displayTextBox1", 1.1f);
                //  Invoke("executeSmoke", 3.8f);
                //    doOnce = true;
            }

        }
    }

    public void disablePlayerControllls()
    {
        GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().enabled = false;
        GameObject.Find("Player").gameObject.GetComponent<LaikaHealth>().enabled = false;
        GameObject.Find("Player").gameObject.GetComponent<DisplayHint>().enabled = false;
        GameObject.Find("Player").gameObject.GetComponent<LaikaMovement>().enabled = false;
    }

    public void executeShipPartsRotation()
    {
        GameObject.Find("Olupina").gameObject.GetComponent<Animator>().Play("ShipPartsRotation");
        if (oneRumble == false)
        {
            SoundManagerScript.PlaySound("rumble1");
            oneRumble = true;
        }
        Invoke("executeSmoke", 1f);
    }

    public void displayTextBox1()
    {
        if (GameObject.Find("CanvasEndingScene").gameObject.transform.childCount > 1)
        {
            GameObject.Find("CanvasEndingScene").gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Invoke("flyLaika", 9f);
        }

    }

    public void displayTextBox2()
    {
        if (GameObject.Find("CanvasEndingScene").gameObject.transform.childCount > 0)
        {
            GameObject.Find("CanvasEndingScene").gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }

    }

    public void flyLaika()
    {
        Invoke("executeShipPartsRotation", 2.1f);
        if (flying == false)
        {
            GameObject.FindGameObjectWithTag("laikaSprite").gameObject.GetComponent<SpriteRenderer>().sprite = movingSprite;
            disableFlying();
            timeStamp = Time.time;
            placeToStandDirection = -(GameObject.Find("Player").gameObject.transform.position - (GameObject.Find("PlaceForLaikaToStand").gameObject.transform.position)).normalized;
            rb.velocity = new Vector2(placeToStandDirection.x, placeToStandDirection.y) * placeToStandForce * (Time.time / timeStamp);
        }
    }

    public void executeSmoke()
    {
        if (GameObject.Find("Olupina").gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            if (oneFlash == false)
            {
                SoundManagerScript.PlaySound("flash");
                oneFlash = true;
            }

            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            Invoke("displayShip", 0.15f);
        }
    }
    public void disableFlying()
    {
        if (Vector2.Distance(GameObject.Find("Player").gameObject.transform.position, GameObject.Find("PlaceForLaikaToStand").gameObject.transform.position) < 4)
        {
            flying = true;
            GameObject.FindGameObjectWithTag("laikaSprite").gameObject.GetComponent<SpriteRenderer>().sprite = stayingSprite;
        }

    }

    public void displayShip()
    {
        this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
        Invoke("revealWeapon", 2f);
    }

    public void revealWeapon()
    {
        if (!oneFlyout)
        {
            SoundManagerScript.PlaySound("flyout");
            oneFlyout = true;
        }
        this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
        Invoke("displayTextBox2", 2.6f);
        Invoke("enablePlayerControllls", 8.4f);
    }


    public void enablePlayerControllls()
    {
        GameObject.Find("Player").gameObject.GetComponent<LaikaHealth>().enabled = true;
        GameObject.Find("Player").gameObject.GetComponent<DisplayHint>().enabled = true;
        GameObject.Find("Player").gameObject.GetComponent<LaikaMovement>().enabled = true;
        this.gameObject.GetComponent<EndingCutscene>().enabled = false;
    }
}
