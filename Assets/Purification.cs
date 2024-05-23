using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purification : MonoBehaviour
{
    public string targetTag = "WaterDrop";
    public int health = 3;
    public float scaleDuration = 0.5f;

    private Vector3 initialScale;
    private Vector3 targetScale;
    private float scaleLerpTime;
    private bool isScaling;

    void Start()
    {
        initialScale = transform.localScale;
        targetScale = initialScale;
    }

    void FixedUpdate()
    {
        if (isScaling)
        {
            scaleLerpTime += Time.deltaTime;
            float t = scaleLerpTime / scaleDuration;
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, t);

            if (t >= 1f) isScaling = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaterDrop"))
        {
            Destroy(other.gameObject);
            health--;

            targetScale = initialScale * (health / 3f);
            scaleLerpTime = 0f;
            isScaling = true;

            if (health <= 0) Destroy(gameObject);
        }
        if (other.CompareTag("Dirt_WaterDrop"))
        {
            Destroy(other.gameObject);
            health++;
            
            targetScale = initialScale * (health / 3f);
            scaleLerpTime = 0f;
            isScaling = true;
        }
    }
}