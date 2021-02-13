using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    // Local
    Animator animator;
    Rigidbody2D playerRB;
    PlayerCollisionChecker collisionChecker;
    PlayerAttributes attributes;

    bool dashLocker = false;
    bool dashDownLocker = false;

    private void Awake()
    {
        attributes = this.GetComponent<PlayerHandler>().attributes;
        animator = this.GetComponent<PlayerHandler>().playerAnimController;
        playerRB = this.GetComponent<PlayerHandler>().playerRB;
        collisionChecker = this.GetComponent<PlayerCollisionChecker>();
    }

    /// <summary>
    /// This is the animation update method
    /// </summary>
    public void OnPlayerAnimate()
    {
        if (collisionChecker.leftSlider || collisionChecker.rightSlider)
        {
            WallHandler();
            dashLocker = false;
            dashDownLocker = false;
        }
        else
        {
            if (collisionChecker.bottom)
            {
                GroundHandler();
                dashLocker = false;
                dashDownLocker = false;
            }
            else
            {
                if (InputSystem.Dash)
                {
                    dashLocker = true;
                }
                else if(InputSystem.Jump)
                {
                    dashDownLocker = true;
                }
                AirHandler();
            }
        }
    }


    /// <summary>
    /// Handler the air logic
    /// </summary>
    void AirHandler()
    {

        if (dashLocker)
        {
            PlayAnimation(PlayerAnimationConstants.PLAYER_DASH_HASH);
        }
        else if (dashDownLocker)
        {
            PlayAnimation(PlayerAnimationConstants.PLAYER_FALL_DASH_HASH);
        }
        else{
            //Falling
            if (playerRB.velocity.y < -attributes.sensorThreshold)
            {
                PlayAnimation(PlayerAnimationConstants.PLAYER_FALL_DASH_HASH);
            }
            // Rising Up
            else if (playerRB.velocity.y > attributes.sensorThreshold)
            {
                PlayAnimation(PlayerAnimationConstants.PLAYER_JUMP_HASH);
            }
        }
    }

    /// <summary>
    /// Handler the ground logic
    /// </summary>
    void GroundHandler()
    {
        PlayAnimation(PlayerAnimationConstants.PLAYER_RUN_HASH);
    }

    /// <summary>
    /// Handle wall logic
    /// </summary>
    void WallHandler()
    {
        PlayAnimation(PlayerAnimationConstants.PLAYER_WALL_SLIDE_HASH);
    }

    /// <summary>
    /// This method handles the play animation
    /// </summary>
    private void PlayAnimation(int animationHash)
    {
        animator.Play(animationHash);
    }
}

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
