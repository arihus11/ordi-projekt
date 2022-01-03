using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupThrustPower : MonoBehaviour
{

    public static bool machineInRange;
    public static bool machineEquiped;
    // Start is called before the first frame update
    void Start()
    {
        machineEquiped = false;
        machineInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (machineInRange == true)
            {
                SoundManagerScript.PlaySound("grab");
                Destroy(GameObject.FindGameObjectWithTag("machine").gameObject);
                machineEquiped = true;
                GameObject.Find("ThrustMessageContainer").gameObject.GetComponent<Animator>().Play("ThrustDisplayMessage");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "machine")
        {

            machineInRange = true;
            GameObject.Find("EquipHintContainer").gameObject.GetComponent<Animator>().Play("EquipHintDisplay", -1, 0f);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "machine")
        {
            machineInRange = false;
            GameObject.Find("EquipHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
    }
}
