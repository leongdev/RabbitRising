using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] float jumpForce;
    [Range(0, 30)]
    [SerializeField] float fallMultiplier = 2.5f;
    [Range(0, 30)]
    [SerializeField] float lowJumpMultiplier = 2f;

    Rigidbody2D playerRB;

    private void Awake()
    {
        playerRB = this.GetComponent<PlayerHandler>().playerRB;
    }

    /// <summary>
    /// This is the Player Jump Update method
    /// </summary>
    /// <param name="checkGround"></param>
    public void OnPlayerJump(bool checkGround, bool checkLeft, bool checkRight)
    {
        if (InputSystem.jump && checkGround)
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
        playerRB.velocity += Vector2.up * jumpForce;
    }

    /// <summary>
    /// This method can jump direction
    /// </summary>
    public void JumpDirection(Vector2 direction)
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
            playerRB.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (playerRB.velocity.y < 0)
        {
            playerRB.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier + 1) * Time.deltaTime;
        }
    }
}
