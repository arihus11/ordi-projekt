using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackHoleMagnet : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 holeDirection;
    float timeStamp;
    public static bool flyToHole;
    public static bool takenByHole;
    private Vector2 hole;
    public float holeForce;
    // Start is called before the first frame update
    void Start()
    {
        takenByHole = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float step = holeForce * Time.deltaTime;
        if (flyToHole && takenByHole)
        {
            holeDirection = -(transform.position - (GameObject.FindGameObjectWithTag("blackHole").gameObject.transform.position)).normalized;
            transform.position = Vector2.MoveTowards(transform.position, hole, step);
            //rb.velocity = new Vector2(holeDirection.x, holeDirection.y) * holeForce * (Time.time / timeStamp);

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "blackHole")
        {
            SoundManagerScript.PlaySound("suck");
            hole = col.gameObject.transform.position;
            timeStamp = Time.time;
            takenByHole = true;
            flyToHole = true;

        }
        if (col.gameObject.tag == "middleOfBlackHole")
        {
            SoundManagerScript.PlaySound("blackhole_death");
            GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().enabled = false;
            this.gameObject.GetComponent<Animator>().Play("LaikaShrink");
            this.gameObject.GetComponent<LaikaMovement>().enabled = false;
            Invoke("gameOverPanel", 1.5f);

        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "blackHole")
        {
            flyToHole = false;
            takenByHole = false;
        }
    }

    public void gameOverPanel()
    {
        GameObject.FindGameObjectWithTag("gameOverCanvas2").GetComponent<Animator>().Play("LaikaBlackHole");
        Invoke("loadNextScene", 2.5f);
    }

    public void loadNextScene()
    {
        SceneManager.LoadScene("Main");
    }

}
