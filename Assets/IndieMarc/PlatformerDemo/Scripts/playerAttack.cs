using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{

    private bool attacking = false;

    public Collider2D attackTrigger;

    private Animator anim; 

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("1") && !attacking)
        {
            attacking = true;
            anim.SetBool("Attacking", attacking);
            attackTrigger.enabled = true; 
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Transition"))
        {
            anim.SetBool("Attacking", false);
            attacking = false;
        }
    }


}
