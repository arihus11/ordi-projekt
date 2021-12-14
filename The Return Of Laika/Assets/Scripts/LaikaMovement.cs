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
                    pos.y += speed * Time.deltaTime;
                    break;
                case MovementState.LeftIdle:
                    pos.x += -speed * Time.deltaTime;
                    break;
                case MovementState.RightIdle:
                    pos.x += speed * Time.deltaTime;
                    break;
                case MovementState.DownwardIdle:
                    pos.y += -speed * Time.deltaTime;
                    break;
                case MovementState.UpwardMoving:
                    rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
                    break;
                case MovementState.LeftMoving:
                    rb.AddForce(transform.right * (-thrust), ForceMode2D.Impulse);
                    break;
                case MovementState.RightMoving:
                    rb.AddForce(transform.right * thrust, ForceMode2D.Impulse);
                    break;
                case MovementState.DownwardMoving:
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
            }
        }
        else
        {
            currentMovementState = MovementState.Steady;
        }
    }

    private MovementState getMovingOrIdle(MovementState moving, MovementState idle)
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
