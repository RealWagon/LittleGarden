using UnityEngine;

public class ToggleMaterial : MonoBehaviour
{
    public Material material1;
    public Material material2;
    
    private Renderer rend;
    private bool usingMaterial1 = true;
    
    void Start()
    {
        gameObject.tag = "Dirt_WaterDrop";
        rend = GetComponent<Renderer>();
        
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
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (usingMaterial1)
            {
                rend.material = material2;
                gameObject.tag = "WaterDrop";
            }
            else
            {
                rend.material = material1;
                gameObject.tag = "Dirt_WaterDrop";
            }
            usingMaterial1 = !usingMaterial1;
        }
    }
}