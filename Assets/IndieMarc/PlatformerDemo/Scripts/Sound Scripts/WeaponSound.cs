using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSound : MonoBehaviour
{
    [SerializeField] private AudioClip swingSound;
    [SerializeField] private AudioClip impactSound;


    public void StartUsing()
    {
        AudioManager.Instance.PlayClip(swingSound, transform.position);
    }

    virtual public void Attack(GameObject[] targets)
    {
        AudioManager.Instance.PlayClip(impactSound, transform.position);
    }
}