using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amaris_Controller : MonoBehaviour
{ 
    Transform player;
    public float velocidadX;
    public float velocidadY;
    public float fuerzaSalto;
    public Rigidbody2D rb2D;
    public Animator animator;
    int limiteSaltos=2;
    int saltosHechos;
    public Transform Firepoint;


    int cantidad_click;
    bool puedo_dar_click;
    public RigidbodyConstraints2D originalConstraints;
    public bool puedo_moverme;  
    // Start is called before the first frame update
    
    void Start()
    {
        animator= GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        saltosHechos=0;
        cantidad_click = 0;
        puedo_dar_click = true;
        puedo_moverme = true;
 
    }

    // Update is called once per frame
    void Update()
    {
        
        velocidadX=0f;

        float Direction = Input.GetAxis ("Horizontal");
        
        if (Direction > 0 && puedo_moverme == true) {
            transform.localScale = new Vector3 (1,1,1);
            velocidadX = 6;
            GetComponent<Animator> ().SetBool ("estaCorriendo", true);
            Firepoint.transform.eulerAngles= new Vector3 (0,0,0);


        } 

        else if (Direction < 0 && puedo_moverme == true) { 
            transform.localScale = new Vector3(-1,1,1);
            velocidadX = -6;
            GetComponent<Animator> ().SetBool ("estaCorriendo", true);
            Firepoint.transform.eulerAngles= new Vector3 (0,180,0);
            Firepoint.transform.localScale= new Vector3 (-1,1,1);
        }
  
                              
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
        {
           velocidadX = 0;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
        {
           velocidadX = 0;
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
        {
           velocidadX = 0;
        }

             
       transform.Translate(velocidadX*Time.deltaTime,0f,0f);

       if (velocidadX==0f) {
           GetComponent<Animator> ().SetBool ("estaCorriendo", false);
       }
       

       if (Input.GetKeyDown(KeyCode.Space)) 

       {

           if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1"))
           {
           animator.SetBool("estaSaltando", false);
           }
           else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
           {
           animator.SetBool("estaSaltando", false);
           }
           else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
           {
           animator.SetBool("estaSaltando", false);
           }
           else if (saltosHechos == 0){
           animator.SetBool("estaSaltando", true);
           rb2D.AddForce(new Vector2(0,fuerzaSalto),ForceMode2D.Impulse);
           saltosHechos++;
           cantidad_click = 0;
           puedo_dar_click = false;
           }

           else if (saltosHechos==1){
           animator.SetBool("dobleSalto", true);
           rb2D.AddForce(new Vector2(0,9),ForceMode2D.Impulse);
           saltosHechos++;

           }


        }

       if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
       {
           cantidad_click = 0;
           puedo_dar_click = false;

       }
       if (animator.GetCurrentAnimatorStateInfo(0).IsName("Double_Jump"))
       {
           cantidad_click = 0;
           puedo_dar_click = false;

       }


       if(Input.GetMouseButtonDown(0) && puedo_dar_click == true)
       { 
           Iniciar_combo(); 
        
        }
 
   
       if (animator.GetCurrentAnimatorStateInfo(0).IsName("Transition3"))
       {
            puedo_dar_click = true;
            cantidad_click = 0;
            animator.SetInteger("attack", 0);

        }
       
       
    }
    
    
    
    
    void Iniciar_combo()
    {
        
        if (puedo_dar_click)
        {
            cantidad_click++;
        }

        if (cantidad_click == 1)
        {
            animator.SetInteger("attack", 1);
        }
    }

    public void Verificar_combo()
    {
        puedo_dar_click = false;

        
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && cantidad_click == 1)
        {       
    
            animator.SetInteger("attack", 0);
            puedo_dar_click = true;
            cantidad_click= 0;
            velocidadX = 0;
            velocidadY = 0;


        }   
           
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && cantidad_click >= 2)
        {

            animator.SetInteger("attack", 2);
            puedo_dar_click = true;
            velocidadX = 0;
            velocidadY = 0;   
                
                
        }

    
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && cantidad_click == 2)
        {
       
            animator.SetInteger("attack", 0);
            cantidad_click = 0;
            puedo_dar_click = true;
            velocidadX = 0;
            velocidadY = 0;   

            
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack2") && cantidad_click >= 3)
        {

            animator.SetInteger("attack", 3);
            puedo_dar_click = false;
            cantidad_click=0;
            velocidadX = 0;
            velocidadY = 0;
                
        }
            
            
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack3"))
        {

    
            animator.SetInteger("attack", 0);
            puedo_dar_click = true;
            cantidad_click = 0;
            velocidadY = 0;
        
        }
        

    }

    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("estaSaltando", false);
            animator.SetBool("dobleSalto", false);
            saltosHechos=0;
        }
        

        
    }   
    
  

}
