using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : GameOver {

    [SerializeField]
    private Rigidbody playerBody;

    [SerializeField]
    private Canvas GUICanvas;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private float cameraPosition = 12.0f;

    [SerializeField]
    private float cameraPositionToSpawnEnvironment = 12.0f;

    [SerializeField]
    private bool timerStop = false;

    [SerializeField]
    private const float CAMERAPOSTOTOPSCREEN = 7.0f;

    [SerializeField]
    private float spawnPlatformTime = 4.0f;

    [SerializeField]
    private float spawnWallsTime = 10.0f;

    [SerializeField]
    private const float TIMER = 0.4f;

    [SerializeField]
    private float lerpTime = 2.0f;

    [SerializeField]
    private float cameraSpeed = 2.5f;

    [SerializeField]
    private float timerToUpSpeed = 25.0f;

	// Use this for initialization
	void Start () {
        ResumeGame();
        playerBody = GameObject.Find("Player").GetComponent<Rigidbody>();
        GUICanvas = GameObject.Find("GUI").GetComponentInChildren<Canvas>();
        mainCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        CheckGameOver();
    }
    
    private void Move()
    {
        if(timerToUpSpeed<=0.0f)
        {
            timerToUpSpeed = 10.0f;
            if (cameraSpeed < 10.0f)
            {
                spawnWallsTime -= 0.5f;
                cameraSpeed += 2.5f;
                
            }
            else
            {
                timerStop = true;
            }
        }
        if (playerBody.transform.position.y <= mainCamera.transform.position.y + CAMERAPOSTOTOPSCREEN)
        {
            Vector3 camSpeed = Vector3.up * cameraSpeed * Time.deltaTime;
            mainCamera.transform.Translate(camSpeed);
        }
        else
        {
            float mainCameraHeight = playerBody.transform.position.y;
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position,new Vector3(0.0f, mainCameraHeight, -10.0f),lerpTime * Time.deltaTime);
        }
        if(!timerStop)
            timerToUpSpeed = timerToUpSpeed - TIMER * Time.deltaTime;

    }


    private void CheckGameOver()
    {
        if(playerBody.transform.localPosition.y < mainCamera.transform.localPosition.y - 14.0f)
        {
            OverGame();
            GUICanvas.enabled = true;
        }
    }
}
