using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadFlower : MonoBehaviour
{
    void Start()
    {
        SetTag("Dead_Flower");
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Gray_Zone")
        {
            SetTag("Flower");
            Debug.Log("not dead");
        }
    }

    private void SetTag(string tag)
    {
        gameObject.tag = tag;
        foreach (Transform child in transform)
        {
            child.gameObject.tag = tag;
        }
    }
}