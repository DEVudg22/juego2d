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

    
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = Direction * Speed;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    public void CreateBullet()
    {
        Instantiate(gameObject);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        BinxMovimiento Binx = collision.collider.GetComponent<BinxMovimiento>();
        HikariSoldierScript HikariSoldier = collision.collider.GetComponent<HikariSoldierScript>();
        
        if(Binx != null)
        {
            Binx.Hit();
        }

        if(HikariSoldier != null)
        {
            HikariSoldier.Hit();
        }
        
       //DestroyBullet();
        
        
        
    }
}
