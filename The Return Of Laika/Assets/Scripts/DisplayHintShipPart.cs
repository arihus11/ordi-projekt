using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Laika.Utils;

public class DisplayHintShipPart : DisplayHint
{
    protected override void onEvent(GameObject other, AnimationType type)
    {
        if (!isCollisionTag(other.tag)
            || this.gameObject.GetComponent<GrabShipPart>().shipPartGrabbed == null
            || Methods.getShipPartID(other) != Methods.getShipPartID(this.gameObject.GetComponent<GrabShipPart>().shipPartGrabbed))
        {
            return;
        }

        playAnimation(type);
    }
}
