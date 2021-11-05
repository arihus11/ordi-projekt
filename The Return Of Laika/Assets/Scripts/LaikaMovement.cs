using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaMovement : MonoBehaviour
{
    public float speed = 1.5f; //Remove this line
    private Animator anim;
    private enum MovementStates
    {
        Steady,
        UpwardIdle,
        UpwardMoving,
        LeftIdle,
        LeftMoving,
        RightIdle,
        RightMoving,
        DownwardIdle,
        DownwardMoving
    }

    private MovementStates currentMovementState = MovementStates.Steady;

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
            anim.SetBool("isGoing", false);
        }
    }

    //Remove this function
    void FixedUpdate()
    {
        Vector2 pos = transform.position; //Remove this line
        switch (currentMovementState)
        {
            case MovementStates.UpwardIdle:
                pos.y += speed * Time.deltaTime;
                break;
            case MovementStates.LeftIdle:
                pos.x += -speed * Time.deltaTime;
                break;
            case MovementStates.RightIdle:
                pos.x += speed * Time.deltaTime;
                break;
            case MovementStates.DownwardIdle:
                pos.y += -speed * Time.deltaTime;
                break;
            case MovementStates.UpwardMoving:
                rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
                break;
            case MovementStates.LeftMoving:
                rb.AddForce(transform.right * (-thrust), ForceMode2D.Impulse);
                break;
            case MovementStates.RightMoving:
                rb.AddForce(transform.right * thrust, ForceMode2D.Impulse);
                break;
            case MovementStates.DownwardMoving:
                rb.AddForce(transform.up * (-thrust), ForceMode2D.Impulse);
                break;
        }
        transform.position = pos;
    }

    private void setCurrentMovementState()
    {
        if (Input.GetKey(KeyCode.W))
        {
            currentMovementState = getMovingOrIdle(MovementStates.UpwardMoving, MovementStates.UpwardIdle);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            currentMovementState = getMovingOrIdle(MovementStates.LeftMoving, MovementStates.LeftIdle);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentMovementState = getMovingOrIdle(MovementStates.DownwardMoving, MovementStates.DownwardIdle);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentMovementState = getMovingOrIdle(MovementStates.RightMoving, MovementStates.RightIdle);
        }
        else
        {
            currentMovementState = MovementStates.Steady;
        }
    }

    private MovementStates getMovingOrIdle(MovementStates moving, MovementStates idle)
    {
        if (Input.GetKey(KeyCode.Space))
        {
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
