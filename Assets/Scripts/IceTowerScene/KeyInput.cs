using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInput : MonoBehaviour {

    [SerializeField]
    private float walkXAxis;

    [SerializeField]
    private bool jumpBool = false;

    [SerializeField]
    private bool isPause = false;

    [SerializeField]
    private KeyCode jumpKey = KeyCode.Space;

    [SerializeField]
    private KeyCode pauseKey = KeyCode.Escape;

    void Update()
    {
        InputKeys();
    }


    public void InputKeys()
    {
        walkXAxis = Input.GetAxis("Horizontal");
        jumpBool = Input.GetKeyDown(jumpKey);
        if (Input.GetKeyDown(pauseKey))
            isPause = !isPause;
    }

    public bool GetJumpValue()
    {
        return jumpBool;
    }

    public float GetXAxis()
    {
        return walkXAxis;
    }

    public bool GetPauseGameValue()
    {
        return isPause;
    }

    public void SetAxis(float walkXAxis)
    {
        this.walkXAxis = walkXAxis;
    }
}
