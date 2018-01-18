using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlatformsState
{
    Normal = 0,
    Sand,
    Ice
};

public class CreatePlatforms : MonoBehaviour {

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
    private float platformPosition;

    [SerializeField]
    private int platformIter = 1;

    [SerializeField]
    private int height = 1;

	// Use this for initialization
	void Start () {
        platforms = new List<GameObject>();

        for (int i = 0; i < 8; i++)
        {
            SpwanPlatform();
        }
        
    }

    private void AddPlatformToListAndSpawn(float platformWidth,float platfromPosition,float platformHeight)
    {


        GameObject spwanPlatform = GameObject.Instantiate(platform);
        spwanPlatform.transform.parent = transform;
        spwanPlatform.transform.position = new Vector3(platfromPosition, platformHeight, 6.0f);
        spwanPlatform.transform.localScale = new Vector3(platformWidth,1.0f,3.0f);
        if(platformIter%20==0)
        {
            platformsState++;
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


        platformIter++;
        height++;
    }

    public void SpwanPlatform()
    {

         platformPosition = Random.Range(14.0f, -14.0f);
         platformWidth = Random.Range(5.0f, 10.0f);
         platformHeight = 4.0f * height;

         AddPlatformToListAndSpawn(platformWidth, platformPosition, platformHeight);
    }

    private void DestroyPlatform()
    {
        Destroy(platforms[0]);
        platforms.RemoveAt(0);
    }

}
