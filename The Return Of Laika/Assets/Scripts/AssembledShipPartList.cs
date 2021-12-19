using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Laika.Utils;

public class AssembledShipPartList : MonoBehaviour
{

    private bool[] isAssembled = { false, false, false, false, false };

    public void AddPart(ShipPartEnum shipPartID)
    {
        isAssembled[((int)shipPartID) - 1] = true;
    }

    public bool HasPart(ShipPartEnum shipPartID)
    {
        return isAssembled[((int)shipPartID) - 1];
    }

    public bool HasAssembledFullShip()
    {
        return !Array.Exists(isAssembled, e => !e);
    }
}
