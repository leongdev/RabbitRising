using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputSystem : MonoBehaviour
{
    [SerializeField] bool firingJump;
    [SerializeField] bool firingDash;

    public static bool jump;
    public static bool dash;

    // Update is called once per frame
    void Update()
    {
        jump = Input.GetButtonDown("Jump");
        dash = Input.GetButtonDown("Dash");
    }
}
