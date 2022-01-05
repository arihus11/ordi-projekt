using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Laika.Utils;

public class LaikaMovement : MonoBehaviour
{
    public float speed = 1.5f; //Remove this line
    private Animator anim;

    private MovementState currentMovementState = MovementState.Steady;

    private Rigidbody2D rb;
    public float thrust = 20f;

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = gameObject.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        if (sprites.Length < 8)
        {
            Debug.LogError("Not enough sprites!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        setCurrentMovementState();
        setSprite();
        if (!(Input.GetKey(KeyCode.Space)))
        {
            GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().mute = true;
            if (LaikaHealth.gameOver == false)
            {
                anim.SetBool("isGoing", false);
            }
        }
    }

    //Remove this function
    void FixedUpdate()
    {
        if (LaikaHealth.gameOver == false)
        {
            Vector2 pos = transform.position; //Remove this line
            switch (currentMovementState)
            {
                case MovementState.UpwardIdle:
                    GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().mute = true;
                    pos.y += speed * Time.deltaTime;
                    break;
                case MovementState.LeftIdle:
                    GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().mute = true;
                    pos.x += -speed * Time.deltaTime;
                    break;
                case MovementState.RightIdle:
                    GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().mute = true;
                    pos.x += speed * Time.deltaTime;
                    break;
                case MovementState.DownwardIdle:
                    GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().mute = true;
                    pos.y += -speed * Time.deltaTime;
                    break;
                case MovementState.UpwardMoving:
                    GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().mute = false;
                    rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
                    break;
                case MovementState.LeftMoving:
                    GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().mute = false;
                    rb.AddForce(transform.right * (-thrust), ForceMode2D.Impulse);
                    break;
                case MovementState.RightMoving:
                    GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().mute = false;
                    rb.AddForce(transform.right * thrust, ForceMode2D.Impulse);
                    break;
                case MovementState.DownwardMoving:
                    GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().mute = false;
                    rb.AddForce(transform.up * (-thrust), ForceMode2D.Impulse);
                    break;
            }
            transform.position = pos;
        }
    }

    private void setCurrentMovementState()
    {
        if (LaikaHealth.gameOver == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                currentMovementState = getMovingOrIdle(MovementState.UpwardMoving, MovementState.UpwardIdle);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                currentMovementState = getMovingOrIdle(MovementState.LeftMoving, MovementState.LeftIdle);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                currentMovementState = getMovingOrIdle(MovementState.DownwardMoving, MovementState.DownwardIdle);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                currentMovementState = getMovingOrIdle(MovementState.RightMoving, MovementState.RightIdle);
            }
            else
            {
                currentMovementState = MovementState.Steady;
                GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().mute = true;
            }
        }
        else
        {
            currentMovementState = MovementState.Steady;
            GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().mute = true;
        }
    }

    private MovementState getMovingOrIdle(MovementState moving, MovementState idle)
    {
        if (Input.GetKey(KeyCode.Space) && PlayerPrefs.GetInt("ThrustMachinePickupPref") == 1)
        {
            //  GameObject.Find("JetpackSoundManager").gameObject.GetComponent<AudioSource>().mute = false;
            GameObject.Find("ThrustMessageContainer").gameObject.GetComponent<Animator>().Play("ThrustBase");
            anim.SetBool("isGoing", true);
            return moving;
        }
        else
        {
            return idle;
        }
    }

    private void setSprite()
    {
        spriteRenderer.sprite = sprites[((int)currentMovementState)];
    }
}
