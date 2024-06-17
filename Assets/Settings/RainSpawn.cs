using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class RainSpawn : MonoBehaviour
{
    public GameObject rainDrop; // The object you want to drop
    public int numberOfObjects = 10; // The number of objects to drop
    public float dropHeight = 50f; // The height from which the objects will drop
    public float minX = -10f; // Minimum X position of dropping area
    public float maxX = 10f; // Maximum X position of dropping area
    public float minZ = -10f; // Minimum Z position of dropping area
    public float maxZ = 10f; // Maximum Z position of dropping area

    void FixedUpdate()
    {
        DropObjects();
    }

    // Function to drop objects
    public void DropObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), dropHeight, Random.Range(minZ, maxZ));
            Instantiate(rainDrop, randomPosition, Quaternion.identity);
        }
    }

    // Gismo for the era
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3((minX + maxX) / 2, dropHeight, (minZ + maxZ) / 2), new Vector3(maxX - minX, 0, maxZ - minZ));
    }
}