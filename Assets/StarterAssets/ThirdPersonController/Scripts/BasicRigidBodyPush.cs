using UnityEngine;
using UnityEngine.InputSystem;

public class BasicRigidBodyPush : MonoBehaviour
{
    public LayerMask pushLayers;
    public LayerMask pickupLayer; // Add a new layer mask for pickup objects
    public bool canPush = true;
    [Range(0.5f, 5f)] public float strength = 1.1f;
    public float pushUpForce = 10f;  // Force to push the player upwards if they get on top of the ball

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (canPush) PushRigidBodies(hit);

        // Additional logic to push the player off the ball if they get on top
        PreventPlayerFromGettingOnTop(hit);
    }

    private void PushRigidBodies(ControllerColliderHit hit)
    {
        // https://docs.unity3d.com/ScriptReference/CharacterController.OnControllerColliderHit.html

        // make sure we hit a non-kinematic rigidbody
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic) return;

        // make sure we only push desired layer(s)
        var bodyLayerMask = 1 << body.gameObject.layer;
        if ((bodyLayerMask & pushLayers.value) == 0) return;

        // We don't want to push objects below us
        if (hit.moveDirection.y < -0.3f) return;

        // Calculate push direction from move direction, horizontal motion only
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0.0f, hit.moveDirection.z);

        // Apply the push and take strength into account
        body.AddForce(pushDir * strength, ForceMode.Impulse);
    }

    private void PreventPlayerFromGettingOnTop(ControllerColliderHit hit)

    {

        // Check if the object is a ball (or the specific object you want to prevent climbing on)

        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic) return;


        // Assuming the ball is on a specific layer

        var bodyLayerMask = 1 << body.gameObject.layer;

        if ((bodyLayerMask & pushLayers.value) == 0) return;


        // Check if the player is on top of the ball

        if (hit.moveDirection.y > 0.5f)

        {

            // Get the CharacterController component

            CharacterController controller = GetComponent<CharacterController>();


            // Push the player upwards to prevent them from staying on top of the ball

            Vector3 pushUpDir = new Vector3(0, 1, 0);

            controller.Move(pushUpDir * pushUpForce * Time.deltaTime);

        }

    }
}