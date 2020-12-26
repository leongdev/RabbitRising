using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraTarget : MonoBehaviour
{
    [Header("Target Settings")]
    [SerializeField] Transform target;
    [SerializeField] Transform cameraTarget;
    public bool canFollowTarget = true;
    // Update is called once per frame

    Vector2 lastPosition;

    void FixedUpdate()
    {
        if (canFollowTarget) {
            cameraTarget.position = target.position;
            lastPosition = target.position;
        }
        else
        {
            cameraTarget.position = lastPosition;
        }
    }

    /// <summary>
    /// This method changes follow target state
    /// </summary>
    /// <param name="state"></param>
    public void SetFollowState(bool state)
    {
        canFollowTarget = state;
    }

    public void ShakeCamera()
    {
        CameraSystem.ShakeCamera();
    }
}
