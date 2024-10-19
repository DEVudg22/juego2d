using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HikariSoldierScript : MonoBehaviour
{
   public GameObject Binx;
   public GameObject bullet;

   private float LastShoot;
   private int health = 3;
    private List<GameObject> pool = new List<GameObject>();

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
        GameObject obj = Instantiate(bullet, transform.position + direction *1.5f, Quaternion.identity) as GameObject;
        obj.GetComponent<DisparoScript>().SetDirection(direction);
        pool.Add(obj);
        return obj;
      
    }
}
