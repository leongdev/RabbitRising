using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpikesHandler : MonoBehaviour
{
    [Header("Moving Spike Settup")]
    [SerializeField] float trapDuration;
    [SerializeField] float trapArmedDuration;
    [SerializeField] Animator spikeAnimator;
    [Header("Timer Debugger")]
    [SerializeField] float localTime = 0;
    [SerializeField] bool blinkTrap = false;
    [SerializeField] bool fireTrap = false;

    private void Update()
    {
        if (blinkTrap)
        {
            localTime += Time.deltaTime;
            if(localTime > trapDuration)
            {
                blinkTrap = false;
                FireTrap();
            }
        }

        if (fireTrap)
        {
            localTime += Time.deltaTime;
            if(localTime > trapArmedDuration)
            {
                fireTrap = false;
                DisableTrap();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    void DisableTrap()
    {
        spikeAnimator.SetInteger("SpikeState", 0);

    }

    /// <summary>
    /// 
    /// </summary>
    void FireTrap()
    {
        localTime = 0;
        fireTrap = true;
        spikeAnimator.SetInteger("SpikeState", 2);
    }

    /// <summary>
    /// 
    /// </summary>
    void BlikTrap()
    {
        localTime = 0;
        blinkTrap = true;
        spikeAnimator.SetInteger("SpikeState", 1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BlikTrap();
        }
    }
}
