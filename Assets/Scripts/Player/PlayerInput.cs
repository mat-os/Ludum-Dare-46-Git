using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float HorizontalInput { get; private set; }
    public bool ActionInput { get; private set; }
    public bool ActionInputPressed { get; private set; }
    public static bool CancelInput { get; private set; }

    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        ActionInput = Input.GetButtonDown("Jump");
        ActionInputPressed = Input.GetButton("Jump");
        CancelInput = Input.GetButtonDown("Cancel");
    }
}
