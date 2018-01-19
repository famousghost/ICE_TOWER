using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlatformsState
{
    Normal = 0,
    Sand,
    Ice
};

abstract public class Spawn : MonoBehaviour {

    void AddToObjectList(float platformWidth, float platfromPosition, float platformHeight)
    {

    }

    void AddToObjectList(GameObject obj, float gap)
    {

    }

    void SpawnObject()
    {

    }
}
