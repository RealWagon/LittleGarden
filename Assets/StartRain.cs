using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StartRain : MonoBehaviour
{
    [SerializeField] private GameObject rain;

    private void Awake()
    {
        rain.SetActive(false);
    }

    void OnTriggerEnter()
    {
        rain.SetActive(true);
    }

    private void FixedUpdate()
    {
        if(rain ==  true)
        {
            
        }
    }
}
