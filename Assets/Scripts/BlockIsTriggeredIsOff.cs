using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockIsTriggeredIsOff : MonoBehaviour {

    [SerializeField]
    private Rigidbody playerBody;

    [SerializeField]
    private BoxCollider platformCollider;

    [SerializeField]
    private bool scoresAdded = false;

    [SerializeField]
    private Scores scores;

    void Start()
    {
        scores = GameObject.Find("GUI").GetComponent<Scores>();
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
                scores.AddScore(10);
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
