using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlatform : MonoBehaviour
{
    [Range(-1,1)]
    [SerializeField] float direction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (direction < 0) JumpLeft(collision);
            else JumpRight(collision);
        }
    }

    /// <summary>
    /// This method jumps the Player twars left direction
    /// </summary>
    /// <param name="player"></param>
    void JumpLeft(Collider2D player)
    {
        player.gameObject.GetComponent<PlayerReference>().playerRoot.gameObject.GetComponent<PlayerJump>().JumpDirection(new Vector2(-1, 1));
        this.GetComponent<Animator>().SetTrigger("Touch");
    }

    /// <summary>
    /// This method jumps the Player twars right direction
    /// </summary>
    /// <param name="player"></param>
    void JumpRight(Collider2D player)
    {
        player.gameObject.GetComponent<PlayerReference>().playerRoot.gameObject.GetComponent<PlayerJump>().JumpDirection(new Vector2(1, 1));
        this.GetComponent<Animator>().SetTrigger("Touch");
    }
}
