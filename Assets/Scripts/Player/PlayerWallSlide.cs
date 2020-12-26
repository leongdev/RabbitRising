using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWallSlide : MonoBehaviour
{
    [Header("Wall Slider Settings")]
    [SerializeField] float wallSlideSpeed;
    [Range(0,2)]
    [SerializeField] float xWallJumpForce;
    [Range(0, 2)]
    [SerializeField] float yWallJumpForce;
    [Header("Wall Jump Settings")]
    [SerializeField] float jumpWallCooldown;
    [SerializeField] UnityEvent onJumpWallEnd;
    [Header("Debuggers")]
    [SerializeField] float localCounter = 0;
    [SerializeField] bool startCount = false;

    Rigidbody2D playerRB;
    PlayerCollisionChecker collisionChecker;
    PlayerMove move;
    PlayerJump jump;

    bool cameFromSlide = false;
    bool blockDownForce = false;

    private void Awake()
    {
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

            if (localCounter > jumpWallCooldown)
            {
                localCounter = 0;
                startCount = false;
                onJumpWallEnd.Invoke();
            }
        }

        if (collisionChecker.leftSlider && !blockDownForce || collisionChecker.rightSlider && !blockDownForce)
        {
            cameFromSlide = true;
            playerRB.velocity = new Vector2(0, -wallSlideSpeed);
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
            jump.JumpDirection(new Vector2(move.moveDirection ? -1 * xWallJumpForce : 1 * xWallJumpForce, 1 * yWallJumpForce));
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
