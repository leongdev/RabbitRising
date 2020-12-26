using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndPortalHandler : MonoBehaviour
{
    [SerializeField] float finishTimer;
    [SerializeField] bool enableTimer;
    [SerializeField] float localTime;
    [SerializeField] UnityEvent onEndLevel;

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enableTimer)
        {
            Time.timeScale = 0.3f;
            localTime += Time.deltaTime;

            if(localTime > finishTimer)
            {
                Time.timeScale = 1;
                enableTimer = false;
                onEndLevel.Invoke();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    public void SetEndTimer(bool index)
    {
        enableTimer = index;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetEndTimer(true);
        }
    }
}
