using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallSlide : MonoBehaviour
{
    [SerializeField] UnityEvent onJumpWallEnd;

    // Local
    PlayerAttributes attributes;
    Rigidbody2D playerRB;
    PlayerCollisionChecker collisionChecker;
    PlayerMove move;
    PlayerJump jump;
    float localCounter = 0;
    bool startCount = false;
    bool cameFromSlide = false;
    bool blockDownForce = false;

    private void Awake()
    {
        attributes = this.GetComponent<PlayerHandler>().attributes;
        playerRB = this.GetComponent<PlayerHandler>().playerRB;
        collisionChecker = this.GetComponent<PlayerCollisionChecker>();
        move = this.GetComponent<PlayerMove>();
        jump = this.GetComponent<PlayerJump>();
    }

    /// <summary>
    /// This is the wall slide update method
    /// </summary>
    public void OnWallSlide()
    {

        if (startCount)
        {
            localCounter += Time.deltaTime;

            if (localCounter > attributes.jumpWallCooldown)
            {
                localCounter = 0;
                startCount = false;
                onJumpWallEnd.Invoke();
            }
        }

        if (collisionChecker.leftSlider && !blockDownForce || collisionChecker.rightSlider && !blockDownForce)
        {
            if (collisionChecker.leftSlider) move.moveDirection = false;
            else if (collisionChecker.rightSlider) move.moveDirection = true;

            cameFromSlide = true;
            playerRB.velocity = new Vector2(0, -attributes.wallSlideSpeed);
        }
        else if(collisionChecker.bottom)
        {
            startCount = false;
            blockDownForce = false;
            cameFromSlide = false;
        } 

        if (InputSystem.jump && cameFromSlide)
        {
            localCounter = 0;
            startCount = true;
            blockDownForce = true;
            cameFromSlide = false;
            jump.JumpDirection(new Vector2(move.moveDirection ? -1 * attributes.xWallJumpForce : 1 * attributes.xWallJumpForce, 1 * attributes.yWallJumpForce));
            move.moveDirection = !move.moveDirection;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="state"></param>
    public void SetBlockDownForce(bool state)
    {
        blockDownForce = state;
    }
}
