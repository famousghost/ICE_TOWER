using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkLeftAndRight : KeyInput
{
    [SerializeField]
    private float playerSpeed = 5.0f;

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

    public float GetPlayerSpeed()
    {
        return playerSpeed;
    }

    public void SetPlayerSpeed()
    {
        if (GetXAxis() != 0)
        {
            if (playerSpeed <= 10.0f)
                playerSpeed += 0.1f;
        }
        else
        {
            if(playerSpeed > 5.0f)
                playerSpeed -= 1.0f;
        }
    }
}
