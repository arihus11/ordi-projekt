using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    // Start is called before the first frame update
    public int BeforeMachinePickupTrigger;
    public int InfrontOfMachineTrigger;
    public int InfrontOfWreckTrigger;
    public int InfrontOfShipPartTrigger;
    public int InfrontOfBlackHoleTrigger;
    public int InfrontOfFireballTrigger;
    public int InfrontOfBasicPlanetTrigger;
    public int BeginningCutscene;

    void Start()
    {

    }

    void Awake()
    {
        if (BeforeMachinePickupTrigger == 0)
        {
            PlayerPrefs.SetInt("BeforeMachinePickupTriggerPref", 0);
        }
        else if (BeforeMachinePickupTrigger == 1)
        {
            PlayerPrefs.SetInt("BeforeMachinePickupTriggerPref", 1);
        }

        if (InfrontOfMachineTrigger == 0)
        {
            PlayerPrefs.SetInt("InfrontOfMachineTriggerPref", 0);
        }
        else if (InfrontOfMachineTrigger == 1)
        {
            PlayerPrefs.SetInt("InfrontOfMachineTriggerPref", 1);
        }
        if (InfrontOfWreckTrigger == 0)
        {
            PlayerPrefs.SetInt("InfrontOfWreckTriggerPref", 0);
        }
        else if (InfrontOfWreckTrigger == 1)
        {
            PlayerPrefs.SetInt("InfrontOfWreckTriggerPref", 1);
        }
        if (InfrontOfShipPartTrigger == 0)
        {
            PlayerPrefs.SetInt("InfrontOfShipPartTriggerPref", 0);
        }
        else if (InfrontOfShipPartTrigger == 1)
        {
            PlayerPrefs.SetInt("InfrontOfShipPartTriggerPref", 1);
        }
        if (InfrontOfBlackHoleTrigger == 0)
        {
            PlayerPrefs.SetInt("InfrontOfBlackHoleTriggerPref", 0);
        }
        else if (InfrontOfBlackHoleTrigger == 1)
        {
            PlayerPrefs.SetInt("InfrontOfBlackHoleTriggerPref", 1);
        }
        if (InfrontOfFireballTrigger == 0)
        {
            PlayerPrefs.SetInt("InfrontOfFireballTriggerPref", 0);
        }
        else if (InfrontOfFireballTrigger == 1)
        {
            PlayerPrefs.SetInt("InfrontOfFireballTriggerPref", 1);
        }
        if (InfrontOfBasicPlanetTrigger == 0)
        {
            PlayerPrefs.SetInt("InfrontOfBasicPlanetTriggerPref", 0);
        }
        else if (InfrontOfBasicPlanetTrigger == 1)
        {
            PlayerPrefs.SetInt("InfrontOfBasicPlanetTriggerPref", 1);
        }
        if (BeginningCutscene == 0)
        {
            PlayerPrefs.SetInt("BeginningCutscenePref", 0);
        }
        else if (BeginningCutscene == 1)
        {
            PlayerPrefs.SetInt("BeginningCutscenePref", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
