using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Laika.Utils;

public class GrabShipPart : MonoBehaviour
{
    private bool isInGrabRange = false;
    private GameObject shipPartInRange = null;

    public GameObject shipPartGrabbed = null;

    private Transform playerTransform;
    private Transform grabbableParentTransform;
    public static bool holdingPart;
    public static bool firstGrabEver;

    void Start()
    {
        firstGrabEver = false;
        holdingPart = false;
        playerTransform = this.gameObject.transform;
        grabbableParentTransform = GameObject.Find("GrabbableParts").transform;

        shipPartGrabbed = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInGrabRange)
            {
                handleGrab();
            }
            else
            {
                handleRelease();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Methods.isGrabbableShip(other.gameObject.tag))
        {
            isInGrabRange = true;
            shipPartInRange = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (Methods.isGrabbableShip(other.gameObject.tag))
        {
            isInGrabRange = false;
            shipPartInRange = null;
        }
    }

    private void handleGrab()
    {
        handleRelease();
        firstGrabEver = true;
        PlayerPrefs.SetInt("FirstMeteorShowerPref", 1);
        shipPartGrabbed = shipPartInRange;
        shipPartGrabbed.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        shipPartGrabbed.gameObject.GetComponent<Animator>().enabled = false;
        SoundManagerScript.PlaySound("grab");
        holdingPart = true;
        shipPartInRange = null;

        attachShipPart();
    }

    public void handleRelease(bool playSound = true)
    {
        if (shipPartGrabbed != null && shipPartGrabbed != shipPartInRange)
        {
            shipPartGrabbed.gameObject.GetComponent<Animator>().enabled = true;
            shipPartGrabbed.transform.SetParent(grabbableParentTransform);
            shipPartGrabbed.gameObject.GetComponent<CircleCollider2D>().enabled = true;
            holdingPart = false;
            if (playSound) SoundManagerScript.PlaySound("grab");
            shipPartGrabbed = null;
        }
    }

    private void attachShipPart()
    {
        shipPartGrabbed.transform.SetParent(playerTransform);

        shipPartGrabbed.transform.localPosition = Vector3.zero;
    }
}
