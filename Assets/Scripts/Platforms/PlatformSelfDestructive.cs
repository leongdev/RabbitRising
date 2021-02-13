using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UtilsTimer))]
public class PlatformSelfDestructive : MonoBehaviour
{
    [SerializeField] private float startTimer;
    [SerializeField] private Animator platformAnimator;

    // Local
    UtilsTimer timer;
    bool canFirePlatform = true;

    void Start()
    {
        timer = GetComponent<UtilsTimer>();
    }

    void OnPlayerTriggerPlatform()
    {
        canFirePlatform = false;
        timer.onTimerFinish.RemoveListener(SelfDestroy);
        timer.onTimerFinish.AddListener(SelfDestroy);
        timer.StartTimer(startTimer);
        platformAnimator.Play(SelfDestructivePlatformAnimationConstants.PLATFORM_BLINK_HASH);
    }

    private void OnDestroy() 
    {
        timer.onTimerFinish.RemoveListener(SelfDestroy);
        timer.onTimerFinish.RemoveListener(SelfDestroy);
    } 

    void SelfDestroy()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canFirePlatform && collision.CompareTag("Player"))
        {
            OnPlayerTriggerPlatform();
        }
    }
}

public static class SelfDestructivePlatformAnimationConstants
{
    private const string PLATFORM_BLINK = "self_destructable_platform_blink";
    public static readonly int PLATFORM_BLINK_HASH = Animator.StringToHash(PLATFORM_BLINK);
}