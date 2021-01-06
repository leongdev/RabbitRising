using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplaySystem : MonoBehaviour
{
    [SerializeField] Text timeDisplayText; 

    // Static
    public static bool timeEnabled = false;
    public static float elapsedTime = 0;

    void Start()
    {
        StartTimer();
    }

    public void StartTimer() 
    {
        elapsedTime = 0;
        timeEnabled = true;
        StartCoroutine(UpdateTimer());
    }

    public void StopTimer() 
    {
        timeEnabled = false;
    }

    private IEnumerator UpdateTimer() 
    {
        while(timeEnabled) 
        {
            elapsedTime += Time.deltaTime;
            timeDisplayText.text = TimeSpan.FromSeconds(elapsedTime).ToString("mm':'ss':'ff");
            yield return null;
        }
    }
}