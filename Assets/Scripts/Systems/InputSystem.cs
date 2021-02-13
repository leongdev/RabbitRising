using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private InputTypes type;
    public static bool Jump; 
    public static bool Dash;

    private enum InputTypes
    {
        Pc,
        Console,
        Mobile
    }

    private void Update()  
    {
        switch (type)
        {
            case InputTypes.Pc:
                Jump = Input.GetButtonDown("Jump");
                Dash = Input.GetButtonDown("Dash");
                break;
            case InputTypes.Console:
                Jump = Input.GetButtonDown("Jump");
                Dash = Input.GetButtonDown("Dash");
                break;
            case InputTypes.Mobile:
                Jump = GetMobileJump();
                Dash = GetMobileDash();
                break;
            default:
                break;
        } 
    }

    private static bool GetMobileJump()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x > Screen.width/2)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private static bool GetMobileDash()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                if (touch.position.x < Screen.width/2)
                {
                    return true;
                }
            }
        }
        return false;
    }

} 