using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkLeftAndRight : KeyInput
{
    [SerializeField]
    protected float playerSpeed = 5.0f;

    void Update()
    {
        InputKeys();
    }


    public void Walking(ref Rigidbody playerBody)
    {
        if(GetXAxis() != 0)
        {
            if (playerSpeed <= 10.0f)
            playerSpeed += 0.1f;
        }
        else
        {
            playerSpeed = 5.0f;
        }

        Vector3 walkX;

        walkX = Vector3.right * GetXAxis() * playerSpeed * Time.deltaTime;

        playerBody.transform.Translate(walkX);

    }
}
