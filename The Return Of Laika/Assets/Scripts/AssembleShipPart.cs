using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Laika.Utils;

public class AssembleShipPart : MonoBehaviour
{
    private Transform playerTransform;
    private Transform playerParentTransform;
    private GrabShipPart shipPartIDScript;
    private AssembledShipPartList assembledShipPartListScript;

    private GameObject collidedShipObject = null;

    void Start()
    {
        playerTransform = this.gameObject.transform;
        playerParentTransform = playerTransform.root.transform;
        shipPartIDScript = this.gameObject.GetComponent<GrabShipPart>();
        assembledShipPartListScript = this.gameObject.GetComponent<AssembledShipPartList>();
    }

    void Update()
    {
        if (shipPartIDScript.shipPartGrabbed != null && collidedShipObject != null
            && Methods.getShipPartID(shipPartIDScript.shipPartGrabbed) == Methods.getShipPartID(collidedShipObject)
            && Input.GetKeyDown(KeyCode.X))
        {
            handleAssembly();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Methods.isShip(other.gameObject.tag))
        {
            collidedShipObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (Methods.isShip(other.gameObject.tag))
        {
            collidedShipObject = null;
        }
    }

    private void handleAssembly()
    {
        assembledShipPartListScript.AddPart(Methods.getShipPartID(shipPartIDScript.shipPartGrabbed));

        Debug.Log("SHIP ASSEMBLY PROGRESS: "
            + (assembledShipPartListScript.HasAssembledFullShip()
            ? "Ship fully assembled."
            : $"{assembledShipPartListScript.remainingPartCount()}/5 parts collected."));

        collidedShipObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().color += new Color(0f, 0f, 0f, 1f);

        GameObject.Destroy(shipPartIDScript.shipPartGrabbed);
    }
}
