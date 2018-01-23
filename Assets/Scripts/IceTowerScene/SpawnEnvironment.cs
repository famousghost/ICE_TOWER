using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnvironment : Spawn {

    [SerializeField]
    private GameObject enviObject;

    [SerializeField]
    private List<GameObject> environment;

    [SerializeField]
    private float objectGap = 15.00f;

    // Use this for initialization
    void Start()
    {
        environment = new List<GameObject>();

        for (int i = 0; i < 10; i++)
        {
            SpawnObject();
        }
    }

    private void AddToObjectList(GameObject obj,float gap)
    {
         GameObject spwanObject = GameObject.Instantiate(obj);
         spwanObject.transform.parent = transform;
         spwanObject.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + gap, obj.transform.position.z);
         spwanObject.transform.rotation = obj.transform.rotation;
         spwanObject.transform.localScale = obj.transform.localScale;
        if(environment.Count<=20)
         environment.Add(spwanObject);
        else
        {
           Destroy(environment[0]);
           environment.RemoveAt(0);
           environment.Add(spwanObject);
        }
    }

    public void SpawnObject()
    {
        AddToObjectList(enviObject, objectGap);
        objectGap += 30.0f;
    }

}
