using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : KeyInput
{

    private float playerJump = 1000.0f;

    private const float RAYLENGHT = 2.0f;

    void Update()
    {
        InputKeys();
    }

    public void Jumping(ref Rigidbody playerBody)
    {
        if(GetJumpValue() && IsOnGrounded(ref playerBody))
        {
            playerBody.AddForce(Vector3.up * playerJump * Time.deltaTime,ForceMode.Impulse);
        }
    }

    private bool IsOnGrounded(ref Rigidbody playerBody)
    {
        Ray rayToDown = new Ray(playerBody.transform.position, -playerBody.transform.up);

        RaycastHit hit;

        Debug.DrawRay(playerBody.transform.position, -playerBody.transform.up * RAYLENGHT);
        
        if(Physics.Raycast(rayToDown, out hit,RAYLENGHT))
        {
            if (hit.collider.tag == "canJump")
                return true;
            else
                return false;
        }
        return false;
    }
}
