using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovingWall : MonoBehaviour
{
    enum StartDitection {
        Top,
        Down
    }
    [Range(0,30)]
    [SerializeField] float moveDistance;
    [SerializeField] float moveSpeed;
    [SerializeField] StartDitection direction; 

    // Local
    private bool isOnEdit = true;
    private bool moveDirection = true;
    private Vector2 bottomPositionA;
    private Vector2 topPositionA; 
    private Vector2 bottomPositionB;  
    private Vector2 topPositionB;

    private void Start()
    {
        moveDirection = direction == StartDitection.Down ? false : true;
        isOnEdit = false;

        bottomPositionA = new Vector2( transform.position.x, transform.position.y - 1.937f);
        bottomPositionB = new Vector2( transform.position.x, bottomPositionA.y - moveDistance);
        topPositionA    = new Vector2( transform.position.x, transform.position.y + 1.937f);
        topPositionB    = new Vector2( transform.position.x, topPositionA.y + moveDistance);
    }

    private void FixedUpdate()
    {
        PlatformMove();
    }

    void PlatformMove()
    {
        bottomPositionA = new Vector2( transform.position.x, transform.position.y - 1.937f);
        topPositionA    = new Vector2( transform.position.x, transform.position.y + 1.937f);

        if (transform.position.y < topPositionB.y && moveDirection) {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        } else {
            moveDirection = false;
        }

        if (transform.position.y > bottomPositionB.y && !moveDirection) {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime); 
        } else {
            moveDirection = true;
        }
       
    }

    private void OnDrawGizmos()
    {
        if (isOnEdit)
        {
            bottomPositionA = new Vector2( transform.position.x, transform.position.y - 1.937f);
            bottomPositionB = new Vector2( transform.position.x, bottomPositionA.y - moveDistance);
            topPositionA    = new Vector2( transform.position.x, transform.position.y + 1.937f);
            topPositionB    = new Vector2( transform.position.x, topPositionA.y + moveDistance);
        }
        
        Gizmos.color = Color.green;
        Gizmos.DrawLine(bottomPositionA, bottomPositionB);
        Gizmos.DrawWireSphere(bottomPositionB, 0.3f);     
        Gizmos.DrawLine(topPositionA, topPositionB);
        Gizmos.DrawWireSphere(topPositionB, 0.3f);
    }
}
