using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimerSystem : MonoBehaviour
{
    [Header("Debug Settings")]
    [SerializeField] string timerCountdown;
    [SerializeField] bool startCount = false;
    [SerializeField] float timeAmount = 0;

    float elapsedTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        startCount = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCounter();
        }

        if (startCount)
        {
            elapsedTime -= Time.deltaTime;
            timerCountdown = TimeSpan.FromSeconds(elapsedTime).ToString("mm':'ss'.'ff");

            if (elapsedTime <= 0)
            {
                EndCounter();
            }
        }
    }

    /// <summary>
    /// This method ends Counter
    /// </summary>
    public void EndCounter()
    {
        startCount = false;
    }

    /// <summary>
    /// This method starts Counter
    /// </summary>
    public void StartCounter()
    {
        elapsedTime = timeAmount;
        startCount = true;
    }


    /// <summary>
    /// This method starts custom Counter
    /// </summary>
    /// <param name="timeAmount"></param>
    public void StartCounterAt(float timeAmount)
    {
        elapsedTime = timeAmount;
        startCount = true;
    }
}
