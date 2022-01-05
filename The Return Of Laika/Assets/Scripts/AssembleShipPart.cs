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
    public static int numberOfPartsAssambled;
    private GameObject collidedShipObject = null;

    private Color colorToMaxOpacity = new Color(0f, 0f, 0f, 1f);
    private Color colorToOriginalOpacity = new Color(0f, 0f, 0f, 0.8f);

    void Start()
    {
        numberOfPartsAssambled = 0;
        playerTransform = this.gameObject.transform;
        playerParentTransform = playerTransform.root.transform;
        shipPartIDScript = this.gameObject.GetComponent<GrabShipPart>();
        assembledShipPartListScript = this.gameObject.GetComponent<AssembledShipPartList>();
    }

    void Update()
    {
        if (!MeteorShowerSpawner.meteorShowerActive &&
            shipPartIDScript.shipPartGrabbed != null && collidedShipObject != null
            && Methods.getShipPartID(shipPartIDScript.shipPartGrabbed) == Methods.getShipPartID(collidedShipObject)
            && Input.GetKeyDown(KeyCode.X))
        {
            SoundManagerScript.PlaySound("correct_drop");
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

    private void OnTriggerStay2D(Collider2D other)
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
        numberOfPartsAssambled++;
        GrabShipPart.holdingPart = false;
        Debug.Log("SHIP ASSEMBLY PROGRESS: "
            + (assembledShipPartListScript.HasAssembledFullShip()
            ? "Ship fully assembled."
            : $"{assembledShipPartListScript.remainingPartCount()}/5 parts collected."));

        collidedShipObject.transform.Find("Sprite").GetComponent<SpriteRenderer>().color += colorToMaxOpacity;

        shipPartIDScript.shipPartGrabbed.SetActive(false);
        shipPartIDScript.handleRelease(false);
    }

    public void handleDeath()
    {
        shipPartIDScript.handleRelease(false);

        foreach (Transform grabbablePart in GameObject.Find("GrabbableParts").transform)
        {
            grabbablePart.GetComponent<InitialTransform>().resetToInitialTransform();
            grabbablePart.gameObject.SetActive(true);
        }

        foreach (Transform assemblyPart in GameObject.Find("Olupina").transform.Find("ShipParts"))
        {
            var sprite = assemblyPart.Find("Sprite").GetComponent<SpriteRenderer>();
            if (sprite.color.a > 0.5)
            {
                sprite.color -= colorToOriginalOpacity;
            }
        }
    }
}
