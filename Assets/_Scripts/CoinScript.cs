using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

   //***Here i attempted to delete coins on reload but it didnt work
   /* public GameObject[] coins;

    private void Start()
    {
        
        foreach (GameObject coin in coins){
            if (coin == gameObject)
            {
                // This is the current coin, check if it was collected already
                if (LifeManager.instance.hasCoinBeenCollected(coin))
                {
                    // Coin was collected, disable it
                    gameObject.SetActive(false);
                }
            }
        }
      /*  if (LifeManager.instance.hasCoinBeenCollected())
        {
            // If the Heart has been collected before, deactivate it
            coins[1].SetActive(false);
        }
    }*/
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            LifeManager.instance.ChangeScore(gameObject);
            // Destroy the coin object
           Destroy(gameObject);
        }
    }
}
