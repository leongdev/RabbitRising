using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Local
    Rigidbody2D playerRB;
    PlayerAttributes attributes;

    private void Awake()
    {
        attributes = this.GetComponent<PlayerHandler>().attributes;
        playerRB = this.GetComponent<PlayerHandler>().playerRB;
    }

    /// <summary>
    /// This is the Player Jump Update method
    /// </summary>
    /// <param name="checkGround"></param>
    public void OnPlayerJump(bool checkGround, bool checkLeft, bool checkRight)
    {
        if (InputSystem.Jump && checkGround)
        {
            Jump();
        }

        PlayerJumpPrettier();
    }

    /// <summary>
    /// This method handle the players jump
    /// </summary>
    public void Jump()
    {
        playerRB.velocity = new Vector2(playerRB.velocity.x, 0);
        playerRB.velocity += Vector2.up * attributes.jumpForce;
    }

    /// <summary>
    /// This method can jump direction
    /// </summary>
    public void JumpDirection(Vector2 direction)
    {
        playerRB.velocity = Vector2.zero;
        playerRB.velocity += direction * attributes.jumpForce;
    }

    /// <summary>
    /// This method can jump direction
    /// </summary>
    public void JumpDirectionWithForce(Vector2 direction , float jumpForce)
    {
        playerRB.velocity = Vector2.zero;
        playerRB.velocity += direction * jumpForce;
    }

    /// <summary>
    /// This method brings a better fell to the Jump
    /// </summary>
    void PlayerJumpPrettier()
    {
        if (playerRB.velocity.y > 0)
        {
            playerRB.velocity += Vector2.up * Physics2D.gravity.y * (attributes.fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerRB.velocity.y < 0)
        {
            playerRB.velocity += Vector2.up * Physics2D.gravity.y * (attributes.lowJumpMultiplier + 1) * Time.deltaTime;
        }
    }
}