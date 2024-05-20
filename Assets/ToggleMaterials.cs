using UnityEngine;

public class ToggleMaterial : MonoBehaviour
{
    // Reference to the two materials
    public Material material1;
    public Material material2;

    // Reference to the Renderer component
    private Renderer rend;

    // Variable to track the current material
    private bool usingMaterial1 = true;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Renderer component from the GameObject
        rend = GetComponent<Renderer>();

        // Check if the Renderer and materials are not null
        if (rend != null && material1 != null && material2 != null)
        {
            // Set the initial material
            rend.material = material1;
        }
        else
        {
            Debug.LogError("Renderer or one of the materials is not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "C" key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Toggle the material
            if (usingMaterial1)
            {
                rend.material = material2;
            }
            else
            {
                rend.material = material1;
            }

            // Update the material tracking variable
            usingMaterial1 = !usingMaterial1;
        }
    }
}