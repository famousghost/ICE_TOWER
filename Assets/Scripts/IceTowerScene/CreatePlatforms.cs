using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatforms : Spawn
{

    [SerializeField]
    private GameObject platform;

    [SerializeField]
    private PlatformsState platformsState;

    [SerializeField]
    private List<GameObject> platforms;

    [SerializeField]
    private float platformHeight;

    [SerializeField]
    private float platformWidth;

    [SerializeField]
    private float platformMaxWidth = 10.0f;

    private const float MINPLATFORMWIDTH = 5.0f;

    private const float MINPLATFORMPOSITION = -14.0f;

    private const float MAXPLATFORMPOSITION = 14.0f;

    private const float PLATFORMGAP = 4.0f;

    [SerializeField]
    private float platformPosition;

    [SerializeField]
    private int platformStateIter = 1;

    [SerializeField]
    private int height = 1;

	// Use this for initialization
	void Start () {
        platforms = new List<GameObject>();

        for (int i = 0; i < 8; i++)
        {
            SpawnObject();
        }
        
    }

    private void AddToObjectList(float platformWidth,float platfromPosition,float platformHeight)
    {


        GameObject spwanPlatform = GameObject.Instantiate(platform);
        spwanPlatform.transform.parent = transform;
        spwanPlatform.transform.position = new Vector3(platfromPosition, platformHeight, 6.0f);
        spwanPlatform.transform.localScale = new Vector3(platformWidth,1.0f,3.0f);
        if(platformStateIter%20==0)
        {
            if (platformMaxWidth > 7.0f)
                platformMaxWidth -= 0.5f;
            if (platformsState != PlatformsState.Ice)
                platformsState++;
            else
                platformsState = PlatformsState.Normal;
        }

        switch (platformsState)
        {
            case PlatformsState.Normal:
                spwanPlatform.GetComponent<Renderer>().material.color = Color.grey;
                break;
            case PlatformsState.Ice:
                spwanPlatform.GetComponent<Renderer>().material.color = Color.blue;
                break;
            case PlatformsState.Sand:
                spwanPlatform.GetComponent<Renderer>().material.color = Color.yellow;
                break;
            default:
                break;
        }

        if (platforms.Count < 16)
        {
            platforms.Add(spwanPlatform);
        }
        else
        {
            DestroyPlatform();
            platforms.Add(spwanPlatform);
        }

        platformStateIter++;
        height++;
    }

    public void SpawnObject()
    {

         platformPosition = Random.Range(MINPLATFORMPOSITION, MAXPLATFORMPOSITION);
         platformWidth = Random.Range(MINPLATFORMWIDTH, platformMaxWidth);
         platformHeight = PLATFORMGAP * height;
         AddToObjectList(platformWidth, platformPosition, platformHeight);

    }

    private void DestroyPlatform()
    {
        Destroy(platforms[0]);
        platforms.RemoveAt(0);
    }

}
