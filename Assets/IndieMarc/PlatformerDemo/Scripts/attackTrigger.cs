using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class attackTrigger : MonoBehaviour
{

    public int dmg = 2;
    public Slider vidaOculus;
    public Slider vidaBellator;
    public Slider vidaGolem;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            vidaOculus.value = vidaOculus.value - dmg;


        }
        else if (collision.tag == "EnemyBellator")
        {
            vidaBellator.value = vidaBellator.value - dmg;


        }
        else if (collision.tag == "EnemyGolem")
        {
            vidaGolem.value = vidaGolem.value - dmg;


        }
    }



}
