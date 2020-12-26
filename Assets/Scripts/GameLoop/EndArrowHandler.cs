using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndArrowHandler : MonoBehaviour
{
    [Header("Arrow Settings")]
    [SerializeField] float rotationSpeed;
    [SerializeField] float minDistance;
    [SerializeField] GameObject endPortal;
    [SerializeField] GameObject arrowIndicator;
    [Header("Debug Settings")]
    [SerializeField] bool debug;
    [SerializeField] Color debugColor;

    private void Update()
    {
        if(Vector2.Distance(arrowIndicator.transform.position, endPortal.transform.position) > minDistance)
        {
            Vector3 vectorToTarget = endPortal.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
            arrowIndicator.SetActive(true);
        }
        else
        {
            arrowIndicator.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        if (debug)
        {
            Gizmos.color = debugColor;
            Gizmos.DrawLine(transform.position, endPortal.transform.position);
            Gizmos.DrawWireSphere(endPortal.transform.position, minDistance);
        }
    }
}
