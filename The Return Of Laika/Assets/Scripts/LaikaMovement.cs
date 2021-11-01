using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaMovement : MonoBehaviour
{
    public float speed = 1.5f; //Remove this line
    private Animator anim;
    private enum MovementStates
    {
        UpwardIdle,
        UpwardMoving,
        LeftIdle,
        LeftMoving,
        RightIdle,
        RightMoving,
        DownwardIdle,
        DownwardMoving,
    }

    private MovementStates currentMovementState = MovementStates.UpwardIdle;

    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = gameObject.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>();

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
        Vector3 pos = transform.position; //Remove this line
        switch (currentMovementState)
        {
            case MovementStates.UpwardMoving:
                pos.y += speed * Time.deltaTime;
                break;
            case MovementStates.LeftMoving:
                pos.x += -speed * Time.deltaTime;
                break;
            case MovementStates.RightMoving:
                pos.x += speed * Time.deltaTime;
                break;
            case MovementStates.DownwardMoving:
                pos.y += -speed * Time.deltaTime;
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
            currentMovementState = MovementStates.UpwardIdle;
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
