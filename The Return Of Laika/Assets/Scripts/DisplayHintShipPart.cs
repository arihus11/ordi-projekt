using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Laika.Utils;

public class DisplayHintShipPart : DisplayHint
{
    protected override void onEvent(GameObject other, AnimationType type)
    {
        if (MeteorShowerSpawner.meteorShowerActive ||
            !isCollisionTag(other.tag)
            || this.gameObject.GetComponent<GrabShipPart>().shipPartGrabbed == null
            || Methods.getShipPartID(other) != Methods.getShipPartID(this.gameObject.GetComponent<GrabShipPart>().shipPartGrabbed))
        {
            return;
        }

        playAnimation(type);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (isCollisionTag(other.gameObject.tag)
            && this.gameObject.GetComponent<GrabShipPart>().shipPartGrabbed == null)
        {
            playAnimation(AnimationType.hide);
        }
    }
}
