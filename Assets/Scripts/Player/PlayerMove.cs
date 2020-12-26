using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] float moveSpeed;
    public bool moveDirection = true;

    Rigidbody2D playerRB;
    SpriteRenderer playerSprite;
    PlayerCollisionChecker collisionChecker;

    private void Awake()
    {
        playerRB = this.GetComponent<PlayerHandler>().playerRB;
        playerSprite = this.GetComponent<PlayerHandler>().playerSpriteRenderer;
        collisionChecker = this.GetComponent<PlayerCollisionChecker>();
    }

    /// <summary>
    /// This is the Player Move Update method
    /// </summary>
    /// <param name="playerRB"></param>
    public void OnPlayerMove(bool moveDirection)
    {
        playerSprite.flipX = !moveDirection;
        Vector2 direction = new Vector2(moveDirection ? 1 : -1, 0);
        Move(direction);
    }

    /// <summary>
    /// This method moves the player twards X and Y axis Direction
    /// </summary>
    /// <param name="direction"> X and Y Input directions </param>
    void Move(Vector2 direction)
    {
        if (collisionChecker.bottom)
        {
            playerRB.velocity = new Vector2(direction.x * moveSpeed,playerRB.velocity.y);
        }
    }
}
