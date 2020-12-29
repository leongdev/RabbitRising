using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UtilsTimer : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent onTimerFinish;

    // Local
    float localTimer = 0;
    bool startCount = false;
    float waitThisForSeconds = 0;

    public void StartTimer(float timeSeconds)
    {
        waitThisForSeconds = timeSeconds;
        localTimer = 0;
        startCount = true;
    }

    void Update()
    {
        if (startCount)
        {
            localTimer += Time.deltaTime;

            if (localTimer >= waitThisForSeconds)
            {
                startCount = false;
                onTimerFinish.Invoke();
            }
        }
    }
}