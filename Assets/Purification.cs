using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purification : MonoBehaviour
{
    // The tag of the object that triggers the destruction
    public string targetTag = "WaterDrop";

    // Ensure both objects have colliders and at least one of them has a Rigidbody component

    void OnTriggerEnter(Collider other)
    {
        // Check if the other object has the target tag
        if (other.CompareTag(targetTag))
        {
            // Destroy the other object (WaterDrop)
            Destroy(other.gameObject);
            // Destroy this object (the object this script is attached to)
            Destroy(gameObject);
        }
    }
}
