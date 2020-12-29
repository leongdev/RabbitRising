using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
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
                OnPlayerDieEnd();
            }
        }

        if (triggerDie)
        {
            triggerDie = false;
            OnPlayerDieStart();
        }
    }

    /// <summary>
    /// This is the Die update
    /// </summary>
    public void OnPlayerDieStart()
    {
        //isDying = true;
        SceneManager.LoadScene(0);
    }

    public void OnPlayerDieEnd()
    {
        isDying = false;
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
