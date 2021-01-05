using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSprintUp : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float cooldownTime;
    [SerializeField] Animator animator;
    [SerializeField] UtilsTimer timer;

    // Local
    bool canFire = true;

    private void Awake() {
        timer.onTimerFinish.AddListener(FireCooldown);    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && canFire) {
            canFire = false;
            PlayerHandler._canMove = false;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
            FireSprint(other.gameObject.GetComponent<UtilsObjectReference>().referenceObject);
        }
    }

    void FireSprint(GameObject player) {
        Vector2 _direction = Vector2.up;
        player.GetComponent<PlayerJump>().JumpDirectionWithForce(_direction, jumpForce);

        // Reset animation
        animator.enabled = false;
        animator.enabled = true;
        animator.Play(SprintUpPlatformAnimationConstants.PLATFORM_SPRINT_HASH);
        PlayerHandler._canMove = true;
        timer.StartTimer(cooldownTime);
    }

    void FireCooldown() {
        canFire = true;
        animator.Play(SprintUpPlatformAnimationConstants.PLATFORM_IDLE_HASH);
    }
}

public static class SprintUpPlatformAnimationConstants
{
    private const string PLATFORM_SPRINT = "sp_sprint_jump_up";
    private const string PLATFORM_IDLE = "sp_sprint_idle";
    
    public static readonly int PLATFORM_SPRINT_HASH = Animator.StringToHash(PLATFORM_SPRINT);
    public static readonly int PLATFORM_IDLE_HASH = Animator.StringToHash(PLATFORM_IDLE);
}
