using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnvironment : Spawn {

    [SerializeField]
    private GameObject leftWall;

    [SerializeField]
    private GameObject rightWall;

    [SerializeField]
    private GameObject backGround;

    [SerializeField]
    private List<GameObject> environment;

    [SerializeField]
    private float platformHeight = 0.35f;

    [SerializeField]
    private float wallsGap = 15.00f;

    [SerializeField]
    private float backGroundgap = 15.00f;

    // Use this for initialization
    void Start()
    {
        environment = new List<GameObject>();

        for (int i = 0; i < 18; i++)
        {
            AddToObjectList(leftWall, wallsGap);
            AddToObjectList(rightWall, wallsGap);
            AddToObjectList(backGround, backGroundgap);
        }
    }

    private void AddToObjectList(GameObject obj,float gap)
    {
         GameObject spwanObject = GameObject.Instantiate(obj);
         spwanObject.transform.parent = transform;
         spwanObject.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + gap, obj.transform.position.z);
         spwanObject.transform.rotation = obj.transform.rotation;
         spwanObject.transform.localScale = obj.transform.localScale;
        if(environment.Count<=36)
         environment.Add(spwanObject);
        else
        {
            for (int i = 0; i < 3; i++)
            {
                Destroy(environment[i]);
                environment.RemoveAt(i);
            }
           environment.Add(spwanObject);
        }
    }

    public void SpawnObject()
    {
        AddToObjectList(leftWall, wallsGap);
        AddToObjectList(rightWall, wallsGap);
        AddToObjectList(backGround, backGroundgap);
        wallsGap += 15.0f;
        backGroundgap += 15.0f;
    }

}
