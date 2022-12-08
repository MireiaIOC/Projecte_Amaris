using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health; 


    public void Damage(int damage)
    {
        health -= damage;
        gameObject.GetComponent<Animation>().Play("CharacteAnimCrouch");
        Debug.Log("damage TAKEN!");

    }

    public void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
