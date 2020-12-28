using UnityEngine;

public static class PlayerAnimationConstants
{
    private const string PLAYER_IDLE = "player_Idle";
    private const string PLAYER_RUN = "player_Run";
    private const string PLAYER_JUMP = "player_Jump";
    private const string PLAYER_FALL = "player_Fall";
    private const string PLAYER_DASH = "player_Dash";
    private const string PLAYER_FALL_DASH = "player_Fall_Dash";
    private const string PLAYER_ROLL = "player_Roll";
    private const string PLAYER_WALL_SLIDE = "player_Wall_Slide";

    public static readonly int PLAYER_IDLE_HASH = Animator.StringToHash(PLAYER_IDLE);
    public static readonly int PLAYER_RUN_HASH = Animator.StringToHash(PLAYER_RUN);
    public static readonly int PLAYER_FALL_HASH = Animator.StringToHash(PLAYER_FALL);
    public static readonly int PLAYER_JUMP_HASH = Animator.StringToHash(PLAYER_JUMP);
    public static readonly int PLAYER_DASH_HASH = Animator.StringToHash(PLAYER_DASH);
    public static readonly int PLAYER_FALL_DASH_HASH = Animator.StringToHash(PLAYER_FALL_DASH);
    public static readonly int PLAYER_ROLL_HASH = Animator.StringToHash(PLAYER_ROLL);
    public static readonly int PLAYER_WALL_SLIDE_HASH = Animator.StringToHash(PLAYER_WALL_SLIDE);
}
