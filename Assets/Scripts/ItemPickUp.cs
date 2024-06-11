using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private Transform objectDropPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    public float pickUpDistance;
    private PlayerInput _playerInput;

    public Image prompt;
    private bool promptActive = false;

    private ObjectGrabbable objectGrabbable;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        prompt.gameObject.SetActive(false);
    }

    private void OnInteract()
    {
        if (objectGrabbable == null)
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward,
                    out RaycastHit raycastHit,
                    pickUpDistance, pickUpLayerMask))
            {
                if (raycastHit.transform.transform.TryGetComponent(out objectGrabbable))
                {
                    objectGrabbable.Grab(objectGrabPointTransform);
                    Debug.Log("hit");
                }
            }
        }
        else
        {
            objectGrabbable.Drop(objectDropPointTransform);
            objectGrabbable = null;
        }
    }

    private void Update()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward,
                out RaycastHit raycastHit,
                pickUpDistance, pickUpLayerMask))
        {
            if (raycastHit.transform.transform.TryGetComponent(out ObjectGrabbable grabbable))
            {
                if (!promptActive)
                {
                    prompt.gameObject.SetActive(true);
                    promptActive = true;
                }
            }
            else
            {
                if (promptActive)
                {
                    prompt.gameObject.SetActive(false);
                    promptActive = false;
                }
            }
        }
        else
        {
            if (promptActive)
            {
                prompt.gameObject.SetActive(false);
                promptActive = false;
            }
        }
    }
}