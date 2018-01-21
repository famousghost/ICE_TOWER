using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : KeyInput
{
    [SerializeField]
    private float playerJump = 1000.0f;

    [SerializeField]
    private CreatePlatforms createPlatforms;

    [SerializeField]
    private WalkLeftAndRight walkLeftAndRight;

    [SerializeField]
    private Score score;

    [SerializeField]
    private int doubleJumpIter = 1;

    private const float RAYLENGHT = 2.0f;

    void Start()
    {
        score = GameObject.Find("GUI").GetComponent<Score>();
        walkLeftAndRight = GetComponent<WalkLeftAndRight>();
        createPlatforms = GameObject.Find("Platforms").GetComponent<CreatePlatforms>();
    }

    void Update()
    {
        InputKeys();
    }

    public void Jumping(ref Rigidbody playerBody)
    {
        if(walkLeftAndRight.GetPlayerSpeed()<= 9.0f)
        {
            playerJump = 1000.0f;
            doubleJumpIter = 1;
            score.SetMultiplyPoints(1);
        }

        if (GetJumpValue() && IsOnGrounded(ref playerBody) && playerBody.velocity.y == 0)
        {

            if (walkLeftAndRight.GetPlayerSpeed() >= 9.0f)
            {
                playerJump = 1500.0f;
                doubleJumpIter++;
            }

            playerBody.AddForce(Vector3.up * playerJump * Time.deltaTime,ForceMode.Impulse);
        }
        if(IsOnGrounded(ref playerBody))
        {
            walkLeftAndRight.SetPlayerSpeed();
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

    private void MultiplyPoints()
    {
        if(doubleJumpIter > 1)
        {
            if(score.GetMultiply()<= 10)
                score.AddMultiplyPoints(doubleJumpIter);
        }
    }

    public int GetDoubleJumpIter()
    {
        return doubleJumpIter;
    }
}
