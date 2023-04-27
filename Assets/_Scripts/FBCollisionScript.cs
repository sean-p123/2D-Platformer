using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FBCollisionScript : MonoBehaviour
{
    // Reference to the Tilemap object
    public Tilemap tilemap;

    private void OnCollisionEnter2D(Collision2D collision)
     {
        // destroy the fireball if it collides with an object tagged with "Barrier"
        if (collision.gameObject.tag == "Barrier")
         {
             Debug.Log("Fireball collision");
             Destroy(this.gameObject);
         }
     }

 
}
