using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InteractivePlatform : MonoBehaviour
{
    public GameObject bottonPlatform;
    public Tilemap platform;
    public float vanisheTime = 5.0f;
    private bool activeTimer = false;
    private float controlTime;
    private float actualTime;
    //private bool bottonColor = true;

    void Start()
    {
       
    }

    
    void Update()
    {
        //Debug.Log(bottonColor);
        if (activeTimer)
        {
            actualTime = Time.realtimeSinceStartup - controlTime;
           
            if (actualTime >= vanisheTime)
            {
                platform.GetComponent<TilemapRenderer>().enabled = false;
                platform.GetComponent<TilemapCollider2D>().enabled = false;
                activeTimer = false;
                actualTime = 0.0f;
                controlTime = 0.0f;
            }
        }
       
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            platform.GetComponent<TilemapRenderer>().enabled = true;
            platform.GetComponent<TilemapCollider2D>().enabled = true;
            platform.enabled = true;

            bottonPlatform.transform.localScale = new Vector3(0.9f, 0.2f, 1);
            /*if (bottonColor)
            {
                bottonPlatform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 100);
                bottonColor = false;
            }*/
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)

    {
        //bottonColor = true;
        //bottonPlatform.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        bottonPlatform.transform.localScale = new Vector3(0.9f, 2, 1);
        if (activeTimer == false)
        {
            if (collision.tag == "Player")
            {
                activeTimer = true;
                controlTime = Time.realtimeSinceStartup;
                

            }
        }
        
    }
}
