using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionChecker : MonoBehaviour
{
    [Header("Collider Settings ")]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask wallSliderLayer;
    [SerializeField] float colliderRadius;
    [SerializeField] Vector2 leftCircleOffset;
    [SerializeField] Vector2 rightCircleOffset; 
    [SerializeField] Vector2 bottomCircleOffset;

    [Header("Collision Variables")]
    public bool left;
    public bool right;
    public bool bottom;
    public bool leftSlider;
    public bool rightSlider;
    [Header("Collision Debuggers")]
    [SerializeField] bool canDebugColliders;
    [SerializeField] Color leftColor;
    [SerializeField] Color rightColor;
    [SerializeField] Color bottomColor;

    Rigidbody2D playerRB;

    private void Awake()
    {
        playerRB = this.GetComponent<PlayerHandler>().playerRB;
    }

    /// <summary>
    /// This is the Collision Checker Update method
    /// </summary>
    /// <param name="debugColliders"></param>
    public void OnCheckCollisions()
    {
        PlayerColliders();
    }

    void PlayerColliders()
    {
        // LEFT
        if (Check2DCollition(GetOverlapPosition(leftCircleOffset, playerRB.transform), colliderRadius, groundLayer))
        {
            left = true;
        }
        else
        {
            left = false;
        }

        // RIGHT
        if (Check2DCollition(GetOverlapPosition(rightCircleOffset, playerRB.transform), colliderRadius, groundLayer))
        {
            right = true;
        }
        else
        {
            right = false;
        }

        // LEFT SLIDER
        if (Check2DCollition(GetOverlapPosition(leftCircleOffset, playerRB.transform), colliderRadius, wallSliderLayer))
        {
            leftSlider = true;
        }
        else
        {
            leftSlider = false;
        }

        // RIGHT SLIDER  
        if (Check2DCollition(GetOverlapPosition(rightCircleOffset, playerRB.transform), colliderRadius, wallSliderLayer))
        {
            rightSlider = true;
        }
        else
        {
            rightSlider = false;
        }

        //BOTTOM
        if (Check2DCollition(GetOverlapPosition(bottomCircleOffset, playerRB.transform), colliderRadius, groundLayer))
        {
            bottom = true;
        }
        else
        {
            bottom = false;
        }
    }



    /// <summary>
    /// This Method check if the Circle is colliding with the layer mask
    /// </summary>
    /// <param name="position"> Position of the Circle</param>
    /// <param name="layer"> Layer to be checked </param>
    /// <returns></returns>
    public bool Check2DCollition(Vector2 position, float radius, LayerMask layerMask)
    {
        return Physics2D.OverlapCircle(position, radius, layerMask);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="offset"></param>
    /// <param name="objectTransform"></param>
    /// <returns></returns>
    public Vector2 GetOverlapPosition(Vector2 offset, Transform objectTransform)
    {
        return new Vector2(objectTransform.position.x + offset.x, objectTransform.position.y + offset.y);
    }

    public void OnDrawGizmos() 
    {
        if (canDebugColliders)
        {
            Gizmos.color = leftColor;
            //LEFT
            Gizmos.DrawWireSphere(GetOverlapPosition(leftCircleOffset, this.transform.GetChild(0).transform), colliderRadius);
            Gizmos.color = rightColor;
            //RIGHT
            Gizmos.DrawWireSphere(GetOverlapPosition(rightCircleOffset, this.transform.GetChild(0).transform), colliderRadius);
            Gizmos.color = bottomColor;
            //BOTTOM
            Gizmos.DrawWireSphere(GetOverlapPosition(bottomCircleOffset, this.transform.GetChild(0).transform), colliderRadius);
        }
    }
}
