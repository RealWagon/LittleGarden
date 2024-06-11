using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purification : MonoBehaviour
{
    public string targetTagWater;
    public string targetTagDirt;
    public int health;
    public float scaleDuration = 0.5f;

    private Vector3 initialScale;
    private Vector3 targetScale;
    private float scaleLerpTime;
    private bool isScaling;

    void Start()
    {
        initialScale = transform.localScale;
        targetScale = initialScale * health;
        scaleLerpTime = 0f;
        isScaling = true;
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
        if (other.CompareTag(targetTagWater))
        {
            Destroy(other.gameObject);
            health--;

            // Decreased the scale when colliding with "WaterDirt" object
            targetScale = initialScale * health;
            scaleLerpTime = 0f;
            isScaling = true;

            if (health <= 0) Destroy(gameObject);
        }
        if (other.CompareTag(targetTagDirt))
        {
            Destroy(other.gameObject);
            health++;
            scaleLerpTime = 0f;
            isScaling = true;

            targetScale = initialScale * health;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, (health / 2f ));
    }
}