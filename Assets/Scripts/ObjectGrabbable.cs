using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    private Transform objectDropPointTransform;

    private void Update()
    {
        objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
    }

    public void Drop(Transform objectDropPointTransform)
    {
        this.objectGrabPointTransform = objectDropPointTransform;
        
        objectRigidbody.useGravity = true;
        
        this.objectGrabPointTransform = null;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            objectRigidbody.MovePosition(objectGrabPointTransform.position);
        }
    }
}
