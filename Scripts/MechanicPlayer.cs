using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicPlayer : MonoBehaviour
{
    HealthManager healthManager;

    void Start()
    {
        healthManager = GameObject.FindWithTag("GameController").GetComponent<HealthManager>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            healthManager.AddHealth(20);
            Debug.Log("Curar");

        }
        
    }
}
