using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTheShip : MonoBehaviour
{
    public static bool insideEnteringRange;
    Vector2 placeToFlyDirection;
    public Sprite emptySpite;
    private Rigidbody2D rb, rbShip;
    public float placeToFlyForce;
    float timeStamp;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        insideEnteringRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (insideEnteringRange == true)
            {
                rbShip = GameObject.Find("Ship").gameObject.GetComponent<Rigidbody2D>();
                GameObject.Find("Main Camera").gameObject.GetComponent<CameraFollowPlayerScript>().player = GameObject.FindGameObjectWithTag("endingShip").gameObject.transform;
                disablePlayerControllsOnEnter();
                this.gameObject.transform.position = GameObject.FindGameObjectWithTag("endingShip").gameObject.transform.position;
                this.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("endingShip").gameObject.transform);
                Invoke("shipFlyAway", 1f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enterShip")
        {
            if (EquipWeapon.weaponEquiped == true)
            {
                insideEnteringRange = true;
                GameObject.Find("EnterShipHintContainer").gameObject.GetComponent<Animator>().Play("EnterShipHintDisplay", -1, 0f);
            }
            else
            {
                GameObject.Find("IBetterTakeThatWeaponFirst").gameObject.GetComponent<Animator>().Play("IBetterTakeThatWeaponFirstDisplay", -1, 0f);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "enterShip")
        {
            if (EquipWeapon.weaponEquiped == true)
            {
                insideEnteringRange = false;
                GameObject.Find("EnterShipHintContainer").gameObject.GetComponent<Animator>().Play("Base", -1, 0f);
            }
            else
            {
                GameObject.Find("IBetterTakeThatWeaponFirst").gameObject.GetComponent<Animator>().Play("IBetterTakeThatWeaponFirstBase", -1, 0f);
            }
        }
    }

    public void disablePlayerControllsOnEnter()
    {
        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        this.gameObject.GetComponent<LaikaHealth>().enabled = false;
        this.gameObject.GetComponent<DisplayHint>().enabled = false;
        this.gameObject.GetComponent<LaikaMovement>().enabled = false;
        this.gameObject.GetComponent<Animator>().enabled = false;
        GameObject.FindGameObjectWithTag("endingShip").gameObject.GetComponent<Animator>().enabled = false;
        GameObject.FindGameObjectWithTag("laikaSprite").gameObject.GetComponent<SpriteRenderer>().enabled = false;
        //rb.enabled = false;
    }

    public void shipFlyAway()
    {
        //   GameObject.Find("EndSceneContainer").gameObject.GetComponent<Animator>().Play("ShipFlyAway2");
        timeStamp = Time.time;
        placeToFlyDirection = -(GameObject.Find("Ship").gameObject.transform.position - (GameObject.Find("PlaceForShipToFly").gameObject.transform.position)).normalized;
        rbShip.constraints = RigidbodyConstraints2D.None;
        rbShip.velocity = new Vector2(placeToFlyDirection.x, placeToFlyDirection.y) * placeToFlyForce * (Time.time / timeStamp);
        Invoke("endGamePanel", 3.5f);
    }

    public void endGamePanel()
    {
        GameObject.Find("EndGamePanel").gameObject.GetComponent<Animator>().Play("EndGamePanel");
        Invoke("changeToCredits", 3f);
    }

    public void changeToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
