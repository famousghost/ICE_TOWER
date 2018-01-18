using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    [SerializeField]
    private Rigidbody playerBody;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private float cameraPosition = 12.0f;

    [SerializeField]
    private float cameraPositionToSpawnEnvironment = 12.0f;

    [SerializeField]
    private SpawnEnvironment spawnEnvironment;

    [SerializeField]
    private CreatePlatforms spawnPlatforms;

    [SerializeField]
    private bool timerStop = false;

    [SerializeField]
    private const float CAMERAPOSTOTOPSCREEN = 7.0f;

    [SerializeField]
    private const float TIMER = 0.4f;

    [SerializeField]
    private float lerpTime = 2.0f;

    [SerializeField]
    private float cameraSpeed = 2.5f;

    [SerializeField]
    private float timerToUpSpeed = 10.0f;

	// Use this for initialization
	void Start () {
        playerBody = GameObject.Find("Player").GetComponent<Rigidbody>();
        spawnEnvironment = GameObject.FindGameObjectWithTag("Environment").GetComponent<SpawnEnvironment>();
        spawnPlatforms = GameObject.FindGameObjectWithTag("Platforms").GetComponent<CreatePlatforms>();

        mainCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
    }
    
    private void Move()
    {
        if(timerToUpSpeed<=0.0f)
        {
            timerToUpSpeed = 10.0f;
            if (cameraSpeed < 10.0f)
            {
                cameraSpeed *= 2f;
                
            }
            else
            {
                timerStop = true;
            }
        }
        Debug.Log(Screen.height);
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
        CheckCameraPosition();
        if(!timerStop)
            timerToUpSpeed = timerToUpSpeed - TIMER * Time.deltaTime;

    }

    private void CheckCameraPosition()
    {
        if(mainCamera.transform.localPosition.y > cameraPosition)
        {
            cameraPosition = (mainCamera.transform.localPosition.y + 4.0f);
            spawnPlatforms.SpwanPlatform();     
        }  
        if(mainCamera.transform.localPosition.y > cameraPositionToSpawnEnvironment)
        {
            cameraPositionToSpawnEnvironment = (mainCamera.transform.localPosition.y + 10.0f);
            spawnEnvironment.SpawEnvi();
        }
    }
}
