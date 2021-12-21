using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private bool doOnce;
    public static bool firstShooting;
    // Start is called before the first frame update
    void Start()
    {
        firstShooting = false;
        doOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (EquipWeapon.weaponEquiped == true)
            {

                if (!doOnce)
                {
                    if (firstShooting == false)
                    {
                        GameObject.Find("ShootMessageContainer").gameObject.GetComponent<Animator>().Play("ShootingBase", -1, 0f);
                        firstShooting = true;
                    }
                    Debug.Log("SHOT!");
                    doOnce = true;
                    Invoke("enableSwitch", 0.5f);
                }
            }
        }
    }

    public void enableSwitch()
    {
        doOnce = false;
    }
}
