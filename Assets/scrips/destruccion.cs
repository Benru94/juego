using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class destruccion : MonoBehaviour
{
    public float resistance;
    public GameObject explosionPrefab;
    public vida v = new vida();


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.relativeVelocity.magnitude > resistance)
        {

            if (explosionPrefab != null)
            {

                var go = Instantiate(explosionPrefab,
                    transform.position,
                    Quaternion.identity);

                Destroy(go, 3);



            }

            Destroy(gameObject, 0.1f);

            


        }
        else
        {

            resistance -= collision.relativeVelocity.magnitude;
           

        }

        
    }

   


    private void OnDestroy()
    {

        
        
        if (gameObject.tag == "caja")
        {

            Score.puntuacion += 1000;
            


        }
        if (gameObject.tag == "dino" && resistance > 0)
        {

            Score.puntuacion += 25000;

        }
        else
        {
            Score.puntuacion += 0;
            
        }
     
        
    }

  
   

   
}
