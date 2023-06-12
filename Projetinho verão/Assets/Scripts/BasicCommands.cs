using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCommands : MonoBehaviour
{

    public int velocidade;                                                          // define a velocidade de movimenta��o
    private Rigidbody2D player;                                             // criar vari�vel para percebeer os componentes de f�sica
    public float forcaPulo;                                              //define a for�a do pulo


    public bool sensor;                                                 // sensor para verificar se est� colidindo com o ch�o
    public Transform posicaoSensor;                                     //posi��o onde o sensor ser� posicionado
    public LayerMask layerChao;                                         // camada de intera��o 

    private Animator anim;
    private Animator anim2;
    private SpriteRenderer sprite;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

    }

    
    void Update()
    {
        float movimentoX = Input.GetAxisRaw("Horizontal");
        player.velocity = new Vector2(movimentoX * velocidade, player.velocity.y);
        

        if (Input.GetButtonDown("Jump") && sensor == true) //movimento de pulo atravez do sensor
        {
            player.AddForce(new Vector2(0, forcaPulo));
        }

        anim.SetBool("jump", sensor);

       



        anim.SetInteger("run", (int)movimentoX); //anima��o de correr

        if (movimentoX > 0)
        {
            sprite.flipX = false;
        }
        else if (movimentoX < 0)
        {
            sprite.flipX = true;
        }


        if (Input.GetButtonDown("Fire1")) //anima��o de bater
        {
            anim.SetTrigger("attack");
        }
        

    }

    private void FixedUpdate()
    { 
        //cria um sensor em posi��o com o raio e layer tambem definida
        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.1f, layerChao);   

    }
}
