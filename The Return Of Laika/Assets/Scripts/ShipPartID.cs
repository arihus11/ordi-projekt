using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Laika.Utils;

public class ShipPartID : MonoBehaviour
{
    public ShipPartEnum shipPartID;

    public ShipPartEnum returnPartID()
    {
        return shipPartID;
    }

    public string returnPartName()
    {
        string namePart = "None";
        switch (shipPartID)
        {
            case ShipPartEnum.Part1:
                namePart = "Astronaut Cabin";
                break;
            case ShipPartEnum.Part2:
                namePart = "Jet Engine";
                break;
            case ShipPartEnum.Part3:
                namePart = "Radiation Sensor";
                break;
            case ShipPartEnum.Part4:
                namePart = "Payload Fairing";
                break;
            case ShipPartEnum.Part5:
                namePart = "Transmitter Sphere";
                break;
        }
        return namePart;

    }
}
