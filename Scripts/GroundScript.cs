using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    HealthManager healthManager;
    public GameObject gameOver;
    private void Start()
    {
        healthManager = GameObject.FindWithTag("GameController").GetComponent<HealthManager>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            healthManager.RestHealth(100);
            gameOver.SetActive(true);
            

        }
    }
}
