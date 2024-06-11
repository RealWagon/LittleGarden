using System;
using System.Collections;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Rigidbody springRigidbody;
    [SerializeField] private GameObject fxPrefab;
    [SerializeField] private GameObject explosionFxPrefab;
    [SerializeField] private float fxVelocityThreshold;
    [SerializeField] private float dedonateTimer;
    [SerializeField] private float fxTimer = 2f;

    private GameObject fxInstance;
    private Material material;
    private float timer = 0f;

    private static readonly int SpringDirID = Shader.PropertyToID("_SpringDir");

    private void Awake()
    {
        Wiggle();
    }

    public void Wiggle()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        material = renderer.material;
        renderer.material = material;

        if (rb == null)
        {
            Debug.LogError("Rigidbody component is not assigned to Drop script.");
        }

        if (springRigidbody == null)
        {
            Debug.LogError("Spring Rigidbody component is not assigned to Drop script.");
        }
    }

    private void Update()
    {
        Vector3 springDir = springRigidbody.position - rb.position;
        material.SetVector(SpringDirID, springDir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > fxVelocityThreshold)
        {
            InstantiateFX(collision.contacts[0].point);
        }
    }

    private void InstantiateFX(Vector3 position)
    {
        if (fxInstance != null)
        {
            Destroy(fxInstance);
        }

        if (fxPrefab != null)
        {
            fxInstance = Instantiate(fxPrefab, position, Quaternion.identity);
            StartCoroutine(CountUp());
        }
        else
        {
            Debug.LogError("FX Prefab is not assigned to Drop script.");
        }
    }
    private IEnumerator CountUp()
    {
        while (timer < fxTimer)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        Destroy(fxInstance);
        timer = 0f; // Reset the timer
    }
}