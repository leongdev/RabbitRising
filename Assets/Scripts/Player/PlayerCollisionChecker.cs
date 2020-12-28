using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionChecker : MonoBehaviour
{

    [HideInInspector]
    public bool left;
    [HideInInspector]
    public bool right;
    [HideInInspector]
    public bool bottom;
    [HideInInspector]
    public bool leftSlider;
    [HideInInspector]
    public bool rightSlider;

    // Local
    Rigidbody2D playerRB;
    PlayerAttributes attributes;

    private void Awake()
    {
        attributes = this.GetComponent<PlayerHandler>().attributes;
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
        if (Check2DCollition(GetOverlapPosition(new Vector2(attributes.leftCircleOffsetX, attributes.leftCircleOffsetY), playerRB.transform), attributes.colliderRadius, attributes.groundLayer))
        {
            left = true;
        }
        else
        {
            left = false;
        }

        // RIGHT
        if (Check2DCollition(GetOverlapPosition( new Vector2(attributes.rightCircleOffsetX, attributes.rightCircleOffsetY), playerRB.transform), attributes.colliderRadius, attributes.groundLayer))
        {
            right = true;
        }
        else
        {
            right = false;
        }

        // LEFT SLIDER
        if (Check2DCollition(GetOverlapPosition(new Vector2(attributes.leftCircleOffsetX, attributes.leftCircleOffsetY), playerRB.transform), attributes.colliderRadius, attributes.wallSliderLayer))
        {
            leftSlider = true;
        }
        else
        {
            leftSlider = false;
        }

        // RIGHT SLIDER  
        if (Check2DCollition(GetOverlapPosition(new Vector2(attributes.rightCircleOffsetX, attributes.rightCircleOffsetY), playerRB.transform), attributes.colliderRadius, attributes.wallSliderLayer))
        {
            rightSlider = true;
        }
        else
        {
            rightSlider = false;
        }

        //BOTTOM
        if (Check2DCollition(GetOverlapPosition(new Vector2(attributes.bottomCircleOffsetX, attributes.bottomCircleOffsetY), playerRB.transform), attributes.colliderRadius, attributes.groundLayer))
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
        if (attributes) 
        {
            Gizmos.color = attributes.leftColor;
            //LEFT
            Gizmos.DrawWireSphere(GetOverlapPosition(new Vector2(attributes.leftCircleOffsetX, attributes.leftCircleOffsetY), this.transform.GetChild(0).transform), attributes.colliderRadius);
            Gizmos.color = attributes.rightColor;
            //RIGHT
            Gizmos.DrawWireSphere(GetOverlapPosition(new Vector2(attributes.rightCircleOffsetX, attributes.rightCircleOffsetY), this.transform.GetChild(0).transform), attributes.colliderRadius);
            Gizmos.color = attributes.bottomColor;
            //BOTTOM
            Gizmos.DrawWireSphere(GetOverlapPosition(new Vector2(attributes.bottomCircleOffsetX, attributes.bottomCircleOffsetY), this.transform.GetChild(0).transform), attributes.colliderRadius);
        }
    }
}
