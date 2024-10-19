using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoScript : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private Vector2 Direction;

    
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void update()
    {
        
    }

    
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
       
       
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }


    void OnTriggerEnter2D(Collider2D collision) 
    {
        BinxMovimiento Binx = collision.GetComponent<BinxMovimiento>();
        HikariSoldierScript HikariSoldier = collision.GetComponent<HikariSoldierScript>();
        
        if(Binx != null)
        {
            Binx.Hit();
            gameObject.SetActive(false);
            
            
           
        }

        if(HikariSoldier != null)
        {
            HikariSoldier.Hit();
            gameObject.SetActive(false);
            
        }

        
       
        
    }

  


}
