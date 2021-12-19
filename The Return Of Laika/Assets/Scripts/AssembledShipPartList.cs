using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Laika.Utils;

public class AssembledShipPartList : MonoBehaviour
{

    private bool[] isAssembled = { false, false, false, false, false };
    private int assembledCount = 0;

    public void AddPart(ShipPartEnum shipPartID)
    {
        isAssembled[((int)shipPartID) - 1] = true;
        assembledCount++;
    }

    public bool HasPart(ShipPartEnum shipPartID)
    {
        return isAssembled[((int)shipPartID) - 1];
    }

    public bool HasAssembledFullShip()
    {
        return !Array.Exists(isAssembled, e => !e);
    }

    public int remainingPartCount()
    {
        return assembledCount;
    }
}
