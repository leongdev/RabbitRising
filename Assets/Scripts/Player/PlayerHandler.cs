using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] bool canDash;
    [SerializeField] bool canMove;
    [SerializeField] bool canJump;
    [SerializeField] bool canSlide;
    [SerializeField] bool canAnimate;
    [SerializeField] bool canCheckCollisions;
    [SerializeField] bool canUpdateDirection;
    [Space]
    [Header("Setup Scripts")]
    [SerializeField] PlayerMove move;
    [SerializeField] PlayerJump jump;
    [SerializeField] PlayerCollisionChecker collisions;
    [SerializeField] PlayerWallSlide wallSlide;
    [SerializeField] PlayerDash dash;
    [SerializeField] PlayerAnimator animate;
    [Header("Other Settings")]
    public PinObject cameraTarget;
    public Rigidbody2D playerRB;
    public Animator playerAnimController;
    public SpriteRenderer playerSpriteRenderer;

    // Update is called once per frame
    void Update()
    {
        if (canMove) move.OnPlayerMove(move.moveDirection);
        if (canJump) jump.OnPlayerJump(collisions.bottom, collisions.leftSlider, collisions.rightSlider);
        if (canCheckCollisions) collisions.OnCheckCollisions();
        if (canUpdateDirection) Direction();
        if (canAnimate) animate.OnPlayerAnimate();
        if (canDash) dash.OnDash();
        if (canSlide) wallSlide.OnWallSlide();
    }

    /// <summary>
    /// This method updates the direction variable
    /// </summary>
    void Direction() 
    {
        //Normal Wall Collision
        if (collisions.right)
        {
            move.moveDirection = false;
        }
        else if (collisions.left)
        {
            move.moveDirection = true;
        }
    }

    /// <summary>
    /// This method can change the movement state
    /// </summary>
    /// <param name="state">Movement State</param>
    public void SetMove(bool state)
    {
        canMove = state;
    }
}
