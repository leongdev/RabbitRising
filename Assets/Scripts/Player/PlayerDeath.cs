using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    [Header("Die Settings")]
    [SerializeField] float dieCodown = 0;

    [Header("Die Events")]
    public UnityEvent onDieStart;
    public UnityEvent onDieEnd;

    float dieCounter = 0;

    static bool isDying = false;
    static bool triggerDie = false;
    static bool dieLocker = true;

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

            if (dieCounter > dieCodown)
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
