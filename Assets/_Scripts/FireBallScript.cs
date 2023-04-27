using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallScript : MonoBehaviour
{
    public float speed = 1f; // the speed at which the bullet will travel
    public float lifespan = 2f; // the lifespan of the bullet in seconds

    private float timer = 0f; // the amount of time that has elapsed since the bullet was fired

    void Update()
    {
        // increment the timer
        timer += Time.deltaTime;

        // destroy the bullet if its lifespan has expired
        if (timer >= lifespan)
        {
           //// Destroy(gameObject);
        }
    }

    /* private void OnCollisionEnter2D(Collision2D collision)
     {
         // destroy the bullet if it collides with an object tagged with "Enemy"
         if (collision.gameObject.tag == "Barrier")
         {
             Debug.Log("Fireball collision");
             Destroy(this.gameObject);
         }
     }*/

    /* private void OnCollisionEnter2D(Collision2D collision)
     {
         Debug.Log("In collision method");

         if (collision.gameObject.tag == "Barrier")
         {
             Debug.Log("Collided with barrier");

             Destroy(this.gameObject);
         }

     }*/

    void OnCollisionEnter2D(Collision2D collision)
    {
        // check if the fireball collided with a barrier
        if (collision.gameObject.tag == ("Barrier"))
        {
            Debug.Log("Collided with barrier");
            // destroy the fireball object
            Destroy(gameObject);
        }
    }

}
