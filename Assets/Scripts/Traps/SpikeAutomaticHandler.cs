using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UtilsTimer))]
public class SpikeAutomaticHandler : MonoBehaviour
{
    [SerializeField] Animator spikeAnimator;
    [SerializeField] Animator spikePlatformAnimator;
    [SerializeField] SpikeAutomaticAttributes attributes;

    // Local
    UtilsTimer timer;
    bool canTriggerTrap = true;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<UtilsTimer>();    
    }

    void OnPlatformBlinkEnd() 
    {
        timer.onTimerFinish.RemoveListener(OnPlatformBlinkEnd);
        timer.onTimerFinish.AddListener(OnSpikeEnd);
        timer.StartTimer(attributes.stayOnTimer);

        spikePlatformAnimator.Play(AutomaticSpikePlatformAnimationConstants.SPIKE_IDLE_HASH);
        spikeAnimator.Play(AutomaticSpikeAnimationConstants.SPIKE_UP_HASH);
    }

    void OnSpikeEnd() 
    {
        spikeAnimator.Play(AutomaticSpikeAnimationConstants.SPIKE_DOWN_HASH);
        canTriggerTrap = true;
    }

    void OnPlayerTriggerPlatform()
    {
        timer.onTimerFinish.RemoveListener(OnSpikeEnd);
        timer.onTimerFinish.AddListener(OnPlatformBlinkEnd);
        timer.StartTimer(attributes.startTimer);

        spikePlatformAnimator.Play(AutomaticSpikePlatformAnimationConstants.SPIKE_BLINK_HASH);
        canTriggerTrap = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canTriggerTrap && collision.CompareTag("Player")) 
        {
            OnPlayerTriggerPlatform();
        }
    }
}

[CreateAssetMenu(fileName = "SpikeAutomaticAttributes", menuName = "LeonGDev/SpikeAutomaticAttributes", order = 1)]
public class SpikeAutomaticAttributes: ScriptableObject 
{
    [Header("SPIKE SETTINGS")]
    public float startTimer;
    public float stayOnTimer;
}

public static class AutomaticSpikeAnimationConstants
{
    private const string SPIKE_UP = "sp_spike_spike_up";
    private const string SPIKE_DOWN = "sp_spike_spike_down";

    public static readonly int SPIKE_UP_HASH = Animator.StringToHash(SPIKE_UP);
    public static readonly int SPIKE_DOWN_HASH = Animator.StringToHash(SPIKE_DOWN);
}

public static class AutomaticSpikePlatformAnimationConstants
{
    private const string SPIKE_IDLE = "sp_spike_automatic_Idle";
    private const string SPIKE_BLINK = "sp_spike_automatic_blink";

    public static readonly int SPIKE_IDLE_HASH = Animator.StringToHash(SPIKE_IDLE);
    public static readonly int SPIKE_BLINK_HASH = Animator.StringToHash(SPIKE_BLINK);
}