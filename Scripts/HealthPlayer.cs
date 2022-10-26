using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayer : MonoBehaviour
  
{
    public float health = 100;
    public Image healthBar;

    void Update()
    {
        health = Mathf.Clamp(health, 0, 100);
        healthBar.fillAmount = health / 100;
    }
}
