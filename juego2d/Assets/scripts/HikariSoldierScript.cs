using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HikariSoldierScript : MonoBehaviour
{
   public GameObject Binx;
   public GameObject bullet;

   private float LastShoot;
   private int health = 3;

   private void Update()
   {
	   Vector3 direction = Binx.transform.position - transform.position;
	   if(direction.x >= 0.0f)
	   {
		   transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
	   }else
	   {
		   transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
	   }

	   float distance = Mathf.Abs(Binx.transform.position.x - transform.position.x);

	   if(distance < 10.0f && Time.time > LastShoot + 2.25f)
	   {
		   Shoot();
		   LastShoot = Time.time;
	   }   
   }

   private void Shoot()
	   {
		   Vector3 direction;
		   if(transform.localScale.x == 1.0f) direction = Vector2.right;
		   else direction = Vector2.left;

		   bullet = Instantiate(bullet, transform.position + direction * 1.5f, Quaternion.identity);
		   bullet.GetComponent<DisparoScript>().SetDirection(direction);
		  
	   }

	   public void Hit()
    {
        health--;
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
}
