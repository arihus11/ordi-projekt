using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private bool doOnce;
    public GameObject bulletPrefab;
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
                    SoundManagerScript.PlaySound("shoot");
                    Instantiate(bulletPrefab, this.gameObject.transform.position, bulletPrefab.transform.rotation);
                    doOnce = true;
                    Invoke("enableSwitch", 0.1f);
                }
            }
        }
    }

    public void enableSwitch()
    {
        doOnce = false;
    }
}
