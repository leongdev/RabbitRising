using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttributes", menuName = "LeonGDev/PlayerAttributes", order = 1)]
public class PlayerAttributes : ScriptableObject
{
    [Header("MOVEMENT SETTINGS")]
    public float moveSpeed;

    [Header("JUMP SETTINGS")]
    public float jumpForce = 25;
    [Range(0, 30)]
    public float fallMultiplier = 6.4f;
    [Range(0, 30)]
    public float lowJumpMultiplier = 15.3f;

    [Header("WALL SLIDER SETTINGS")]
    public float wallSlideSpeed;
    [Range(0, 2)]
    public float xWallJumpForce;
    [Range(0, 2)]
    public float yWallJumpForce;

    [Header("WALL JUMP SETTINGS")]
    public float jumpWallCooldown;

    [Header("DASH SETTINGS")]
    public float dashSpeed;
    public float dashCooldown;

    [Header("COLLIDER SETTINGS")]
    public LayerMask groundLayer;
    public LayerMask wallSliderLayer;
    [Space]
    public float colliderRadius;
    public float leftCircleOffsetX;
    public float leftCircleOffsetY;
    public float rightCircleOffsetX;
    public float rightCircleOffsetY;
    public float bottomCircleOffsetX;
    public float bottomCircleOffsetY;
    [Space]
    public Color leftColor;
    public Color rightColor;
    public Color bottomColor;

    [Header("ANIMATION SETTINGS")]
    public float sensorThreshold;

    [Header("KIILL SETTINGS")]
    public float afterDieCounter = 0;
}
