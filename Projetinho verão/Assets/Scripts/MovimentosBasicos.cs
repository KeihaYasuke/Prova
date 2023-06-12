using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentosBasicos : MonoBehaviour
{

    private Rigidbody2D rbPlayer;
    private Animator anim;
    public float velocidade;
    public float forcaPulo;
    private float imputMovimentoHorizontal;
    
    
    
    // Start is called before the first frame update
    void Start()
    {

        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        imputMovimentoHorizontal = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity = new Vector2(imputMovimentoHorizontal* velocidade,rbPlayer.velocity.y);

        anim.SetInteger("walk", (int) imputMovimentoHorizontal);

    }
}
