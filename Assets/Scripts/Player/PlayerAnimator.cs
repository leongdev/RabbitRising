using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header("Animation Settings")]
    public float animationIndex = 1;
    public float sensorThreshold;

    Animator animator;
    Rigidbody2D playerRB;
    PlayerCollisionChecker collisionChecker;

    bool dashLocker = false;
    bool dashDownLocker = false;

    private void Awake()
    {
        animator = this.GetComponent<PlayerHandler>().playerAnimController;
        playerRB = this.GetComponent<PlayerHandler>().playerRB;
        collisionChecker = this.GetComponent<PlayerCollisionChecker>();
    }

    /// <summary>
    /// This is the animation update method
    /// </summary>
    public void OnPlayerAnimate()
    {
        animator.SetFloat("PlayerState", animationIndex);

        if (collisionChecker.leftSlider || collisionChecker.rightSlider)
        {
            WallHandler();
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
                if (InputSystem.dash)
                {
                    dashLocker = true;
                }
                else if(InputSystem.jump)
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
            animationIndex = 4;
        }
        else if (dashDownLocker)
        {
            animationIndex = 5;
        }
        else{
            //Falling
            if (playerRB.velocity.y < -sensorThreshold)
            {
                animationIndex = 3;
            }
            // Rising Up
            else if (playerRB.velocity.y > sensorThreshold)
            {
                animationIndex = 2;
            }
        }
    }

    /// <summary>
    /// Handler the ground logic
    /// </summary>
    void GroundHandler()
    {
        animationIndex = 1;
    }

    /// <summary>
    /// Handle wall logic
    /// </summary>
    void WallHandler()
    {
        animationIndex = 7;
    }
}
