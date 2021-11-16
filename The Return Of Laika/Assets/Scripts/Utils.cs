namespace Laika.Utils
{
    public enum MovementState
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

    public enum CollisionMessageObjectTag
    {
        boundary,
        grabbable
    }
}