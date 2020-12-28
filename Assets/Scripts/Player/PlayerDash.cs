using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDash : MonoBehaviour
{
    [Header("Dash Settings")]
    [SerializeField] float dashSpeed;
    [SerializeField] float dashCooldown;
    [Header("Debuggers")]
    [SerializeField] float localCounter = 0;
    [SerializeField] bool startCount;
    [Header("Setup Events")]
    [SerializeField] UnityEvent onDashStart;
    [SerializeField] UnityEvent onDashEnd;

    bool moveDirection;
    bool cameFromSky= false;
    bool dashedDown = false;

    PlayerCollisionChecker collision;
    Rigidbody2D playerRB;

    private void Awake()
    {
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

            if(localCounter > dashCooldown)
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
        playerRB.velocity += direction * dashSpeed;
    }

    /// <summary>
    /// Starts Counter
    /// </summary>
    void StartDash()
    {
        cameFromSky = collision.bottom;
        localCounter = 0;
        startCount = true;
        onDashStart.Invoke();
    }

    /// <summary>
    /// Ends Counter
    /// </summary>
    void EndDash()
    {
        startCount = false;
        onDashEnd.Invoke();
    }
}
