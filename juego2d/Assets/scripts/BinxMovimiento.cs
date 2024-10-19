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
    private int health = 1;
    private float LastShoot;
    private List<GameObject> pool = new List<GameObject>();
    
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

        Debug.DrawRay(transform.position, Vector2.down * 1.0f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector2.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.X) && Grounded)
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.Z) && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void Shoot()
    {
        
        getBala();
        
    }

    
    public void Hit()
    {
        health--;
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }

    public GameObject getBala()
    
    {
        Vector3 direction;
        
        for(int i=0; i<pool.Count; i++)
        {
            if(!pool[i].activeInHierarchy)
            {
                if(transform.localScale.x == 1.0f) direction = Vector2.right;
                else direction = Vector2.left;
                pool[i].transform.position = transform.position + direction * 1.5f;
                pool[i].GetComponent<DisparoScript>().SetDirection(direction);
                
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        if(transform.localScale.x == 1.0f) direction = Vector2.right;
        else direction = Vector2.left;
        GameObject obj = Instantiate(DisparoGarra, transform.position + direction *1.5f, Quaternion.identity) as GameObject;
        obj.GetComponent<DisparoScript>().SetDirection(direction);
        pool.Add(obj);
        return obj;
      
    }


    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal * speed, Rigidbody2D.velocity.y);
    }
}
