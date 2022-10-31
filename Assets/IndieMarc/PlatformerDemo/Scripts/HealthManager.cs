using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class HealthManager : MonoBehaviour
{
    HealthPlayer healthPlayer;
    public int amount;
   
    
    
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
        if (healthPlayer.health < 0) { healthPlayer.health = 0; }


    }

    void Update () 
    { 
    if  (healthPlayer.health <= 0)
        {
            SceneManager.LoadScene("GameOverMenu");
        }
    }

}
