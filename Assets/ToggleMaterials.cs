using System;
using UnityEngine;

public class ToggleMaterial : MonoBehaviour
{
    public Material material1;
    public Material material2;
    
    private Renderer rend;
    private bool usingMaterial1 = true;
    
    private Drop drop;
    
    void Start()
    {
        drop = GetComponent<Drop>();
        
        drop.Wiggle();
        gameObject.tag = "Dirt_WaterDrop";
        rend = GetComponent<Renderer>();
        
        if (rend != null && material1 != null && material2 != null)
        {
            // Set the initial material
            rend.material = material1;
            drop.Wiggle();
        }
        else
        {
            Debug.LogError("Renderer or one of the materials is not assigned.");
        }
    }
    
  /*  void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (usingMaterial1)
            {
                rend.material = material2;
                gameObject.tag = "WaterDrop";
                drop.Wiggle();
                
            }
            else
            {
                rend.material = material1;
                gameObject.tag = "Dirt_WaterDrop";
                drop.Wiggle();
            }
            usingMaterial1 = !usingMaterial1;
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Flower"))
        {
            rend.material = material2;
            gameObject.tag = "WaterDrop";
            drop.Wiggle();
        }
    }
}