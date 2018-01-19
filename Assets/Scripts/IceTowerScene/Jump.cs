using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : WalkLeftAndRight
{
    [SerializeField]
    private float playerJump = 1500.0f;

    [SerializeField]
    private CreatePlatforms createPlatforms;

    [SerializeField]
    private Score score;

    [SerializeField]
    private float currentScore = 0.0f;

    [SerializeField]
    private int doubleJumpIter = 0;

    private const float RAYLENGHT = 2.0f;

    void Start()
    {
        score = GameObject.Find("GUI").GetComponent<Score>();
        createPlatforms = GameObject.Find("Platforms").GetComponent<CreatePlatforms>();
    }

    void Update()
    {
        InputKeys();
    }

    public void Jumping(ref Rigidbody playerBody)
    {
        if(GetJumpValue() && IsOnGrounded(ref playerBody))
        {
            if (playerSpeed >= 9.0f)
            {
                playerJump = 1500.0f;
                doubleJumpIter++;
            }
            else
                playerJump = 1000.0f;

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
