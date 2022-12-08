using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    HealthPlayer healthPlayer;
    public int amount;
    public GameObject gameOver;
   
    
    
    void Start()
    {
        healthPlayer = GameObject.FindWithTag("Player").GetComponent<HealthPlayer>();
    }

   public void AddHealth(int amount)
    {
        healthPlayer.health += amount;
        if (healthPlayer.health > 100) { healthPlayer.health = 100; }


    }

    public void RestHealth(int amount)
    {
        healthPlayer.health -= amount;
        if (healthPlayer.health < 0) 
        { 
            healthPlayer.health = 0;
            gameOver.SetActive(true);

            
        }


    }

}
