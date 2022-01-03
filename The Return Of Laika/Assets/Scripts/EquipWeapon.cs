using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    public static bool weaponInRange;
    public static bool weaponEquiped;
    // Start is called before the first frame update
    void Start()
    {
        weaponEquiped = false;
        weaponInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (weaponInRange == true)
            {
                SoundManagerScript.PlaySound("grab");
                Destroy(GameObject.FindGameObjectWithTag("weapon").gameObject);
                weaponEquiped = true;
                GameObject.Find("ShootMessageContainer").gameObject.GetComponent<Animator>().Play("ShootMessageDisplay");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "weapon")
        {

            weaponInRange = true;
            GameObject.Find("EquipHintContainer").gameObject.GetComponent<Animator>().Play("EquipHintDisplay", -1, 0f);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "weapon")
        {
            weaponInRange = false;
            GameObject.Find("EquipHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
        }
    }
}


