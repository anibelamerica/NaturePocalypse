using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

public class SpawnCheck : MonoBehaviour
{

    //[SerializeField]
    [Range(0.0F, 5.0F)]
    public float minRange = 1.0F;

    public GameObject[] groundObjects;
    public GameObject[] wallObjects;

    public void GrabObjects()
    {
        groundObjects = GameObject.FindGameObjectsWithTag("GroundSpawn");
        Debug.Log("Number of existing ground objects: " + groundObjects.Length);
   
        wallObjects = GameObject.FindGameObjectsWithTag("WallSpawn");
        Debug.Log("Number of existing wall objects: " + wallObjects.Length);
       
    }

    //check if a given point is out of range of surrounding spawned ground objects
    public bool IsOutOfRange(Vector3 point, bool isHorizontal, float minRange)
    {
        GameObject[] objects = isHorizontal ? groundObjects : wallObjects;

        if (objects.Length == 0)
        {
            return true;
        }

        bool b1 = objects.Any(spawn => (spawn.transform.position - point).sqrMagnitude < (float)minRange);
        return !b1;
    }
}
