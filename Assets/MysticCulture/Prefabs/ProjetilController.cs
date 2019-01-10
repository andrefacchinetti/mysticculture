using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilController : MonoBehaviour
{

    public Rigidbody projetil;
    public Transform muzzle;
    public float velocidade;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Ataque1"))
        {
            animator.SetBool("isAtacando1", true);
            Rigidbody c = Rigidbody.Instantiate(this.projetil, this.muzzle.position, this.muzzle.rotation) as Rigidbody;
            c.AddForce(this.muzzle.forward * this.velocidade);
        }else
        animator.SetBool("isAtacando1", false);
    }
}
