using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : KeyInput
{
    [SerializeField]
    private float playerJump;

    [SerializeField]
    private float timerToNextDoubleJump = 1.5f;

    private const float MINHEIGHTVELOCITY = 1000f;

    private const float MAXHEIGHTVELOCITY = 1200f;

    [SerializeField]
    private WalkLeftAndRight walkLeftAndRight;

    [SerializeField]
    private Score score;

    [SerializeField]
    private int doubleJumpIter = 1;

    private const float RAYLENGHT = 2.0f;

    void Start()
    {
        playerJump = MINHEIGHTVELOCITY;
        score = GameObject.Find("GUI").GetComponent<Score>();
        walkLeftAndRight = GetComponent<WalkLeftAndRight>();
    }

    public void Jumping(ref Rigidbody playerBody)
    {
        if(walkLeftAndRight.GetPlayerSpeed()<= 9.0f || timerToNextDoubleJump <=0.0f)
        {
            playerJump = MINHEIGHTVELOCITY;
            doubleJumpIter = 1;
            score.SetMultiplyPoints(1);
        }

        if (GetJumpValue() && IsOnGrounded(ref playerBody) && playerBody.velocity.y <= 0.0f && playerBody.velocity.y >= -1.0f)
        {

            if (walkLeftAndRight.GetPlayerSpeed() >= 9.0f)
            {
                playerJump = MAXHEIGHTVELOCITY;
                timerToNextDoubleJump = 1.5f;
                if(doubleJumpIter <= 10)
                    doubleJumpIter++;
            }

            playerBody.AddForce(Vector3.up * playerJump * Time.deltaTime,ForceMode.Impulse);
        }
        if(IsOnGrounded(ref playerBody))
        {
            walkLeftAndRight.SetPlayerSpeed();
        }
        if (timerToNextDoubleJump >= 0.0f)
        timerToNextDoubleJump -= (0.3f * Time.deltaTime);
    }

    private bool IsOnGrounded(ref Rigidbody playerBody)
    {
        Ray rayToDown = new Ray(playerBody.transform.position, -playerBody.transform.up);

        RaycastHit hit;

        Debug.DrawRay(playerBody.transform.position, -playerBody.transform.up * RAYLENGHT);
        
        if(Physics.Raycast(rayToDown, out hit,RAYLENGHT))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("canJump"))
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
            score.AddMultiplyPoints(doubleJumpIter);
        }
    }

    public int GetDoubleJumpIter()
    {
        return doubleJumpIter;
    }
}
