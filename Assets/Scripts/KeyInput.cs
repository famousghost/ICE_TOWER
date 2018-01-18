using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour {

    private float walkXAxis;

    private bool jumpBool;

    private KeyCode jumpKey = KeyCode.Space;


    public void InputKeys()
    {
        walkXAxis = Input.GetAxis("Horizontal");
        jumpBool = Input.GetKeyDown(jumpKey);
    }

    public bool GetJumpValue()
    {
        return jumpBool;
    }

    public float GetXAxis()
    {
        return walkXAxis;
    }
}
