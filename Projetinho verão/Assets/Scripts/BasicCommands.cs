using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCommands : MonoBehaviour
{

    public int velocidade;                                                          // define a velocidade de movimentação
    private Rigidbody2D player;                                             // criar variável para percebeer os componentes de física
    public float forcaPulo;                                              //define a força do pulo


    public bool sensor;                                                 // sensor para verificar se está colidindo com o chão
    public Transform posicaoSensor;                                     //posição onde o sensor será posicionado
    public LayerMask layerChao;                                         // camada de interação 

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

       



        anim.SetInteger("run", (int)movimentoX); //animação de correr

        if (movimentoX > 0)
        {
            sprite.flipX = false;
        }
        else if (movimentoX < 0)
        {
            sprite.flipX = true;
        }


        if (Input.GetButtonDown("Fire1")) //animação de bater
        {
            anim.SetTrigger("attack");
        }
        

    }

    private void FixedUpdate()
    { 
        //cria um sensor em posição com o raio e layer tambem definida
        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.1f, layerChao);   

    }
}
