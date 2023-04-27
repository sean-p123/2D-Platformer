using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public PlayerMovement pm;
    public DeathScript ds;
    public CameraFollowScript cfs;
    public LivesManager lm;
    public PortalScript ps;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("In collision method1");
        
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Collided with enemy");
            //   pm.playerHit();
            ds.enabled = true;
           // cfs.enabled = false;
           // lm.Died();
         //   Destroy(this.gameObject);
        }

        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided with enemy");
            Destroy(this.gameObject);
        }

       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Portal")
        {
            Debug.Log("PortalTrigger");
            ps.isActive = true;
            
            Debug.Log("PortalTrigger");
        }
    }

}
