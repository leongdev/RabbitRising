using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDash : MonoBehaviour
{
    // Local
    PlayerCollisionChecker collision;
    Rigidbody2D playerRB;
    PlayerAttributes attributes;

    bool moveDirection;
    bool cameFromSky= false;
    bool dashedDown = false;
    float localCounter = 0;
    bool startCount;

    private void Awake()
    {
        attributes = this.GetComponent<PlayerHandler>().attributes;
        playerRB = this.GetComponent<PlayerHandler>().playerRB;
    }

    /// <summary>
    /// This method is the update dash
    /// </summary>
    public void OnDash()
    {
        collision = this.GetComponent<PlayerCollisionChecker>();
        moveDirection = this.GetComponent<PlayerMove>().moveDirection;

        // Dash Ground and Air
        if (InputSystem.dash && !collision.leftSlider && !collision.rightSlider)
        {
            DashDirection(new Vector2(moveDirection ? 1 : -1 ,0));
        }

        // Dash to Down
        if (InputSystem.jump && !collision.bottom && !collision.leftSlider && !collision.rightSlider)
        {
            DashDirection(new Vector2(0, -1));
            dashedDown = true;
        }

        // Find Ground after down dash
        if(collision.bottom && dashedDown)
        {
            dashedDown = false;
            CameraSystem.ShakeCamera();
        }

        if (startCount)
        {
            localCounter += Time.deltaTime;

            if(localCounter > attributes.dashCooldown)
            {
                EndDash();
            }else if (collision.bottom && !cameFromSky)
            {
                EndDash();
            }
        }
    }

    void DashDirection(Vector2 direction)
    {
        StartDash();
        playerRB.velocity = Vector2.zero;
        playerRB.velocity += direction * attributes.dashSpeed;
    }

    /// <summary>
    /// Starts Counter
    /// </summary>
    void StartDash()
    {
        cameFromSky = collision.bottom;
        localCounter = 0;
        startCount = true;
        PlayerHandler._canMove = false;
    }

    /// <summary>
    /// Ends Counter
    /// </summary>
    void EndDash()
    {
        startCount = false;
        PlayerHandler._canMove = true;
    }
}
