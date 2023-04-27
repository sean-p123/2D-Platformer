using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    private static bool hasBeenCollected = false;

    void Start()
    {
        // Check if the Heart has been collected before
        if (LifeManager.instance.HasHeartBeenCollected())
        {
            // If the Heart has been collected before, deactivate it
         //   gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && !hasBeenCollected)
        {
            Debug.Log("HeartScript" );
            hasBeenCollected = true;
            LifeManager.instance.addLife(gameObject);
      //      LifeManager.instance.HasHeartBeenCollected();
         //   gameObject.SetActive(false);
        }

        /*  if (collision.gameObject.CompareTag("Player"))
          {
          //    Destroy(gameObject);
              //  ScoreManager.instance.ChangeScore(value);
              LifeManager.instance.addLife(gameObject);
          }*/
    }

    
}
