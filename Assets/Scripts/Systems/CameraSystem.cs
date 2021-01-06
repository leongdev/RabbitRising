using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [Header("[CAMERA SETTINGS]")]
    [SerializeField] private bool canFollowTarget;
    [SerializeField] private bool canShake;
    [SerializeField] private bool canDebugShake;
    [SerializeField] private bool canUseBounds;

    [Header("[SETUP OBJECTS]")]
    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform defaultSlider;
    [SerializeField] private Transform defaultPivot;
    [SerializeField] private Transform defaultTarget;
    [Space]

    [Header("[CAMERA SYSTEM]")]
    [Range(0, 2)]
    [SerializeField] private float smoothY;
    [Range(0, 2)]
    [SerializeField] private float smoothX;
    [Space]

    [Header("[SHAKE CAMERA SETTINGS]")]
    [Range(0, 1)]
    [SerializeField] float shakePower;
    [Range(0, 1)]
    [SerializeField] float shakeDuration;

    [Header("[BOUND SETTINGS]")]
    [SerializeField] private Vector2 minCameraPos;
    [SerializeField] private Vector2 maxCameraPos;
    [SerializeField] private Vector2 offsetPos;

    //Local
    Vector3 velocity;
    Transform initialPosition;

    // Static
    public static float shakeTimer;
    public static float shakeAmount;
    public static bool shakeLogicKey = true;
    public static Transform target;

    private void Start()
    {
        if (defaultTarget) SetTarget(defaultTarget);
        if (defaultSlider) initialPosition = defaultSlider;
        
        mainCamera.transform.position = new Vector3(0,0,-10);
    }

    void FixedUpdate()
    {
        if (canFollowTarget) FollowTarget();
        if (canUseBounds) SetBounds();
        if (canShake) CameraShake();
    }

    void CameraShake() 
    {
        if (shakeTimer >= 0)
        {
            Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
            defaultPivot.position = new Vector3(
                defaultPivot.position.x + shakePos.x,
                defaultPivot.position.y + shakePos.y,
                defaultPivot.position.z);
            shakeTimer -= Time.deltaTime;
        }
        else if (shakeLogicKey)
        {
            defaultPivot.position = initialPosition.position;
            shakeLogicKey = false;
        }

        if (canDebugShake)
        {
            if (Input.GetKeyDown(KeyCode.P)) ShakeCameraCustom(shakePower, shakeDuration);
        }
    }

    /// <summary>
    /// This method can make the camera follow a target
    /// </summary>
    private void FollowTarget()
    {
        if (!target) return;
        float posX = Mathf.SmoothDamp(defaultSlider.position.x, target.transform.position.x, ref velocity.x, smoothX);
        float posY = Mathf.SmoothDamp(defaultSlider.position.y, target.transform.position.y, ref velocity.y, smoothY);
        defaultSlider.position = new Vector2(posX, posY);
    }

    /// <summary>
    /// This method can set bounds to the camera
    /// </summary>
    private void SetBounds()
    {
        defaultSlider.position = new Vector2(
            Mathf.Clamp(defaultSlider.position.x, minCameraPos.x, maxCameraPos.x),
            Mathf.Clamp(defaultSlider.position.y, minCameraPos.y, maxCameraPos.y));
    }

    /// <summary>
    /// This method can set new target to the camera
    /// </summary>
    /// <param name="newTarget"> Camera Target </param>
    public static void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    /// <summary>
    /// This method can change the follow target state
    /// </summary>
    /// <param name="newState"></param>
    public void SetFollowState(bool newState)
    {
        canFollowTarget = newState;
    }

    /// <summary>
    /// Debug bounds
    /// </summary>
    private void OnDrawGizmos()
    {
        if (canUseBounds)
        {
            Gizmos.color = Color.yellow;

            Vector2 LDown = new Vector3(minCameraPos.x, minCameraPos.y);
            Vector2 LUp = new Vector3(minCameraPos.x, maxCameraPos.y);

            Vector2 RDown = new Vector3(maxCameraPos.x, minCameraPos.y);
            Vector2 RUp = new Vector3(maxCameraPos.x, maxCameraPos.y);

            Gizmos.DrawLine(LDown, RDown);
            Gizmos.DrawLine(LUp, RUp);

            Gizmos.DrawLine(LUp, LDown);
            Gizmos.DrawLine(RDown, RUp);
        }
    }

    /// <summary>
    /// This method can trigger shake
    /// </summary>
    /// <param name="shakePower"> The intensity of the shake </param>
    /// <param name="shakeDuration"> The duration of the shake </param>
    public static void ShakeCamera()
    {
        shakeLogicKey = true;
        shakeAmount = 0.2f;
        shakeTimer = 0.3f;
    }

    /// <summary>
    /// This method can trigger shake
    /// </summary>
    /// <param name="shakePower"> The intensity of the shake </param>
    /// <param name="shakeDuration"> The duration of the shake </param>
    public static void ShakeCameraCustom(float shakePower, float shakeDuration)
    {
        shakeLogicKey = true;
        shakeAmount = shakePower;
        shakeTimer = shakeDuration;
    }

    /// <summary>
    /// This method can change the chake pivot
    /// </summary>
    /// <param name="newShakePivot"> The shake pivot </param>
    public void SetShakePivot(Transform newShakePivot)
    {
        defaultPivot = newShakePivot;
    }
}
