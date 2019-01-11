using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KambaiAtaques : MonoBehaviour
{

    
    public Rigidbody flecha; //flecha para ataque
    public Rigidbody bola; //bola para ataque

    public Transform muzzle; //ponto onde sai os disparos
    public float velocidadeDisparo; //velocidade do disparo
    private Animator animator; //animator do personagem


    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AtaquesController.isAtaqueA)
        {
            animator.SetBool("isAtacandoA", true);
            Rigidbody c = Rigidbody.Instantiate(this.flecha, this.muzzle.position, this.muzzle.rotation) as Rigidbody;
            c.AddForce(this.muzzle.forward * this.velocidadeDisparo);
            AtaquesController.isAtaqueA = false;
        } else  animator.SetBool("isAtacandoA", false);

        if (AtaquesController.isAtaqueB)
        {
            animator.SetBool("isAtacandoB", true);
            Rigidbody c = Rigidbody.Instantiate(this.bola, this.muzzle.position, this.muzzle.rotation) as Rigidbody;
            c.AddForce(this.muzzle.forward * this.velocidadeDisparo);
            AtaquesController.isAtaqueB = false;
        }
        else animator.SetBool("isAtacandoB", false);
    }
}
