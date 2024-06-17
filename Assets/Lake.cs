using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lake : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playera;
    [SerializeField] private List<Transform> waterObjects = new List<Transform>();
    [SerializeField] private Transform waterRespawnPoint;

    private CharacterController playerController;
    private CharacterController playeraController;

    private void Start()
    {
        playerController = player.GetComponent<CharacterController>();
        playeraController = playera.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            RespawnPlayer();
        }
        else if (other.CompareTag("WaterDrop"))
        {
            RespawnWaterDrop(other.transform);
        }
    }

    private void RespawnPlayer()
    {
        player.transform.position = respawnPoint.position;
        playeraController.enabled = false;
        playera.transform.position = respawnPoint.position;
        playeraController.enabled = true;
    }

    private void RespawnWaterDrop(Transform water)
    {
        if (water != null && waterRespawnPoint != null)
        {
            water.position = waterRespawnPoint.position;
            Rigidbody waterRb = water.GetComponent<Rigidbody>();
            if (waterRb != null)
            {
                waterRb.velocity = Vector3.zero;
                waterRb.angularVelocity = Vector3.zero;
            }
        }
        else
        {
            Debug.LogWarning("Water object or Water Respawn Point is not assigned.");
        }
    }
}