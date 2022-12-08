using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
  

 
 void OnTriggerEnter2D(Collider2D other) 
 {
    Debug.Log(other.tag);
    if (other.tag == "Player")
    {
        
       SceneManager.LoadScene("Win");

    }
 }   
 void OnTriggerStay2D(Collider2D other) 
 {
    Debug.Log(other.tag);
    if (other.tag == "Player")
    {
        
       SceneManager.LoadScene("Win");

    }
 }   
}
