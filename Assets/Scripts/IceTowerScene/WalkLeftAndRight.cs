using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkLeftAndRight : KeyInput
{

    private float playerSpeed = 15.0f;

    void Update()
    {
        InputKeys();
    }


    public void Walking(ref Rigidbody playerBody)
    {
        Vector3 walkX;

        walkX = Vector3.right * GetXAxis() * playerSpeed * Time.deltaTime;

        playerBody.transform.Translate(walkX);

    }
}
