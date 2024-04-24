using UnityEngine;

public class BallPush : MonoBehaviour
{
    public float pushForce = 10f; // Adjust this value to change the force applied to the ball

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the ball
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a Rigidbody
        Rigidbody otherRigidbody = collision.collider.GetComponent<Rigidbody>();
        if (otherRigidbody != null)
        {
            // Calculate the direction in which to apply the force
            Vector3 forceDirection = collision.contacts[0].normal; // Use the collision normal as the force direction

            // Apply the force to the ball
            rb.AddForce(forceDirection * pushForce, ForceMode.Impulse);
        }
    }
}
