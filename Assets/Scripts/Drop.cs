using System.Collections;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Rigidbody springRigidbody;
    [SerializeField] private GameObject fxPrefab;
    [SerializeField] private float fxVelocityThreshold;

    private Material material;

    private static readonly int SpringDirID = Shader.PropertyToID("_SpringDir");

    private void Awake()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        material = renderer.material;
        renderer.material = material;
        
        if (rigidbody == null)
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
        Vector3 springDir = springRigidbody.position - rigidbody.position;
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
        if (fxPrefab != null)
        {
            GameObject fxInstance = Instantiate(fxPrefab, position, Quaternion.identity);
            // You may want to handle the fxInstance here, for example, deactivate it after a certain time.
        }
        else
        {
            Debug.LogError("FX Prefab is not assigned to Drop script.");
        }
    }
}