using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
[RequireComponent(typeof(PlayerJump))]
[RequireComponent(typeof(PlayerCollisionChecker))]
[RequireComponent(typeof(PlayerWallSlide))]
[RequireComponent(typeof(PlayerDash))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerHandler : MonoBehaviour
{
    [Header("PLAYER DEBUG STATES")]
    [SerializeField] bool canDash;
    [SerializeField] bool canMove;
    [SerializeField] bool canJump;
    [SerializeField] bool canSlide;
    [SerializeField] bool canAnimate;
    [SerializeField] bool canCheckCollisions;
    [SerializeField] bool canUpdateDirection;
    [Space]
  
    [Header("PLAYER FILES")]
    public UtilsPinObject cameraTarget;
    public Rigidbody2D playerRB;
    public Animator playerAnimController;
    public SpriteRenderer playerSpriteRenderer;
    public PlayerAttributes attributes;

    // Local
    PlayerMove move;
    PlayerJump jump;
    PlayerCollisionChecker collisions;
    PlayerWallSlide wallSlide;
    PlayerDash dash;
    PlayerAnimator animate;

    private void Awake()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        SetupVariables();
    }

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
    /// This method setups the local variables
    /// </summary>
    void SetupVariables() 
    {
        move = GetComponent<PlayerMove>();
        jump = GetComponent<PlayerJump>();
        collisions = GetComponent<PlayerCollisionChecker>();
        wallSlide = GetComponent<PlayerWallSlide>();
        dash = GetComponent<PlayerDash>();
        animate = GetComponent<PlayerAnimator>();
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
