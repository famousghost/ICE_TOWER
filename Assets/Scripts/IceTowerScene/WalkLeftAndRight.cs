using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkLeftAndRight : KeyInput
{
    [SerializeField]
    private float playerSpeed = 5.0f;

    [SerializeField]
    private float playerSpeedIce = 1.5f;

    [SerializeField]
    private float playerMaxSpeed = 10.0f;

    [SerializeField]
    private float normalPlayerSpeed = 5.0f;

    [SerializeField]
    private float timeToFallDown = 0.1f;

    [SerializeField]
    private GameObject platform;


    void Start()
    {
        platform = GameObject.Find("BigPlaftform").GetComponent<GameObject>();
    }


    void OnCollisionEnter(Collision collision)
    {
        platform = collision.gameObject;
        if (platform.tag != "Ice")
            playerMaxSpeed = 10.0f;
    }


    public void Walking(ref Rigidbody playerBody)
    {
        Vector3 walkX;

        if (platform != null)
        {
            if (platform.tag == "Sand")
            {
                platform.transform.position = Vector3.Lerp(platform.transform.position, new Vector3(platform.transform.position.x, platform.transform.position.y - 5.0f, platform.transform.position.z), timeToFallDown * Time.deltaTime);
            }
            if (platform.tag == "Ice")
                playerMaxSpeed = 15.0f;
        }
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
            if (playerSpeed <= playerMaxSpeed)
            {
                playerSpeed += 0.1f;
            }
        }
        else
        {
            if(playerSpeed > 5.0f)
                playerSpeed -= 1.0f;
        }
    }
}
