using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaikaMovement : MonoBehaviour
{
    private enum MovementStates {
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
        spriteRenderer = gameObject.transform.Find("Sprite").gameObject.GetComponent<SpriteRenderer>();

        if (sprites.Length < 8) {
            Debug.LogError("Not enough sprites!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        setCurrentMovementState();
        setSprite();
    }

    private void setCurrentMovementState()
    {
        if (Input.GetKey(KeyCode.W)) {
            currentMovementState = getMovingOrIdle(MovementStates.UpwardMoving, MovementStates.UpwardIdle);
        } else if (Input.GetKey(KeyCode.A)) {
            currentMovementState = getMovingOrIdle(MovementStates.LeftMoving, MovementStates.LeftIdle);
        } else if (Input.GetKey(KeyCode.S)) {
            currentMovementState = getMovingOrIdle(MovementStates.DownwardMoving, MovementStates.DownwardIdle);
        } else if (Input.GetKey(KeyCode.D)) {
            currentMovementState = getMovingOrIdle(MovementStates.RightMoving, MovementStates.RightIdle);
        } else {
            currentMovementState = getIdleCurrentMovementState();
        }
    }

    private MovementStates getMovingOrIdle(MovementStates moving, MovementStates idle) {
        return Input.GetKey(KeyCode.Space) ? moving : idle;
    }

    private MovementStates getIdleCurrentMovementState()
    {
        switch (currentMovementState)
        {
            case MovementStates.UpwardMoving:
                return MovementStates.UpwardIdle;
            case MovementStates.LeftMoving:
                return MovementStates.LeftIdle;
            case MovementStates.RightMoving:
                return MovementStates.RightIdle;
            case MovementStates.DownwardMoving:
                return MovementStates.DownwardIdle;
            default:
                return currentMovementState;
        }
    }

    private void setSprite()
    {
        spriteRenderer.sprite = sprites[((int)currentMovementState)];
    }
}
