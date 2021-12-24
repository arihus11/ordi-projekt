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
    private Transform playerParentTransform;
    public static bool holdingPart;

    void Start()
    {
        holdingPart = false;
        playerTransform = this.gameObject.transform;
        playerParentTransform = playerTransform.parent;

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

        shipPartGrabbed = shipPartInRange;
        shipPartGrabbed.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        SoundManagerScript.PlaySound("grab");
        holdingPart = true;
        shipPartInRange = null;

        attachShipPart();
    }

    private void handleRelease()
    {
        if (shipPartGrabbed != null && shipPartGrabbed != shipPartInRange)
        {
            shipPartGrabbed.transform.SetParent(playerParentTransform);
            shipPartGrabbed.gameObject.GetComponent<CircleCollider2D>().enabled = true;
            holdingPart = false;
            SoundManagerScript.PlaySound("grab");
            shipPartGrabbed = null;
        }
    }

    private void attachShipPart()
    {
        shipPartGrabbed.transform.SetParent(playerTransform);

        shipPartGrabbed.transform.localPosition = Vector3.zero;
    }
}
