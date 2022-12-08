using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IA_Bellator : MonoBehaviour

{
    public Animator animator;
    [SerializeField]
    Transform Player;
    public float damage;
    public Patrullar_Bellator patrullar;
    public AudioClip OculusAttack;
    public AudioSource audioSource;


    [SerializeField]
    public Slider vidaOculus;
    public float rangoAgro;
    public float velocidadMov;
    Rigidbody2D rb2d;






    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("Caminar", false);
        animator.SetBool("Muerto", false);


    }


    void Update()
    {


        float distJugador = Vector2.Distance(transform.position, Player.position);
        Debug.Log("Distancia del jugador: " + distJugador);

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Transition"))
        {
            animator.SetBool("Atacar", false);
            patrullar.velocidadMovimiento = 3;
        }

        if (distJugador < rangoAgro && Mathf.Abs(distJugador) > 6)
        {
            animator.SetBool("Caminar", false);
            animator.SetBool("Atacar", false);

        }
        else if (Mathf.Abs(distJugador) < 1)
        {
            animator.SetBool("Atacar", true);
            velocidadMov = 3;
            patrullar.velocidadMovimiento = 0;
            audioSource.PlayOneShot(OculusAttack);
        }



        else
        {
            animator.SetFloat("Velocidad", 3);

        }
        if (vidaOculus.value <= 0)
        {
            animator.SetBool("Muerto", true);

        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Transition1"))
        {
            Destroy(gameObject);
            ScoreManager.instance.AddPoint(200);
        }



    }


}
