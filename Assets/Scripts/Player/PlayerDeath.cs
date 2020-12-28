using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    public UnityEvent onDieStart;
    public UnityEvent onDieEnd;

    // Local
    PlayerAttributes attributes;
    float dieCounter = 0;

    // Static
    static bool isDying = false;
    static bool triggerDie = false;
    static bool dieLocker = true;

    private void Awake()
    {
        attributes = this.GetComponent<PlayerHandler>().attributes;
    }

    private void Start()
    {
        isDying = false;
        triggerDie = false;
        dieLocker = true;
    }

    private void Update()
    {
        // Die Timer
        if (isDying)
        {
            dieCounter += Time.deltaTime;

            if (dieCounter > attributes.afterDieCounter)
            {
                onDieEnd.Invoke();
                isDying = false;
            }
        }

        if (triggerDie)
        {
            triggerDie = false;
            OnPlayerDie();
        }
    }

    /// <summary>
    /// This is the Die update
    /// </summary>
    public void OnPlayerDie()
    {
        isDying = true;
        onDieStart.Invoke();
    }

    /// <summary>
    /// A method to me called from every place and kill the player
    /// </summary>
    public static void KillPlayer()
    {
        if (dieLocker) {
            triggerDie = true;
            dieLocker = false;
        } 
    }
}
