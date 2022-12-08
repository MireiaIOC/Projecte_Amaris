using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    HealthManager healthManager;
    private void Start()
    {
        healthManager = GameObject.FindWithTag("GameController").GetComponent<HealthManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            healthManager.RestHealth(2);
            Debug.Log("planta");

        }
    }
    
    
        
    
}
