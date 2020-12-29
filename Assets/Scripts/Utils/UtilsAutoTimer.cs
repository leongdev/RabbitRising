using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UtilsAutoTimer : MonoBehaviour
{
    [SerializeField] float timeInSeconds = 0;
    [SerializeField] UnityEvent onTimerFinish;

    // Local
    float localTimer = 0;
    bool startCount = false;

    private void Start()
    {
        StartTimer();
    }

    public void StartTimer()
    {
        localTimer = 0;
        startCount = true;
    }

    void Update()
    {
        if (startCount)
        {
            localTimer += Time.deltaTime;

            if (localTimer >= timeInSeconds)
            {
                startCount = false;
                onTimerFinish.Invoke();
            }
        }
    }
}
