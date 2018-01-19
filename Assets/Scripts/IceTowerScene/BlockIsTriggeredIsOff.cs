using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockIsTriggeredIsOff : MonoBehaviour {

    [SerializeField]
    private Rigidbody playerBody;

    [SerializeField]
    private BoxCollider platformCollider;

    [SerializeField]
    private CreatePlatforms createPlatforms;

    [SerializeField]
    private SpawnEnvironment spawnEnvironment;

    [SerializeField]
    private Jump jump;

    [SerializeField]
    private bool scoresAdded = false;

    [SerializeField]
    private Score score;

    void Start()
    {
        jump = GameObject.Find("Player").GetComponent<Jump>();
        spawnEnvironment = GameObject.Find("Walls").GetComponent<SpawnEnvironment>();
        createPlatforms = GetComponentInParent<CreatePlatforms>();
        score = GameObject.Find("GUI").GetComponent<Score>();
        playerBody = GameObject.Find("Player").GetComponent<Rigidbody>();
        platformCollider = GetComponent<BoxCollider>();
    }

    void FixedUpdate()
    {
        OnOffCollider();
    }

    private void OnOffCollider()
    {
        if (playerBody.transform.position.y > this.transform.position.y + 1.0f)
        {
            if (!scoresAdded)
            {
                score.AddScore(10, jump.GetDoubleJumpIter());
                createPlatforms.SpawnObject();
                if(score.GetCurrentPlatform() == 0)
                {
                    spawnEnvironment.SpawnObject();
                }
            }
            platformCollider.isTrigger = false;
            platformCollider.transform.gameObject.tag = "canJump";
            scoresAdded = true;
        }
        else
        {
            platformCollider.isTrigger = true;
            platformCollider.transform.gameObject.tag = "CantJump";
        }

    }

	
}
