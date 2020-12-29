using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UtilsTimer))]
public class SelfDestructivePlatformHandler : MonoBehaviour
{
    [SerializeField] SelfDestructivePlatformAttributes attributes;
    [SerializeField] Animator platformAnimator;

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
        timer.StartTimer(attributes.startTimer);
        platformAnimator.Play(SelfDestructivePlatformAnimationConstants.PLATFORM_BLINK_HASH);
    }

    void SelfDestroy()
    {
        GameObject.Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(canFirePlatform && collision.CompareTag("Player"))
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

[CreateAssetMenu(fileName = "SelfDestructivePlatformAttributes", menuName = "LeonGDev/SelfDestructivePlatformAttributes", order = 1)]
public class SelfDestructivePlatformAttributes : ScriptableObject
{
    [Header("PLATFORM SETTINGS")]
    public float startTimer;
}