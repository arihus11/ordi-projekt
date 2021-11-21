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

    void Start()
    {
        playerTransform = this.gameObject.transform;
        playerParentTransform = playerTransform.root.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            handleGrab();
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
        shipPartInRange = null;

        attachShipPart();
    }

    private void handleRelease()
    {
        if (shipPartGrabbed != null && shipPartGrabbed != shipPartInRange)
        {
            shipPartGrabbed.transform.SetParent(playerParentTransform);
        }
    }

    private void attachShipPart()
    {
        shipPartGrabbed.transform.SetParent(playerTransform);

        shipPartGrabbed.transform.localPosition = Vector3.zero;
    }
}
