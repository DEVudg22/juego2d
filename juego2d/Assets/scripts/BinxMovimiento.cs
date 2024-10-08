using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinxMovimiento : MonoBehaviour
{
    
    public float JumpForce;
    public float speed;
    public GameObject DisparoGarra;
    

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
    
    void Start()
    {
        //toma el componente rigidbody para utilizarlo en este script
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        //se detecta la tecla que el jugador esta presionando
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("caminando", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector2.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.X) && Grounded)
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            Shoot();
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if(transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        DisparoGarra = Instantiate(DisparoGarra, transform.position + direction * 0.1f, Quaternion.identity);
        DisparoGarra.GetComponent<DisparoScript>().SetDirection(direction);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * speed, Rigidbody2D.velocity.y);
    }
}
