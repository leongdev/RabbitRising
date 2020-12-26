using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cineCamera;

    static CinemachineBasicMultiChannelPerlin noise;

    static bool startCount = false;
    static float initialFrequency = 0;
    static float time = 1;

    private void Awake()
    {
        noise = cineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Update()
    {
        if (startCount)
        {
            noise = cineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            initialFrequency -= Time.deltaTime * time;
            noise.m_FrequencyGain = initialFrequency;

            if(initialFrequency <= 0)
            {
                startCount = false;
                noise.m_FrequencyGain = 0;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="amplitude"></param>
    /// <param name="frequency"></param>
    /// <param name="timeMultiplier"></param>
    public static void ShakeCameraWith(float amplitude, float frequency, float timeMultiplier)
    {
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = frequency;
        initialFrequency = frequency;
        time = timeMultiplier;
        startCount = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public static void ShakeCamera()
    {
        noise.m_AmplitudeGain = 3;
        noise.m_FrequencyGain = 1;
        initialFrequency = 1;
        time = 2f;
        startCount = true;
    }

    public void ReplaceTarget(Transform target)
    {
        cineCamera.Follow = target;
    }
}
