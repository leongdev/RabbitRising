using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GeneralCounter : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] bool startCount = false;
    [SerializeField] float waitThisForSeconds;
    [Space]
    [SerializeField] float localTimer = 0;
    [SerializeField] UnityEvent onTimerFinish;

    public void StartCount()
    {
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
