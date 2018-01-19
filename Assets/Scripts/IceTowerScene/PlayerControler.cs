using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    [SerializeField]
    private Rigidbody playerBody;

    [SerializeField]
    private WalkLeftAndRight walkingLeftAndRight;

    [SerializeField]
    private Jump jump;


    // Use this for initialization
    void Start () {
        playerBody = GetComponent<Rigidbody>();
        walkingLeftAndRight = GetComponent<WalkLeftAndRight>();
        jump = GetComponent<Jump>();
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
    }

    private void PlayerMove()
    {
        walkingLeftAndRight.Walking(ref playerBody);
        jump.Jumping(ref playerBody);
    }
}
