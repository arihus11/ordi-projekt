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

    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        setCurrentMovementState();
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
            currentMovementState = MovementStates.UpwardIdle;
        }
    }

    private MovementStates getMovingOrIdle(MovementStates moving, MovementStates idle) {
        return Input.GetKey(KeyCode.Space) ? moving : idle;
    }
}
